package Services;

import Models.Prestamo;

public class PrestamoService {
    
    public Prestamo Calcular(Prestamo prestamo){
        prestamo.valorTotal = prestamo.monto + (prestamo.monto * (prestamo.interes/100));
        prestamo.valorCuota = prestamo.valorTotal / prestamo.cantCuotas;
        return prestamo;
    }
}
