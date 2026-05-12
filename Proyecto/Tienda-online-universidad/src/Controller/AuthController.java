package controller;

import Model.Usuario;
import service.UsuarioService;
import enums.Role;

public class AuthController {

    private UsuarioService service = new UsuarioService();

    public boolean registrar(String nombre, String email, String password) {

        Usuario usuario = new Usuario(0, nombre, email, password, Role.CLIENTE);

        return service.registrar(usuario);
    }

    public Usuario login(String email, String password) {
        return service.login(email, password);
    }
}