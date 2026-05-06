
package Models;


public class Cotizacion {
    public String producto;
    public double precioProducto;
    public int cantidad;
    public int descuento;
    public int iva;
    public double totalPagar;

    public Cotizacion(String producto, double precioProducto, int cantidad, int descuento, int iva) {
        this.producto = producto;
        this.precioProducto = precioProducto;
        this.cantidad = cantidad;
        this.descuento = descuento;
        this.iva = iva;
    }
            
}
