package Models;

public class Prestamo {
    public double monto;
    public int interes;
    public int cantCuotas;
    public double valorTotal;
    public double valorCuota;
    
    public Prestamo(double monto, int interes, 
            int cantCuotas){
        this.monto = monto;
        this.interes = interes;
        this.cantCuotas = cantCuotas;
    }
}
