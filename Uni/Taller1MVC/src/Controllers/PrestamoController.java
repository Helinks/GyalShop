
package Controllers;

import Models.Prestamo;
import Services.PrestamoService;

public class PrestamoController {
    
    public PrestamoService service;
    
    public PrestamoController(){
        this.service = new PrestamoService();
    }
    
    public Prestamo Calcular(Prestamo prestamo){
        return this.service.Calcular(prestamo);
    }
}
