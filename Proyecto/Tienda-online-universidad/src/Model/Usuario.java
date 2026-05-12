/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Model;

import enums.Role;

/**
 *
 * @author Dilan
 */
public class Usuario {
    private int id_usuario;
    private String nombre;
    private String email;
    private String password;
    private Role role;

    public Usuario(int id, String nombre, String email, String password, Role role) {
        this.id_usuario = id;
        this.nombre = nombre;
        this.email = email;
        this.password = password;
        this.role = role;
    }

    public int getId_usuario() {
        return id_usuario;
    }

    public String getNombre() {
        return nombre;
    }

    public String getEmail() {
        return email;
    }

    public String getPassword() {
        return password;
    }

    public Role getRole() {
        return role;
    }

    
    
    

}
