
package Services;

import Models.Notas;

public class NotasService {
    
    public Notas CalcularNota(Notas nota){
        nota.promedio = (nota.notaUno + nota.notaDOs + nota.notaTres) / 3;
        nota.notaRestante = 100 - nota.promedio;
        return nota;
    }
    
    
}
