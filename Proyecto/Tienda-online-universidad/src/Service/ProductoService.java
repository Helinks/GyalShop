/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Service;

import Model.Categoria;
import Model.Producto;
import java.sql.*;
import config.ConexionBD;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Dilan
 */
public class ProductoService {

    public boolean Create(Producto producto) {
        String sql = "INSERT INTO producto (nombre, precio, stock, categoria) VALUES (?,?,?,?)";

        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, producto.getNombre());
            ps.setDouble(2, producto.getPrecio());
            ps.setInt(3, producto.getStock());
            ps.setInt(4, producto.getCategoria().getId());
            return ps.executeUpdate() > 0;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }

    public boolean Edit(Producto producto) {

        String sql = "UPDATE producto SET nombre = ?, precio = ?, stock = ?, categoria = ? WHERE id = ?";
        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, producto.getNombre());
            ps.setDouble(2, producto.getPrecio());
            ps.setInt(3, producto.getStock());
            ps.setInt(4, producto.getCategoria().getId());
            ps.setInt(5, producto.getId());
            return ps.executeUpdate() > 0;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }

    public List<Producto> Read(Producto producto) {
        List<Producto> lista = new ArrayList<>();
        String sql = "SELECT * FROM producto WHERE LOWER(nombre) = LIKE ?";
        String search = "%" + producto.getNombre() + "%";

        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setString(1, search);
            return lista;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public boolean Delete(Producto producto) {
        String sql = "DELETE FROM producto WHERE id = ?";
        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ps.setInt(1, producto.getId());
            return ps.executeUpdate() > 0;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }

    public List<Categoria> listaDeCategoria() {
        String sql = "SELECT * FROM categoria";
        List<Categoria> lista = new ArrayList<>();

        try (Connection con = ConexionBD.getConnection(); PreparedStatement ps = con.prepareStatement(sql)) {
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Categoria cat = new Categoria(
                        rs.getInt("id"),
                        rs.getString("nombre"));
                lista.add(cat);
            }
            return lista;
        } catch (SQLException e) {
            e.printStackTrace();
            
        }
        return lista;
    }
}
