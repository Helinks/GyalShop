package service;

import Model.Usuario;
import config.ConexionBD;
import java.sql.*;
import enums.Role;
import org.mindrot.jbcrypt.BCrypt;

public class UsuarioService {

    public boolean existeEmail(String email) {
        String sql = "SELECT id_usuario FROM usuarios WHERE email = ?";

        try (Connection con = ConexionBD.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {

            System.out.println("Conectado: " + con);

            ps.setString(1, email);
            ResultSet rs = ps.executeQuery();

            boolean existe = rs.next();

            System.out.println("Existe email? " + existe);

            return existe;

        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }

    public boolean registrar(Usuario usuario) {

        if (existeEmail(usuario.getEmail())) {
            return false;
        }

        String sql = "INSERT INTO usuarios (nombre, email, password, role) VALUES (?, ?, ?, ?)";

        try (Connection con = ConexionBD.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {

            String hashedPassword = BCrypt.hashpw(usuario.getPassword(), BCrypt.gensalt());

            ps.setString(1, usuario.getNombre());
            ps.setString(2, usuario.getEmail());
            ps.setString(3, hashedPassword);
            ps.setString(4, usuario.getRole().name());

            return ps.executeUpdate() > 0;

        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }

    public Usuario login(String email, String password) {
        String sql = "SELECT * FROM usuarios WHERE email = ?";

        try (Connection con = ConexionBD.getConnection();
             PreparedStatement ps = con.prepareStatement(sql)) {

            ps.setString(1, email);
            ResultSet rs = ps.executeQuery();

            if (rs.next()) {

                String hashedPassword = rs.getString("password");

                if (BCrypt.checkpw(password, hashedPassword)) {
                    return new Usuario(
                        rs.getInt("id_usuario"),
                        rs.getString("nombre"),
                        rs.getString("email"),
                        hashedPassword,
                        Role.valueOf(rs.getString("role"))
                    );
                }
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return null;
    }
}