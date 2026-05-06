
package Animales;

/*  Herencia: 
    Toma los atributos y metodos de su clase padre, al padre ser abstracto, no se pueden crear
    objetos de este(Animal) pero si de su hijo (perro)
*/
public class Perro extends Animal{
    
    public double decibelesLadrido;
    
    //Metodos
    
    //Constructor
    
    /*
        Polimorfismo(Sobrecarga): 
        El nombre de los metodos es el mismo, pero su firma (los parametros) cambia 
    */
    public Perro() {
    }
    
    public Perro(double decibelesLadrido) {
        this.decibelesLadrido = decibelesLadrido;
    }

    public Perro(String color, double peso, double tamanio, double decibelesLadrido) {
        super(color, peso, tamanio);
        this.decibelesLadrido = decibelesLadrido;
    }

    /*
        Polimorfismo (Sobreescritura):  
        Se encarga de implementar la logica del metodo abstracto que se especifico en la clase
        padre o en una interfaz
    
    */
    //@Override: Especifica que el metodos se esta sobrescribiendo
    
    @Override
    public void Desplazarse(int cantMetros) {
        System.out.println("El perro ha corrido " + cantMetros + " metros");
    }
    
    //Otros metodos propios de esta clase
    public boolean OlfatearMercanciaIlegal(String producto){
        System.out.println("El perro huele el producto");
        boolean esIlegal = true;
        return esIlegal;
    }
}
