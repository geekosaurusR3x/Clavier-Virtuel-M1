using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

/**
 * \file Clavier.cs
 */

/**
 * \namespace Virtual_Keyboard
 * Namespace regroupant les elements permetant la gestion d'un clavier virtuel.
 * 
 */

namespace Virtual_Keyboard
{
    /**
    *  Classe represantant le clavier virtuelle.
    *  Elle contiends le nombre de touche ainsi que la liste des touches 
    */
    class Keyboard
    {

        #region data
        private int _Nb_touches; /*!< int _Nb_touches . */
        private int _Nb_lignes;
        private int _Nb_colones;
        private List<Touche> _Touches; /*!< List Touche _Touches . */
        private int _Largeur_touche, _Largeur_origin;
        private Point _Pos;
        private Point _Pos_Origin;
        #endregion

        #region constructeur
        /**
       * Le constructeur ne prend pas de parametres.
       * Il initialise le nombre de touche a 0 et la liste des touches.
       * @param none
       * @return
       */
        public Keyboard()
        {
            _Touches = new List<Touche>();
            _Nb_touches = 0;
            _Largeur_origin = _Largeur_touche = 50;
            _Pos_Origin = _Pos = new Point(50, 50);
        }
        #endregion

        #region get/set
        /**
         * Getter /Setter pour le nombre de touche du clavier
         */
        public int Nb_touches
        {
            get { return _Nb_touches; }
            set { _Nb_touches = value; }
        }
        public int Largeur_Touche
        {
            get { return _Largeur_touche; }
            set { _Largeur_touche = value; }
        }

        public int Largeur_Origin
        {
            get { return _Largeur_origin; }
        }

        public Point Pos
        {
            get { return _Pos; }
            set { _Pos = value; }
        }

        public Point Pos_Origin
        {
            get { return _Pos_Origin; }
            set { _Pos_Origin = value; }
        }
        #endregion

        #region methodes
        /**
         * Fonction public qui charge le clavier a partir du fichier xml passé en parametre
         * @param nom_du_fichier : Chaine de caractere contenant le nom du fichier
         * @return none
         * @exception Leve une exception en cas de probleme sur la lecture du fichier ou le traitement du code xml
         * 
         */
        public void Charger_fichier(string nom_du_fichier)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(nom_du_fichier);
            }
            catch (Exception e)
            {
                throw e;
            }

            Touche temp;
            try
            {
                XmlAttributeCollection info;
                XmlNode nb_ligne = xml.SelectSingleNode("/clavier/infos/nblignes");
                info = nb_ligne.Attributes;
                _Nb_lignes = int.Parse(info.Item(0).InnerText);
                XmlNode nb_colone = xml.SelectSingleNode("/clavier/infos/nbcolones");
                info = nb_colone.Attributes;
                _Nb_colones = int.Parse(info.Item(0).InnerText);
            }
            catch (Exception e)
            {
                throw e;
            }
            XmlNodeList liste_noeud = xml.SelectNodes("/clavier/listetouches/touche");
            try
            {
                foreach (XmlNode n in liste_noeud)
                {
                    Point P = new Point(0, 0);
                    XmlAttributeCollection info_touche = n.Attributes;
                    string S = info_touche.Item(0).InnerText;
                    string L = info_touche.Item(1).InnerText;
                    string T = info_touche.Item(2).InnerText;
                    switch (T)
                    {
                        case "v":
                            temp = new Touche_Voyelle(S,L, P, _Largeur_touche);
                            break;
                        case "e":
                             temp = new Touche_Enter(S,L, P, _Largeur_touche);
                             break;
                        case "b":
                             temp = new Touche_Backspace(S,L, P, _Largeur_touche);
                             break;
                        default:
                            temp = new Touche(S,L, P, _Largeur_touche);
                            break;

                    }
                    _Touches.Add(temp);
                    _Nb_touches++;
                }
                Mise_a_jour_Clavier();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /** fonction qui met a jour la position des touches en fonctions de la position du clavier
         * @param none
         * @return none
         */
        public void Mise_a_jour_Clavier()
        {
            Point temp = _Pos;
            int i = 0;
            int decalage = _Largeur_touche;
            foreach (Touche t in _Touches)
            {
                i++;
                t.Largeur = _Largeur_touche;
                t.set_position(temp);
                if (i < _Nb_colones)
                {
                    temp.X = temp.X + 2*_Largeur_touche + 1;
                }
                else
                {
                    temp.X = _Pos.X;
                    if (decalage > 0)
                    {
                          temp.X += decalage;
                    }
                    temp.Y = temp.Y + 3*_Largeur_touche/2;
                    decalage = -1*decalage;
                    i = 0;
                }
                

            }
        }
        /**
        * Fonction publique demandant au clavier de se dessiner.
        * @param graf : Graphics sur lequel dessiner
        * @return none
        */
        public void Dessin(Graphics graf)
        {
            foreach (Touche t in _Touches)
            {
                t.Dessin(graf);
            }
        }
        #endregion

        /**
        * Fonction publique verifiant si un point est present dans une des touches du clavier.
        * @param p : Point a verifier
        * @return Touche contenant le point sinon null
        */
        public Touche Valide(Point p)
        {
            foreach (Touche t in _Touches)
            {
                t.Color_Back_To_Origin();
                if (t.Is_in(p))
                {
                    t.Inverse_Color();
                    return t;
                }
            }
            return null;
        }
    }
}