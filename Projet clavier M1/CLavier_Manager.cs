using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

/**
 * \file Clavier_Manager.cs
 */

/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */

namespace Virtual_Keyboard
{
    /**
     * Classe permetant de gerer le clavier
    */
    class Keyboard_Manager
    {
        const int ZOOM_VALIDATE = 1;
        Keyboard _Clavier;
        Keyboard_Graphics _Graphics;
        Zoom _Zoom;
        Boolean _Deplacement;
        int _Sens_Deplacement;
        int _Mouse_X, _Mouse_Y;
        float _Deplacement_X, _Deplacement_Y, _Deplacement_X_Old, _Deplacement_Y_Old;
        Projet_clavier_M1.Form1 _Formulaire;

        /**
         * Constructeur qui initialise un Keyboard et un keyboard_graphics. Il deffinit aussi un zoom dinamique de base et un sens normal de deplacement.
         * @param f : Formulaire qui va interagir avec le clavier
         * @param g : Graphics sur lequel dessiner
         * @return none
         */
        public Keyboard_Manager(Projet_clavier_M1.Form1 f, Graphics g = null)
        {
            _Formulaire = f;
            Set_Zoom_Din();
            Set_Sens_Normal();
            _Clavier = new Keyboard();
            _Graphics = new Keyboard_Graphics(g);
            _Deplacement = false;
            _Mouse_X = 0;
            _Mouse_Y = 0;

        }

        /**
         * Fontion publique demandant au clavier de charger un fichier passé en parametre
         * @param p : String /url du fichier a charger
         * @return none
         */

        public void Load(string p)
        {
            _Clavier.Largeur_Touche = (int)(_Clavier.Largeur_Origin * _Zoom.Zoom_Value);
            _Clavier.Charger_fichier(p);
        }
        
        /**
         * Fonction publique demandant au clavier de ce dessiner
         * @param none
         * @return none
         */

        public void Draw()
        {
            _Graphics.Clear();
            _Clavier.Dessin(_Graphics.graf);
        }

        /**
        * Getter de la valeur du zoom
        * @param none
        * @return float
        */
        public float Zoom
        {
            get {return _Zoom.Zoom_Value; }
        }

        /**
        * Getter de la valeur de zoom validant
        * @param none
        * @return float
        */
        public float Zoom_Validant
        {
            get { return _Zoom.Zoom_Valide; }
        }

        /**
        * Getter de l'etat du deplacement
        * @param none
        * @return boolean
        */
        public Boolean Deplacement
        {
            get { return _Deplacement; }
        }
        /**
        * Setter du graphique de dessin pour le clavier
        * @param Graphics
        * @return none
        */
        public void Set_Graphic(Graphics g)
        {
            _Graphics.graf = g;
        }

        /**
        * Fonction publique permetant de definit un deplacement normal
        * @param none
        * @return none
        */
        public void Set_Sens_Normal()
        {
            _Sens_Deplacement = -1;
        }
        /**
        * Fonction publique permetant de definit un deplacement inverse
        * @param none
        * @return none
        */
        public void Set_Sens_Inverse()
        {
            _Sens_Deplacement = 1;
        }

        /**
        * Fonction publique permetant d'instancier un Zoom Static
        * @param none
        * @return none
        */
        public void Set_Zoom_Static()
        {
            _Zoom = new Zoom_Static();
        }
        /**
        * Fonction publique permetant d'instancier un Zoom dynamique
        * @param none
        * @return none
        */
        public void Set_Zoom_Din()
        {
            _Zoom = new Zoom_Dynamique(this);
        
        }

        /**
        * Fonction publique permetant de metre a jour le formulaire
        * @param none
        * @return none
        */
        public void Update_Form()
        {
            _Clavier.Largeur_Touche = (int)(_Clavier.Largeur_Origin * _Zoom.Zoom_Value);
            _Clavier.Mise_a_jour_Clavier();
            _Formulaire.Update_Satus();
            _Formulaire.Pannel_Paint();
        }

        /**
        * Callback de l'evenement OnMouseWheel de la sourie
        * Appel les methodes de modification du zoom instancié. Demande une mise a jour du formulaire apres ca.
        * @param object sender
        * @param MouseEventArgs e
        * @return none
        */
        public void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _Zoom.Increment();
            }
            else if (e.Delta < 0)
            {
                _Zoom.Decrement();
            }
            Update_Form();
        }

        /**
        * Callback de l'evenement OnMouseClick de la sourie
        * Active le deplacement de la sourie et stoque la position du curseur Ou valide la touche et appel un mise a jour du formulaire.
        * @param object sender
        * @param MouseEventArgs e
        * @return none
        */
        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (_Deplacement & _Zoom.Zoom_Value >= _Zoom.Zoom_Valide)
            {
                Touche t = _Clavier.Valide(Point_a_Valider());
                if (t != null)
                {
                    t.Valide(_Formulaire.Textbox);
                }
            }

            _Deplacement = !_Deplacement;
            _Clavier.Pos_Origin = _Clavier.Pos;
            _Mouse_X = e.X;
            _Mouse_Y = e.Y;
            _Formulaire.Update_Satus();
        }
        /**
        * Callback de l'evenement OnMouseMouve de la sourie
        * Calcul le deplacement de la sourie et demande un test de validation de la touche et une mise a jour du formulaire apres ca.
        * @param object sender
        * @param MouseEventArgs e
        * @return none
        */
        public void OnMouseMouve(object sender, MouseEventArgs e)
        {
            _Deplacement_X = (int)((_Mouse_X - e.Location.X) * _Sens_Deplacement);
            _Deplacement_Y = (int)((_Mouse_Y - e.Location.Y) * _Sens_Deplacement);
            if (_Deplacement)
            {
                _Clavier.Pos = new Point((int)(_Clavier.Pos_Origin.X + _Deplacement_X), (int)(_Clavier.Pos_Origin.Y + _Deplacement_Y));
                _Clavier.Valide(Point_a_Valider());
                Update_Form();
            }
        }
        /**
        * Fonction qui calcul le point a valider represantant le centre de la croix
        * @param none
        * @return Point
        */
        private Point Point_a_Valider()
        {
            return _Formulaire._Centre;
        }
    }
}
