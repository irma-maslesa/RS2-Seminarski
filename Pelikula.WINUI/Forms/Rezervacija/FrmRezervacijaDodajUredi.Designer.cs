
namespace Pelikula.WINUI.Forms.Rezervacija
{
    partial class FrmRezervacijaDodajUredi
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
            this.btnOcisti = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDodajKorisnika = new System.Windows.Forms.Button();
            this.btnProjekcijaInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTermin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKorisnik = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbProjekcija = new System.Windows.Forms.ComboBox();
            this.flpSjedista = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOcisti
            // 
            this.btnOcisti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcisti.Location = new System.Drawing.Point(336, 181);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 23);
            this.btnOcisti.TabIndex = 10;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpremi.Location = new System.Drawing.Point(417, 181);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 7;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.BtnSpremi_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDodajKorisnika);
            this.groupBox2.Controls.Add(this.btnProjekcijaInfo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbTermin);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbKorisnik);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbProjekcija);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 145);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacije";
            // 
            // btnDodajKorisnika
            // 
            this.btnDodajKorisnika.Location = new System.Drawing.Point(452, 99);
            this.btnDodajKorisnika.Name = "btnDodajKorisnika";
            this.btnDodajKorisnika.Size = new System.Drawing.Size(23, 23);
            this.btnDodajKorisnika.TabIndex = 29;
            this.btnDodajKorisnika.Text = "+";
            this.btnDodajKorisnika.UseVisualStyleBackColor = true;
            this.btnDodajKorisnika.Click += new System.EventHandler(this.BtnDodajKorisnika_Click);
            // 
            // btnProjekcijaInfo
            // 
            this.btnProjekcijaInfo.Location = new System.Drawing.Point(452, 26);
            this.btnProjekcijaInfo.Name = "btnProjekcijaInfo";
            this.btnProjekcijaInfo.Size = new System.Drawing.Size(23, 23);
            this.btnProjekcijaInfo.TabIndex = 28;
            this.btnProjekcijaInfo.Text = "i";
            this.btnProjekcijaInfo.UseVisualStyleBackColor = true;
            this.btnProjekcijaInfo.Click += new System.EventHandler(this.BtnProjekcijaInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Termin";
            // 
            // cbTermin
            // 
            this.cbTermin.FormattingEnabled = true;
            this.cbTermin.Location = new System.Drawing.Point(65, 65);
            this.cbTermin.Name = "cbTermin";
            this.cbTermin.Size = new System.Drawing.Size(410, 21);
            this.cbTermin.TabIndex = 26;
            this.cbTermin.SelectedValueChanged += new System.EventHandler(this.CbTermin_SelectedValueChanged);
            this.cbTermin.Validating += new System.ComponentModel.CancelEventHandler(this.CbTermin_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Korisnik";
            // 
            // cbKorisnik
            // 
            this.cbKorisnik.FormattingEnabled = true;
            this.cbKorisnik.Location = new System.Drawing.Point(65, 101);
            this.cbKorisnik.Name = "cbKorisnik";
            this.cbKorisnik.Size = new System.Drawing.Size(381, 21);
            this.cbKorisnik.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Projekcija";
            // 
            // cbProjekcija
            // 
            this.cbProjekcija.FormattingEnabled = true;
            this.cbProjekcija.Location = new System.Drawing.Point(65, 28);
            this.cbProjekcija.Name = "cbProjekcija";
            this.cbProjekcija.Size = new System.Drawing.Size(381, 21);
            this.cbProjekcija.TabIndex = 19;
            this.cbProjekcija.SelectedValueChanged += new System.EventHandler(this.CbProjekcija_SelectedValueChanged);
            this.cbProjekcija.Validating += new System.ComponentModel.CancelEventHandler(this.CbProjekcija_Validating);
            // 
            // flpSjedista
            // 
            this.flpSjedista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flpSjedista.AutoSize = true;
            this.flpSjedista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSjedista.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpSjedista.Location = new System.Drawing.Point(202, 164);
            this.flpSjedista.MaximumSize = new System.Drawing.Size(481, 0);
            this.flpSjedista.MinimumSize = new System.Drawing.Size(100, 5);
            this.flpSjedista.Name = "flpSjedista";
            this.flpSjedista.Size = new System.Drawing.Size(100, 5);
            this.flpSjedista.TabIndex = 13;
            // 
            // FrmRezervacijaDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(508, 216);
            this.Controls.Add(this.flpSjedista);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnSpremi);
            this.Name = "FrmRezervacijaDodajUredi";
            this.Text = "Dodaj korisnika";
            this.Load += new System.EventHandler(this.FrmRezervacijaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbProjekcija;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTermin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKorisnik;
        private System.Windows.Forms.Button btnProjekcijaInfo;
        private System.Windows.Forms.FlowLayoutPanel flpSjedista;
        private System.Windows.Forms.Button btnDodajKorisnika;
    }
}