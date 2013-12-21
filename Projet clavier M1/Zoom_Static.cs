using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */
namespace Virtual_Keyboard
{
    /**
     * Classe represantant le zoom statique.
     * Herite de Zoom
     */
    class Zoom_Static : Zoom
    {
        /** 
         * le constructeur ne prend pas de parametre
         *@param none
         *@return none
         */
        public Zoom_Static() : base() { }

      /**
      * Fonction permetant d'incrementer le Zoom
      *@param none
      *@return none
      */
        public override void Increment()
        {
            base.Inc_Zoom();
        }
       /**
     * Fonction permetant de decrementer le Zoom
     *@param none
     *@return none
     */
        public override void Decrement()
        {
            base.Dec_Zoom();
        }
    }
}
