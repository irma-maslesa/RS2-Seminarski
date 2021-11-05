
namespace Pelikula.WINUI
{
    partial class MdiFrmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.upravljanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoviKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZanroviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upravljanjeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // upravljanjeToolStripMenuItem
            // 
            this.upravljanjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.tipoviKorisnikaToolStripMenuItem,
            this.ZanroviToolStripMenuItem});
            this.upravljanjeToolStripMenuItem.Name = "upravljanjeToolStripMenuItem";
            this.upravljanjeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.upravljanjeToolStripMenuItem.Text = "Upravljanje";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // tipoviKorisnikaToolStripMenuItem
            // 
            this.tipoviKorisnikaToolStripMenuItem.Name = "tipoviKorisnikaToolStripMenuItem";
            this.tipoviKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoviKorisnikaToolStripMenuItem.Text = "Tipovi korisnika";
            this.tipoviKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.TipoviKorisnikaToolStripMenuItem_Click);
            // 
            // ZanroviToolStripMenuItem
            // 
            this.ZanroviToolStripMenuItem.Name = "ZanroviToolStripMenuItem";
            this.ZanroviToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ZanroviToolStripMenuItem.Text = "Žanrovi";
            this.ZanroviToolStripMenuItem.Click += new System.EventHandler(this.ZanroviToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MdiFrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MdiFrmAdmin";
            this.Text = "MdiFrmAdmin";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem upravljanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoviKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZanroviToolStripMenuItem;
    }
}



