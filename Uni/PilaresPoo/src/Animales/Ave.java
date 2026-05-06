package Animales;

import Interfaces.IVolador;

/*  Herencia (extends): 
    Toma los atributos y metodos de su clase padre, al padre ser abstracto, no se pueden crear
    objetos de este(Animal) pero si de su hijo (ave)
*/
/*  Implementacion de interfaz (Implements)
    Obliga a la clase a implementar los metodos abstractos que la interfaz declaro    
*/
public class Ave extends Animal implements IVolador{
    //Atributos
    public String materialPico;
    
    //Metodos
    
    //Constructor
    
    /*
        Polimorfismo(Sobrecarga): 
        El nombre de los metodos es el mismo, pero su firma (los parametros) cambia 
    */
    public Ave() {
    }
    
    public Ave(String materialPico) {
        this.materialPico = materialPico;
    }

    public Ave(String color, double peso, double tamanio, String materialPico) {
        super(color, peso, tamanio);
        this.materialPico = materialPico;
    }
    
    /*
        Polimorfismo (Sobreescritura):  
        Se encarga de implementar la logica del metodo abstracto que se especifico en la clase
        padre o en una interfaz
    
    */
    //@Override: Especifica que el metodos se esta sobrescribiendo
    
    @Override
    public void Desplazarse(int cantMetros) {
        System.out.println("El ave ha volado por " + cantMetros + " metros");
    }
    
    
    //Otros metodos propios de esta clase
    public void Picotear(){
        System.out.println("El ave ha abierto un boquete en el arbol.");
    }

    
    //Sobreescritura de los metodos de la INTERFAZ
    @Override
    public void Aterrizar() {
        System.out.println("El ave baja sus alas a 45 grados");
        System.out.println("Pone sus patas en el piso");
        System.out.println("Esconde las alas");
        System.out.println("Frena");
    }

    @Override
    public void Despegar() {
        System.out.println("mueve sus alas y se levanta del piso desde su propio punto");
    }
    
}
