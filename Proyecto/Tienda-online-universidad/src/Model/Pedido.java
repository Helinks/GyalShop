/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Model;

import enums.PedidoEstado;
import java.util.List;

/**
 *
 * @author Dilan
 */
public class Pedido {
    private int id;
    private Usuario usuario;
    private List<PedidoItem> items;
    private PedidoEstado status;
}
