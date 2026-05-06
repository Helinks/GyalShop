/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controllers;

import Models.Cotizacion;
import Services.CotizacionService;

/**
 *
 * @author Dilan
 */
public class CotizacionController {
    public CotizacionService cotizacionService;

    public CotizacionController() {
        this.cotizacionService = new CotizacionService();
    }
    
    public Cotizacion CalcularCotizacion(Cotizacion cotizacion){
        return this.cotizacionService.CalcularCotizacion(cotizacion);
    }
    
    
}
