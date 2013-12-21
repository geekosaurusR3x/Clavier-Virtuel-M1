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
     * Classe abstraite representant le Zoom
     */
    abstract class Zoom
    {
        protected float _Zoom_Value;
        protected float _Zoom_Valide = 1.0f;

        /** Le constructeur ne prend pas de parametres
         * @param none
         * @return null
         */
        public Zoom()
        {
            _Zoom_Value = 0.5f;
            _Zoom_Valide = 1.0f;
        }
        /**
         * Getter de la valeur de zoom
         *@param none
         *@return float
         */
        public float Zoom_Value
        {
            get { return _Zoom_Value; }
        }
        /**
         *Getter de la valeur de zoom validant
         *@param none
         *return float
         */
        public float Zoom_Valide
        {
            get { return _Zoom_Valide; }
        }

        /**
         * Fonction abstraite permetant de modifier le zoom avec un mousewell avant
         *@param none
         *@return none
         */
        public abstract void Increment();

        /**
     * Fonction abstraite permetant de modifier le zoom avec un mousewell arriere
     *@param none
     *@return none
     */
        public abstract void Decrement();

        /**
         * Fonction permetant d'increment la valeur de Zoom
         *@param none
         *@return none
         */
        protected void Inc_Zoom()
        {
            _Zoom_Value += 0.01f;
        }

        /**
     * Fonction permetant de decrementer la valeur de Zoom
     *@param none
     *@return none
     */
        protected void Dec_Zoom()
        {
            _Zoom_Value -= 0.01f;
        }
    }

}
