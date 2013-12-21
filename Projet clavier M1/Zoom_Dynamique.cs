using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */
namespace Virtual_Keyboard
{
    /**
     * Classe reprensant le zoom dynamique. Contiends un timer pour le modifier par interval de temps
     * Herite de Zoom
     */
    class Zoom_Dynamique : Zoom 
    {
        Timer _Timer;
        int _Base_Tick = 500;
        Keyboard_Manager _Keyboard;

        /**
         * Le constructeur prend comme parametre le gestionaire clavier pour pouvoir demander une mise a jour de du formulaire a chaque interval de mofidication du clavier
         *@param Keyboard_Manager : key
         *@return none
         */
        public Zoom_Dynamique(Keyboard_Manager key) : base ()
        {
            _Keyboard = key;
            _Timer = new Timer(_Base_Tick);
            _Timer.Elapsed += new ElapsedEventHandler(Tick);
            _Timer.Enabled = false;
        }

        /**
         * Calback du timer. Il incremente le zoom et demande une mise a jour du formulaire
         *@param object : sender
         *@param EventArgs : e
         *@return none
         */
        private void Tick(object sender, EventArgs e)
        {
            base.Inc_Zoom();
            _Keyboard.Update_Form();
        }

        /**
         * Fonction Demarant le timer OU diminuant l'interval de Tick
         *@param none
         *@return none
         */
        public override void Increment()
        {
            if (_Timer.Enabled)
            {
                if (_Timer.Interval > 50)
                {
                    _Timer.Interval -= 50;
                }
            }
            else
            {
                _Timer.Start();
                _Timer.Enabled = true;
            }
        }

        /**
         * Fonction augmentant l'interval de Tick OU arretant le timer
         *@param none
         *@return none
         */
        public override void Decrement()
        {
            if (_Timer.Enabled)
            {
                if (_Timer.Interval < 2000)
                {
                    _Timer.Interval += 50;
                }
                else
                {
                    _Timer.Stop();
                    _Timer.Interval = _Base_Tick;
                    _Timer.Enabled = false;
                }
            }
            else
            {
                base.Dec_Zoom();
            }
        }
    }
}
