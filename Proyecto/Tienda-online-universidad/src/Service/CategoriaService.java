/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Service;

import Model.Categoria;
import config.ConexionBD;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Dilan
 */
public class CategoriaService {

    public boolean Create(Categoria categoria) {
        String sql = "INSERT INTO categoria (nombre) VALUES(?)";
        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, categoria.getNombre());

            return ps.executeUpdate() > 0;

        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }

    public boolean Edit(Categoria categoria) {
        String sql = "UPDATE categoria SET nombre= ? WHERE id = ?";
        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, categoria.getNombre());
            ps.setInt(2, categoria.getId());

            return ps.executeUpdate() > 0;

        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }

    public List<Categoria> Read(Categoria categoria) {
        List<Categoria> lista = new ArrayList<>();
        String sql = "SELECT * FROM categoria WHERE LOWER(nombre) LIKE ?";
        String search = "%" + categoria.getNombre() + "%";

        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {

            ps.setString(1, search);

            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Categoria categ = new Categoria(
                        rs.getInt("id"),
                        rs.getString("nombre")
                );
                lista.add(categ);
            }
            return lista;

        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public boolean Delete(Categoria categoria) {
        String sql = "DELETE FROM categoria WHERE id = ?";
        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, categoria.getId());
            return ps.executeUpdate() > 0;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }
}
