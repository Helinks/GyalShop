/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package View.Components;

import java.awt.Graphics;
import java.awt.Image;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JPanel;

/**
 *
 * @author Dilan
 */
public class JPanelImageLogo extends  JLabel{
    private int x, y;
    private final String path;

    public JPanelImageLogo(JPanel panel, String path) {
        this.path = path;
        this.x = panel.getWidth();
        this.y = panel.getHeight();
        this.setSize(x,y);
    }
    
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);

        ImageIcon icon = new ImageIcon(getClass().getResource(path));
        Image img = icon.getImage();

        int panelW = getWidth();
        int panelH = getHeight();

        int imgW = icon.getIconWidth();
        int imgH = icon.getIconHeight();

        double scale = Math.max(
            (double) panelW / imgW,
            (double) panelH / imgH
        );

        int newW = (int) (imgW * scale);
        int newH = (int) (imgH * scale);

        int x = (panelW - newW) / 2;
        int y = (panelH - newH) / 2;

        g.drawImage(img, x, y, newW, newH, this);
    }
}
