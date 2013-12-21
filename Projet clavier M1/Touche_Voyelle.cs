using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */

namespace Virtual_Keyboard
{
    /**
* Classe represant une touche voyelle
*/
    class Touche_Voyelle : Touche
    {
        /**
   * Constructeur par default :
   * @param lettre : string (le charactere de la touche "a z e r t y")
    * @param label : string (le charactere a afficher touche "a z e r t y")
   * @param p : Point (Position centrale de la lettre)
    * @param largeur : int (Largeur de la touche)
   * @return none
   */
        public Touche_Voyelle(string lettre, string lab,Point p, int largeur)
            : base(lettre, lab ,p, largeur)
        {
            base._Origin_Color = base._Color = Color.White;
        }

    }   
}
