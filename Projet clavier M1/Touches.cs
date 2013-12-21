using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Virtual_Keyboard
{
    /**Classe represantant une touche virtuelle dans le clavier */
    class Touche
    {
        #region datas
        protected string _Lettre /*!< string _Lettre contien le texte de la touche */;
        protected string _Label/*!< string _Label contien le texte a afficher */;
        protected Point _Position /*!< Point _Position contien les coordonnees de la touche */;
        protected int _Largeur /*!< int _Largeur definit la largeur en px de la touche */;
        protected int _Largeur_origin;
        protected Point[] _TabPoint;
        protected Color _Color;
        protected Color _Origin_Color;
        #endregion

        #region constructeur

        /**
        * Constructeur par default :
        * @param lettre : string (le charactere de la touche "a z e r t y")
         * @param label : string (le charactere a afficher touche "a z e r t y")
        * @param p : Point (Position centrale de la lettre)
         * @param largeur : int (Largeur de la touche)
        * @return none
        */
        public Touche(string lettre,string label, Point p, int largeur)
        {
            _Lettre = lettre;
            _Label = label;
            _Position = p;
            _Largeur = largeur;
            _TabPoint = new Point[7];
            set_position(_Position);
            _Origin_Color = _Color = Color.WhiteSmoke;

        }
        #endregion

        #region get/set
        public string Lettre
        {
            get { return _Lettre; }
        }
        public int Largeur
        {
            set { _Largeur = value; }
        }
        #endregion

        #region methodes

        /**
         * fonction publique qui permet de calculer les points de la touches en fonction d'un point passé en parametre
         * @param Point : p
         *@return none
         */
        public void set_position(Point p)
        {
            _Position = p;
            _TabPoint[0] = new Point(p.X - _Largeur, p.Y - (_Largeur / 2));
            _TabPoint[1] = new Point(p.X, p.Y - _Largeur);
            _TabPoint[2] = new Point(p.X + _Largeur, p.Y - (_Largeur / 2));
            _TabPoint[3] = new Point(p.X + _Largeur, p.Y + (_Largeur / 2));
            _TabPoint[4] = new Point(p.X, p.Y + _Largeur);
            _TabPoint[5] = new Point(p.X - _Largeur, p.Y + (_Largeur / 2));
            _TabPoint[6] = new Point(p.X - _Largeur, p.Y - (_Largeur / 2));
        }
        /**
        * Fonction publique demandant a la touche de se dessiner.
        * @param graf : Graphics sur lequel dessiner
        * @return none
        */
        public void Dessin(Graphics graf)
        {
            graf.FillPolygon(new SolidBrush(_Color), _TabPoint);
            graf.DrawLines(new Pen(Color.Black), _TabPoint);
            int taille = 20;
            Font font = new Font("Verdana", taille);
            Size textSize = TextRenderer.MeasureText(_Label, font);
            while (textSize.Width > _Largeur)
            {
                taille--;
                font = new Font("Verdana", taille);
                textSize = TextRenderer.MeasureText(_Label, font);
            }
            graf.DrawString(_Label, font, new SolidBrush(Utilitaire.InColor(_Color)), new Point(_Position.X - textSize.Width / 2, _Position.Y - textSize.Height/2));
        }

        /**
        * Fonction publique demandant a la touche si une position est en elle.
        * @param Point : position du curseur
        * @return String : Lettre de la touche ou null
        */
        public bool Is_in(Point pos)
        {
            double a, b, c, dpos,dori;
            for (int i = 0; i <= 5; i++)
            {
                a = _TabPoint[i + 1].Y - _TabPoint[i].Y;
                b = _TabPoint[i].X - _TabPoint[i + 1].X;
                c = (_TabPoint[i + 1].X * _TabPoint[i].Y) - (_TabPoint[i].X * _TabPoint[i + 1].Y);
                dori = Utilitaire.Dist(a, b, c, _Position);
                dpos = Utilitaire.Dist(a, b, c, pos);
                if ((dori > 0 & dpos > 0) ^ (dori < 0 & dpos < 0))
                {}
                else
                {
                    return false;
                }
                 
            }

            return true;
        }

        public void Inverse_Color()
        {
            _Color = Utilitaire.InColor(_Color);
        }

        public void Color_Back_To_Origin()
        {
            _Color = _Origin_Color;
        }

        public virtual void Valide(System.Windows.Forms.TextBox textbox)
        {
            textbox.AppendText(_Lettre);
        }
        #endregion

    }
}