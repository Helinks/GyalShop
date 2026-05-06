
package Controller;

import Model.Empleado;
import Service.EmpleadoService;

public class EmpleadoController {
    public EmpleadoService service;

    public EmpleadoController() {
        this.service = new EmpleadoService();
    }
    
    public boolean Create(Empleado empleado ){
        return this.service.Create(empleado);
    }
    
    public Empleado CalcularNomina(Empleado empleado){
        return this.service.CalcularNomina(empleado);
    }
    
    public double CalcularTotalNomina(){
        return this.service.CalcularTotalNomina();
    }

    public double CalcularPromedioNomina(){
        return this.service.CalcularPromedioNomina();
    }
    
    public int CantidadEmpleados(){
        return service.CantidadEmpleados();
    }
    
    public Empleado EmpleadoMayorSalario(){
        return service.CalcularMayorSalario();
    }
}
