namespace Projet_clavier_M1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDeZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomStaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomDinamiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDeDéplacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deplacementNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deplacementInverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status_Zoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Trans = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Dep = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerToolStripMenuItem,
            this.typeDeZoomToolStripMenuItem,
            this.typeDeDéplacementToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fichierToolStripMenuItem.Text = "Clavier";
            // 
            // chargerToolStripMenuItem
            // 
            this.chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            this.chargerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.chargerToolStripMenuItem.Text = "Charger";
            this.chargerToolStripMenuItem.Click += new System.EventHandler(this.chargerToolStripMenuItem_Click);
            // 
            // typeDeZoomToolStripMenuItem
            // 
            this.typeDeZoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomStaticToolStripMenuItem,
            this.zoomDinamiqueToolStripMenuItem});
            this.typeDeZoomToolStripMenuItem.Name = "typeDeZoomToolStripMenuItem";
            this.typeDeZoomToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.typeDeZoomToolStripMenuItem.Text = "Type de zoom";
            // 
            // zoomStaticToolStripMenuItem
            // 
            this.zoomStaticToolStripMenuItem.Name = "zoomStaticToolStripMenuItem";
            this.zoomStaticToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.zoomStaticToolStripMenuItem.Text = "Zoom Static";
            this.zoomStaticToolStripMenuItem.Click += new System.EventHandler(this.zoomStaticToolStripMenuItem_Click);
            // 
            // zoomDinamiqueToolStripMenuItem
            // 
            this.zoomDinamiqueToolStripMenuItem.Checked = true;
            this.zoomDinamiqueToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomDinamiqueToolStripMenuItem.Name = "zoomDinamiqueToolStripMenuItem";
            this.zoomDinamiqueToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.zoomDinamiqueToolStripMenuItem.Text = "Zoom Dinamique";
            this.zoomDinamiqueToolStripMenuItem.Click += new System.EventHandler(this.zoomDinamiqueToolStripMenuItem_Click);
            // 
            // typeDeDéplacementToolStripMenuItem
            // 
            this.typeDeDéplacementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deplacementNormalToolStripMenuItem,
            this.deplacementInverseToolStripMenuItem});
            this.typeDeDéplacementToolStripMenuItem.Name = "typeDeDéplacementToolStripMenuItem";
            this.typeDeDéplacementToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.typeDeDéplacementToolStripMenuItem.Text = "Type de déplacement";
            // 
            // deplacementNormalToolStripMenuItem
            // 
            this.deplacementNormalToolStripMenuItem.Checked = true;
            this.deplacementNormalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deplacementNormalToolStripMenuItem.Name = "deplacementNormalToolStripMenuItem";
            this.deplacementNormalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deplacementNormalToolStripMenuItem.Text = "Deplacement Normal";
            this.deplacementNormalToolStripMenuItem.Click += new System.EventHandler(this.deplacementNormalToolStripMenuItem_Click);
            // 
            // deplacementInverseToolStripMenuItem
            // 
            this.deplacementInverseToolStripMenuItem.Name = "deplacementInverseToolStripMenuItem";
            this.deplacementInverseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deplacementInverseToolStripMenuItem.Text = "Deplacement Inverse";
            this.deplacementInverseToolStripMenuItem.Click += new System.EventHandler(this.deplacementInverseToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editionToolStripMenuItem.Text = "Aide";
            this.editionToolStripMenuItem.Click += new System.EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aProposToolStripMenuItem.Text = "A Propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 288);
            this.panel1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_Zoom,
            this.Status_Trans,
            this.Status_Dep});
            this.statusStrip1.Location = new System.Drawing.Point(0, 367);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1077, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status_Zoom
            // 
            this.Status_Zoom.Name = "Status_Zoom";
            this.Status_Zoom.Size = new System.Drawing.Size(45, 17);
            this.Status_Zoom.Text = "Zoom :";
            this.Status_Zoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status_Trans
            // 
            this.Status_Trans.Name = "Status_Trans";
            this.Status_Trans.Size = new System.Drawing.Size(148, 17);
            this.Status_Trans.Text = "Facteur de Zoom validant :";
            // 
            // Status_Dep
            // 
            this.Status_Dep.Name = "Status_Dep";
            this.Status_Dep.Size = new System.Drawing.Size(83, 17);
            this.Status_Dep.Text = "Deplacement :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Enabled = false;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(1077, 50);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 389);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Clavier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDeZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDeDéplacementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status_Zoom;
        private System.Windows.Forms.ToolStripStatusLabel Status_Dep;
        private System.Windows.Forms.ToolStripStatusLabel Status_Trans;
        private System.Windows.Forms.ToolStripMenuItem deplacementNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deplacementInverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomStaticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomDinamiqueToolStripMenuItem;
    }
}

