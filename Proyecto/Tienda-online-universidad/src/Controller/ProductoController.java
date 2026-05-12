/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controller;

import Model.Categoria;
import Model.Producto;
import Service.ProductoService;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Dilan
 */
public class ProductoController {

    ProductoService service = new ProductoService();

    public boolean Create(String nombre, double precio, int stock, int idCategoria) {
        Categoria categoria = new Categoria(idCategoria, "");

        Producto producto = new Producto(0, nombre, precio, stock, categoria);
        return this.service.Create(producto);
    }

    public boolean Edit(String nombre, double precio, int stock, int idCategoria) {
        Categoria categoria = new Categoria(idCategoria, "");

        Producto producto = new Producto(0, nombre, precio, stock, categoria);
        return this.service.Edit(producto);
    }

    public List<Producto> Read(String busqueda) {
        Categoria categoria = new Categoria(0, "");
        Producto producto = new Producto(0, busqueda, 0, 0, categoria);
        return this.service.Read(producto);
    }

    public boolean Delete(int id) {
        Categoria categoria = new Categoria(0, "");
        Producto producto = new Producto(id, "", 0, 0, categoria);
        return this.service.Delete(producto);
    }
    
    public List<Categoria> listaDeCategoria(){
    return this.service.listaDeCategoria();
    }
}
