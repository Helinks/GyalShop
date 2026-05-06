
package Models;

public class Notas {
    public int notaUno;
    public int notaDOs;
    public int notaTres;
    public int promedio;
    public boolean aprobado;
    public int notaRestante;

    public Notas(int notaUno, int notaDOs, int notaTres, int promedio, boolean aprobado, int notaRestante) {
        this.notaUno = notaUno;
        this.notaDOs = notaDOs;
        this.notaTres = notaTres;
        this.promedio = promedio;
        this.aprobado = aprobado;
        this.notaRestante = notaRestante;
    }

    public Notas(int notaUno, int notaDOs, int notaTres) {
        this.notaUno = notaUno;
        this.notaDOs = notaDOs;
        this.notaTres = notaTres;
    }
    
    
    
    
    
}
