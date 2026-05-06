
package Service;

import Model.Empleado;
import DB.EmpleadoDB;

public class EmpleadoService {
    
    public EmpleadoDB db;

    public EmpleadoService() {
        this.db = new EmpleadoDB();
    }
    
    public boolean Create (Empleado empleado){
        db.Create(empleado);
        return true;
    }

    public Empleado CalcularNomina(Empleado empleados){
        empleados.totalHorasExtra = empleados.horasExtra * empleados.valorHoraExtra;
        empleados.totalDevengado = empleados.salario + empleados.totalHorasExtra;
        empleados.totalDescuento = empleados.totalDevengado * 0.08;
        
        if(empleados.tipo == true){
            empleados.bono = (empleados.salario * 0.1);
        }else {
            empleados.bono = (empleados.salario * 0.05);
        }
        
        empleados.salarioNeto = (empleados.totalDevengado + empleados.bono) -  empleados.totalDescuento;
        
        return empleados;
    }
    
    public double CalcularTotalNomina(){
        double totalNomina = 0;

        for(Empleado e : db.ListaDeEmpleados()){
            totalNomina = totalNomina + e.salarioNeto;
        }

        return totalNomina;
    }
    
    public double CalcularPromedioNomina(){
        int cantidad = db.CantidadEmpleados();
        if(cantidad == 0) return 0;

        return CalcularTotalNomina() / cantidad;
    }
    
    public int CantidadEmpleados(){
        return db.CantidadEmpleados();
    }
    
    public Empleado CalcularMayorSalario(){
         if(db.CantidadEmpleados() == 0){
            return null;
        }

        Empleado empleadoMayorSalario = db.ListaDeEmpleados().get(0);
        for(Empleado e : db.ListaDeEmpleados()){
            if(e.salarioNeto > empleadoMayorSalario.salarioNeto){
                    empleadoMayorSalario = e;
            }
        }

        return empleadoMayorSalario;
    }
}
