
namespace Pelikula.WINUI.Forms.Prodaja
{
    partial class FrmProdajaDodajUredi
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
            this.txtCijenaUkupno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbInformacije = new System.Windows.Forms.GroupBox();
            this.btnDodajKorisnika = new System.Windows.Forms.Button();
            this.btnProjekcijaInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTermin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKorisnik = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbProjekcija = new System.Windows.Forms.ComboBox();
            this.gbRezervacija = new System.Windows.Forms.GroupBox();
            this.cbRezervacija = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tip = new System.Windows.Forms.Label();
            this.cbTipProdaje = new System.Windows.Forms.ComboBox();
            this.txtCijenaProjekcija = new System.Windows.Forms.TextBox();
            this.lblCijenaProjekcija = new System.Windows.Forms.Label();
            this.btnOdaberiSjedista = new System.Windows.Forms.Button();
            this.gbArtikli = new System.Windows.Forms.GroupBox();
            this.txtCijenaArtikli = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvArtikli = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Izaberi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.gbInformacije.SuspendLayout();
            this.gbRezervacija.SuspendLayout();
            this.gbArtikli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtikli)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOcisti
            // 
            this.btnOcisti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcisti.Location = new System.Drawing.Point(796, 344);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 23);
            this.btnOcisti.TabIndex = 10;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpremi.Location = new System.Drawing.Point(877, 344);
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
            // txtCijenaUkupno
            // 
            this.txtCijenaUkupno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCijenaUkupno.Location = new System.Drawing.Point(755, 309);
            this.txtCijenaUkupno.Margin = new System.Windows.Forms.Padding(2);
            this.txtCijenaUkupno.Name = "txtCijenaUkupno";
            this.txtCijenaUkupno.ReadOnly = true;
            this.txtCijenaUkupno.Size = new System.Drawing.Size(197, 20);
            this.txtCijenaUkupno.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(658, 312);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "UKUPNO (KM):";
            // 
            // gbInformacije
            // 
            this.gbInformacije.Controls.Add(this.btnDodajKorisnika);
            this.gbInformacije.Controls.Add(this.btnProjekcijaInfo);
            this.gbInformacije.Controls.Add(this.label3);
            this.gbInformacije.Controls.Add(this.cbTermin);
            this.gbInformacije.Controls.Add(this.label1);
            this.gbInformacije.Controls.Add(this.cbKorisnik);
            this.gbInformacije.Controls.Add(this.label8);
            this.gbInformacije.Controls.Add(this.cbProjekcija);
            this.gbInformacije.Location = new System.Drawing.Point(13, 41);
            this.gbInformacije.Name = "gbInformacije";
            this.gbInformacije.Size = new System.Drawing.Size(463, 145);
            this.gbInformacije.TabIndex = 78;
            this.gbInformacije.TabStop = false;
            this.gbInformacije.Text = "Informacije";
            // 
            // btnDodajKorisnika
            // 
            this.btnDodajKorisnika.Location = new System.Drawing.Point(434, 99);
            this.btnDodajKorisnika.Name = "btnDodajKorisnika";
            this.btnDodajKorisnika.Size = new System.Drawing.Size(23, 23);
            this.btnDodajKorisnika.TabIndex = 29;
            this.btnDodajKorisnika.Text = "+";
            this.btnDodajKorisnika.UseVisualStyleBackColor = true;
            this.btnDodajKorisnika.Click += new System.EventHandler(this.BtnDodajKorisnika_Click);
            // 
            // btnProjekcijaInfo
            // 
            this.btnProjekcijaInfo.Location = new System.Drawing.Point(434, 26);
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
            this.label3.Location = new System.Drawing.Point(30, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Termin";
            // 
            // cbTermin
            // 
            this.cbTermin.FormattingEnabled = true;
            this.cbTermin.Location = new System.Drawing.Point(75, 65);
            this.cbTermin.Name = "cbTermin";
            this.cbTermin.Size = new System.Drawing.Size(382, 21);
            this.cbTermin.TabIndex = 26;
            this.cbTermin.SelectedValueChanged += new System.EventHandler(this.CbTermin_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Korisnik";
            // 
            // cbKorisnik
            // 
            this.cbKorisnik.FormattingEnabled = true;
            this.cbKorisnik.Location = new System.Drawing.Point(75, 101);
            this.cbKorisnik.Name = "cbKorisnik";
            this.cbKorisnik.Size = new System.Drawing.Size(353, 21);
            this.cbKorisnik.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Projekcija";
            // 
            // cbProjekcija
            // 
            this.cbProjekcija.FormattingEnabled = true;
            this.cbProjekcija.Location = new System.Drawing.Point(75, 28);
            this.cbProjekcija.Name = "cbProjekcija";
            this.cbProjekcija.Size = new System.Drawing.Size(353, 21);
            this.cbProjekcija.TabIndex = 19;
            this.cbProjekcija.SelectedValueChanged += new System.EventHandler(this.CbProjekcija_SelectedValueChanged);
            // 
            // gbRezervacija
            // 
            this.gbRezervacija.Controls.Add(this.cbRezervacija);
            this.gbRezervacija.Controls.Add(this.label2);
            this.gbRezervacija.Location = new System.Drawing.Point(13, 40);
            this.gbRezervacija.Name = "gbRezervacija";
            this.gbRezervacija.Size = new System.Drawing.Size(463, 60);
            this.gbRezervacija.TabIndex = 78;
            this.gbRezervacija.TabStop = false;
            this.gbRezervacija.Text = "Informacije";
            // 
            // cbRezervacija
            // 
            this.cbRezervacija.FormattingEnabled = true;
            this.cbRezervacija.Location = new System.Drawing.Point(76, 28);
            this.cbRezervacija.Name = "cbRezervacija";
            this.cbRezervacija.Size = new System.Drawing.Size(382, 21);
            this.cbRezervacija.TabIndex = 30;
            this.cbRezervacija.SelectedValueChanged += new System.EventHandler(this.CbRezervacija_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Rezervacija";
            // 
            // Tip
            // 
            this.Tip.AutoSize = true;
            this.Tip.Location = new System.Drawing.Point(13, 16);
            this.Tip.Name = "Tip";
            this.Tip.Size = new System.Drawing.Size(60, 13);
            this.Tip.TabIndex = 83;
            this.Tip.Text = "Tip prodaje";
            // 
            // cbTipProdaje
            // 
            this.cbTipProdaje.FormattingEnabled = true;
            this.cbTipProdaje.Location = new System.Drawing.Point(79, 13);
            this.cbTipProdaje.Name = "cbTipProdaje";
            this.cbTipProdaje.Size = new System.Drawing.Size(397, 21);
            this.cbTipProdaje.TabIndex = 82;
            this.cbTipProdaje.SelectedIndexChanged += new System.EventHandler(this.CbTipProdaje_SelectedIndexChanged);
            // 
            // txtCijenaProjekcija
            // 
            this.txtCijenaProjekcija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCijenaProjekcija.Location = new System.Drawing.Point(400, 243);
            this.txtCijenaProjekcija.Margin = new System.Windows.Forms.Padding(2);
            this.txtCijenaProjekcija.Name = "txtCijenaProjekcija";
            this.txtCijenaProjekcija.ReadOnly = true;
            this.txtCijenaProjekcija.Size = new System.Drawing.Size(76, 20);
            this.txtCijenaProjekcija.TabIndex = 81;
            // 
            // lblCijenaProjekcija
            // 
            this.lblCijenaProjekcija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCijenaProjekcija.AutoSize = true;
            this.lblCijenaProjekcija.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCijenaProjekcija.Location = new System.Drawing.Point(320, 246);
            this.lblCijenaProjekcija.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCijenaProjekcija.Name = "lblCijenaProjekcija";
            this.lblCijenaProjekcija.Size = new System.Drawing.Size(76, 13);
            this.lblCijenaProjekcija.TabIndex = 80;
            this.lblCijenaProjekcija.Text = "Cijena (KM):";
            // 
            // btnOdaberiSjedista
            // 
            this.btnOdaberiSjedista.Location = new System.Drawing.Point(12, 192);
            this.btnOdaberiSjedista.Name = "btnOdaberiSjedista";
            this.btnOdaberiSjedista.Size = new System.Drawing.Size(464, 23);
            this.btnOdaberiSjedista.TabIndex = 30;
            this.btnOdaberiSjedista.Text = "Odaberi sjedišta";
            this.btnOdaberiSjedista.UseVisualStyleBackColor = true;
            this.btnOdaberiSjedista.Click += new System.EventHandler(this.BtnOdaberiSjedista_Click);
            // 
            // gbArtikli
            // 
            this.gbArtikli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbArtikli.Controls.Add(this.txtCijenaArtikli);
            this.gbArtikli.Controls.Add(this.label7);
            this.gbArtikli.Controls.Add(this.dgvArtikli);
            this.gbArtikli.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbArtikli.Location = new System.Drawing.Point(497, 12);
            this.gbArtikli.Name = "gbArtikli";
            this.gbArtikli.Size = new System.Drawing.Size(455, 266);
            this.gbArtikli.TabIndex = 84;
            this.gbArtikli.TabStop = false;
            this.gbArtikli.Text = "Artikli";
            // 
            // txtCijenaArtikli
            // 
            this.txtCijenaArtikli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCijenaArtikli.Location = new System.Drawing.Point(374, 231);
            this.txtCijenaArtikli.Margin = new System.Windows.Forms.Padding(2);
            this.txtCijenaArtikli.Name = "txtCijenaArtikli";
            this.txtCijenaArtikli.ReadOnly = true;
            this.txtCijenaArtikli.Size = new System.Drawing.Size(76, 20);
            this.txtCijenaArtikli.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(294, 234);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 69;
            this.label7.Text = "Cijena (KM):";
            // 
            // dgvArtikli
            // 
            this.dgvArtikli.AllowUserToAddRows = false;
            this.dgvArtikli.AllowUserToDeleteRows = false;
            this.dgvArtikli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtikli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtikli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Izaberi,
            this.dataGridViewTextBoxColumn2,
            this.Cijena,
            this.Kolicina});
            this.dgvArtikli.Location = new System.Drawing.Point(0, 20);
            this.dgvArtikli.Name = "dgvArtikli";
            this.dgvArtikli.Size = new System.Drawing.Size(455, 201);
            this.dgvArtikli.TabIndex = 15;
            this.dgvArtikli.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArtikli_CellContentClick);
            this.dgvArtikli.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArtikli_CellValueChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Izaberi
            // 
            this.Izaberi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Izaberi.HeaderText = "";
            this.Izaberi.Name = "Izaberi";
            this.Izaberi.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Naziv";
            this.dataGridViewTextBoxColumn2.HeaderText = "Naziv";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            // 
            // Kolicina
            // 
            this.Kolicina.HeaderText = "Količina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // FrmProdajaDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 383);
            this.Controls.Add(this.gbArtikli);
            this.Controls.Add(this.btnOdaberiSjedista);
            this.Controls.Add(this.gbRezervacija);
            this.Controls.Add(this.gbInformacije);
            this.Controls.Add(this.Tip);
            this.Controls.Add(this.cbTipProdaje);
            this.Controls.Add(this.txtCijenaProjekcija);
            this.Controls.Add(this.lblCijenaProjekcija);
            this.Controls.Add(this.txtCijenaUkupno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnSpremi);
            this.MaximumSize = new System.Drawing.Size(980, 422);
            this.MinimumSize = new System.Drawing.Size(980, 422);
            this.Name = "FrmProdajaDodajUredi";
            this.Text = "Dodaj korisnika";
            this.Load += new System.EventHandler(this.FrmProdajaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.gbInformacije.ResumeLayout(false);
            this.gbInformacije.PerformLayout();
            this.gbRezervacija.ResumeLayout(false);
            this.gbRezervacija.PerformLayout();
            this.gbArtikli.ResumeLayout(false);
            this.gbArtikli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtikli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.TextBox txtCijenaUkupno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbInformacije;
        private System.Windows.Forms.GroupBox gbRezervacija;
        private System.Windows.Forms.ComboBox cbRezervacija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodajKorisnika;
        private System.Windows.Forms.Button btnProjekcijaInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTermin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKorisnik;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbProjekcija;
        private System.Windows.Forms.Label Tip;
        private System.Windows.Forms.ComboBox cbTipProdaje;
        private System.Windows.Forms.TextBox txtCijenaProjekcija;
        private System.Windows.Forms.Label lblCijenaProjekcija;
        private System.Windows.Forms.Button btnOdaberiSjedista;
        private System.Windows.Forms.TextBox txtCijenaArtikli;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvArtikli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Izaberi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.GroupBox gbArtikli;
    }
}