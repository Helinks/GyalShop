
package Services;

import Models.Cotizacion;

public class CotizacionService {
    
    public Cotizacion CalcularCotizacion(Cotizacion cotizacion){
        int precioTotal = (int) cotizacion.precioProducto*cotizacion.cantidad;
        double valorDescuento = precioTotal * (cotizacion.descuento/100.0);
        double valorIva = precioTotal * (cotizacion.iva/100.0);
        cotizacion.totalPagar = (int) (precioTotal - valorDescuento + valorIva);
        return cotizacion;
    }
    
}
