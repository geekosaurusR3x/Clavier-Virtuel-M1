using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

/**
 * \file Clavier_graphics.cs
 */

/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */
namespace Virtual_Keyboard
{
    /**
    *  Classe represantant la partie graphique du clavier.
    *  Elle ne contiends que le buffer de dessin
    */
    class Keyboard_Graphics
    {

        private Graphics _Buffer_graf;
        /**
         * Constructeur du graphic manager
         * @param g : Graphics Le graphics sur lequel a dessiner
         * @return none
         */
        public Keyboard_Graphics(Graphics g)
        {
            _Buffer_graf = g;
        }

        /**
         * Getter/Setter du Graphics de dessin
         * @param Graphics
         * @return Graphics
         */
        public Graphics graf
        {
            get { return _Buffer_graf; }
            set { _Buffer_graf = value; }
        }

        /**
         * Fonction permetant de netoyer le graphics
         * @param none
         * @return none
         */

        public void Clear()
        {
            _Buffer_graf.Clear(Form.DefaultBackColor);
        }
    }

}
