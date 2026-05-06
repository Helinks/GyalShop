package Animales;

//Clase abstracta: No se pueden crear objetos de este tipo de clase
public abstract class Animal {
    
    //Atributos
    public String color;
    private double peso;
    public double tamanio;
    
    
    //Metodos
    
    //Constructor
    
    /*
        Polimorfismo(Sobrecarga): 
        El nombre de los metodos es el mismo, pero su firma (los parametros) cambia 
    */
    public Animal(){}
    
    public Animal(String color, double peso, double tamanio){
        this.color = color;
        this.peso = peso;
        this.tamanio = tamanio;
    }
    
    public Animal(String color){
        this.tamanio = tamanio;
    }
    
    public Animal(double peso, double tamanio){
        this.peso = peso;
        this.tamanio = tamanio;
    }
    
    //Getters y Setters
    /*
        Encapsulamiento:
        Se utiliza las variables de acceso private para que los datos no sean accesibles
        desde otras partes del codigo        
    */

    public double getPeso() {
        return peso;
    }

    public void setPeso(double peso) {
        this.peso = peso;
    }
    
    // Otros metodos de tipo abstracto
    
    /*
        abstraccion (bajo nivel de detalle):
        Se especifica la firma del metodo, pero no su implementacion
    */
    
    public abstract void Desplazarse(int cantMetros);
    
    
    //otros metodos propios de la clase
    
    public void Alimentarse(String comida){
        System.out.println("EL animal esta comiendo " + comida);
    }
}
