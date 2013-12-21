using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Virtual_Keyboard;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/**
 * \file Form1.cs
 */

/**
 * \namespace Projet_clavier_M1
 * Namespace les formulaires pour l'interface.
 * 
 */
namespace Projet_clavier_M1
{

    public partial class Form1 : Form
    {
        /**
         * Classe permetant d'instancer le formulaire de dessin
         */

        private Keyboard_Manager _Clavier;
        private BufferedGraphics _Buff_grafique;
        private string _Status_label_zoom, _Status_label_deplacement, _Status_Translation;
        public Point _Centre;

        /**
        * Le constructeur ne prend pas de parametres.
        * Il initialise le clavier virtuel, alloue le buffer graphique pour le double buffering
        *
        * @param none
        * @return none
        */
        public Form1()
        {
            InitializeComponent();
            _Clavier = new Keyboard_Manager(this);
            Creat_Graphique();

            this.panel1.MouseClick += new MouseEventHandler(this._Clavier.OnMouseClick);
            this.MouseWheel += new MouseEventHandler(this._Clavier.OnMouseWheel);
            this.panel1.MouseMove += new MouseEventHandler(this._Clavier.OnMouseMouve);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            _Status_label_zoom = this.Status_Zoom.Text + " ";
            _Status_label_deplacement = this.Status_Dep.Text + " ";
            _Status_Translation = this.Status_Trans.Text + " ";

        }

        /**
        *Fonction allouant le buffer graphique pour le double buffering et l'integrant dans le clavier
        *
        * @param none
        * @return none
        */

        private void Creat_Graphique()
        {
            BufferedGraphicsContext buf_context = BufferedGraphicsManager.Current;
            _Buff_grafique = buf_context.Allocate(CreateGraphics(), DisplayRectangle);
            using (Brush b = new SolidBrush(Form.DefaultBackColor))
            {
                _Buff_grafique.Graphics.FillRectangle(b, DisplayRectangle);
            }
            _Clavier.Set_Graphic(_Buff_grafique.Graphics);
        }

        /**
        * Ne fait rien.
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /**
        * Evement du menu pour quitter l'application
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
        * Affiche une boite de dialogue contenant le l'auteur du projet.
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fait part Vincent Lamouroux", "A Propos", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /**
        * Affiche une boite de selection de fichier pui charge le clavier en fonction du fichier xml.
        * Affiche une boite de dialogue en cas d'erreure durant le processus
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void chargerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFile = new OpenFileDialog();

            OpenFile.InitialDirectory = "";
            OpenFile.RestoreDirectory = true;

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Clavier.Load(OpenFile.FileName);
                }
                catch (Exception exp)
                {
                    Erreure(exp);
                }
                Update_Satus();
                Pannel_Paint();
            }
        }

        #region Event
        /**
        * Event qui met a jour les tailles des objects
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        protected override void OnSizeChanged(EventArgs e)
        {
            this.textBox1.Width = this.Width;
            this.panel1.Width = this.Width;
            this.panel1.Height = this.Height - this.statusStrip1.Height;
            try
            {
                Creat_Graphique();
            }
            catch { }
            _Centre = new Point(this.Width / 2, this.Height / 2);
            Pannel_Paint();
        }

        /**
        * Event qui declanche un deplacement normal
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void deplacementNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deplacementNormalToolStripMenuItem.Checked = true;
            this.deplacementInverseToolStripMenuItem.Checked = false;
            _Clavier.Set_Sens_Normal();
        }

        /**
        * Event qui declanche un deplacement inverse
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void deplacementInverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deplacementInverseToolStripMenuItem.Checked = true;
            this.deplacementNormalToolStripMenuItem.Checked = false;
            _Clavier.Set_Sens_Inverse();
        }

        /**
        * Event qui declanche un zoom statique
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void zoomStaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.zoomStaticToolStripMenuItem.Checked = true;
            this.zoomDinamiqueToolStripMenuItem.Checked = false;
            _Clavier.Set_Zoom_Static();
        }

        /**
        * Event qui declanche un zoom dynamique
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void zoomDinamiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.zoomStaticToolStripMenuItem.Checked = false;
            this.zoomDinamiqueToolStripMenuItem.Checked = true;
            _Clavier.Set_Zoom_Din();
        }

        /**
        * Event qui declanche l'affichage de l'aide
        * @param sender : object
        * @param e : EventArgs
        * @return none
        */
        private void editionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Help help = new Form_Help();
            help.Show();
        }
        #endregion Event

        /**
        * Fonction qui met a jour la barre de status
        * @param none
        * @return none
        */
        public void Update_Satus()
        {
            this.Status_Zoom.Text = _Status_label_zoom + _Clavier.Zoom;
            this.Status_Dep.Text = _Status_label_deplacement + _Clavier.Deplacement;
            this.Status_Trans.Text = _Status_Translation + _Clavier.Zoom_Validant;
        }

        /**
        * Fonction qui dessine la croix rouge de visée
        * @param none
        * @return none
        */

        public void Draw_Cross()
        {

            Pen color = new Pen(Color.Red);

            Point p1 = new Point(_Centre.X - 50, _Centre.Y);
            Point p2 = new Point(_Centre.X + 50, _Centre.Y);
            Point p3 = new Point(_Centre.X, _Centre.Y - 50);
            Point p4 = new Point(_Centre.X, _Centre.Y + 50);

            _Buff_grafique.Graphics.DrawLine(color, p1, p2);
            _Buff_grafique.Graphics.DrawLine(color, p3, p4);

        }
        /**
        * Fonction qui dessine le clavier
        * @param none
        * @return none
        */
        public void Pannel_Paint()
        {

            try
            {
                _Clavier.Draw();
                Draw_Cross();
                _Buff_grafique.Render(this.panel1.CreateGraphics());
            }
            catch (Exception ex)
            {
               
            }
        }

        /**
        * Getter de la textbox qui va recevoir le texte
        * @param none
        * @return Textbox
        */
        public TextBox Textbox
        {
            get { return this.textBox1; }
        }
        /**
        * Fonction generique pour afficher un message d'erreur.
        * @param e : Exception
        * @return none
        */
        private void Erreure(Exception e)
        {
            MessageBox.Show(e.Message, "Erreure type : " + e.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
