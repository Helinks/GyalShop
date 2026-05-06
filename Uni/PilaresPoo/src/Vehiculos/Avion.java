package Vehiculos;

import Interfaces.IVolador;

/*  Implementacion de interfaz (Implements)
    Obliga a la clase a implementar los metodos abstractos que la interfaz declaro    
*/
public class Avion implements IVolador{
    
    //Atributos
    public String nombre;
    public int horasVuelo;
    
    //Metodos
    
    //Constructor
    public Avion(String nombre, int horasVuelo) {
        this.nombre = nombre;
        this.horasVuelo = horasVuelo;
    }
    
    //Sobreescritura de los metodos de la INTERFAZ
    @Override
    public void Aterrizar() {
        System.out.println("abre sistema de aterrizaje");
        System.out.println("Realiza una inclinacion de 45 grados");
        System.out.println("Se coloca avion en el suelo");
        System.out.println("frena");
    }

    @Override
    public void Despegar() {
        System.out.println("empieza a acelerar");
        System.out.println("Toma velocidad superior de 300km/h");
        System.out.println("hace una elevacion de 45 grados");
        System.out.println("Despega");
    }
    
}
