
package DB;

import Model.Empleado;
import java.util.ArrayList;

public class EmpleadoDB {
    public ArrayList<Empleado> empleado;

    public EmpleadoDB() {
        this.empleado = new ArrayList<>();
    }
    
    public boolean Create(Empleado empleado){
        if(this.empleado.size() == 3){
            return false;
        }
        this.empleado.add(empleado);
        return true;
    }
    
    
    public ArrayList<Empleado> ListaDeEmpleados(){
        return this.empleado;
    }

    public int CantidadEmpleados(){
        return this.empleado.size();
    }
    
    
}
