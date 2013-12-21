using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

/**
 * \file Utilitaire.cs
 */

/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */

namespace Virtual_Keyboard
{
    /**
     * Classe regroupant des fonctions utilitaires pour le clavier virtuel.
     **/
    class Utilitaire
    {
        /**
        * Fonction publique statique permetant de calculer la distance d'un point a une droite.
        * a b et c etant les coeficiants de l'equation carthesienne de la droite et p le point.
        * @param a : double
        * @param b : double
        * @param c : double
        * @param p : point
        * @return double distance du point a la droite
        */
        public static double Dist(double a, double b, double c, Point p)
        {
            return ((a * p.X) + (b * p.Y) + c) / Math.Sqrt((a * a) + (b * b));
        }

        /**
        * Fonction publique statique permetant de calculer la couleur inverse en ARGB.
        * @param col : Color
        * @return Color couleur inverse
        */
        public static Color InColor(Color col)
        {
            return Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B);
        }
    }
}
