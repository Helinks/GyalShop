
package Controllers;

import Models.Notas;
import Services.NotasService;

public class NotasController {
    
    public NotasService notasService;
    
    public NotasController (){
        this.notasService = new NotasService();
    }
    
    public Notas CalcularNota(Notas nota){
        return this.notasService.CalcularNota(nota);
    }
    
}
