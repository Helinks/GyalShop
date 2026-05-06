
package Model;

public class Empleado {
    public int id;
    public String nombre;
    public double salario;
    public int horasExtra;
    public double valorHoraExtra;
    public boolean tipo;
    
    public double totalHorasExtra;
    public double totalDevengado;
    public double totalDescuento;
    public double bono;
    public double salarioNeto;
    

    public Empleado(int id, String nombre, double salario, int horasExtra, double valorHoraExtra, boolean tipo) {
        this.id = id;
        this.nombre = nombre;
        this.salario = salario;
        this.horasExtra = horasExtra;
        this.valorHoraExtra = valorHoraExtra;
        this.tipo = tipo;
    }
    
}
