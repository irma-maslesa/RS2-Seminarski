
namespace Pelikula.WINUI.Forms.Projekcija
{
    partial class FrmProjekcija
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProjekcije = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAktivno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JedinicaMjere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GodinaSnimanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjekcije)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.dgvProjekcije);
            this.groupBox1.Location = new System.Drawing.Point(15, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1180, 499);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projekcije";
            // 
            // dgvProjekcije
            // 
            this.dgvProjekcije.AllowUserToAddRows = false;
            this.dgvProjekcije.AllowUserToDeleteRows = false;
            this.dgvProjekcije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjekcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjekcije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Datum,
            this.JedinicaMjere,
            this.Sifra,
            this.GodinaSnimanja});
            this.dgvProjekcije.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjekcije.Location = new System.Drawing.Point(3, 16);
            this.dgvProjekcije.Name = "dgvProjekcije";
            this.dgvProjekcije.ReadOnly = true;
            this.dgvProjekcije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjekcije.Size = new System.Drawing.Size(1174, 480);
            this.dgvProjekcije.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cbAktivno);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbSala);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cbFilm);
            this.groupBox4.Location = new System.Drawing.Point(18, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(754, 71);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Aktivna";
            // 
            // cbAktivno
            // 
            this.cbAktivno.FormattingEnabled = true;
            this.cbAktivno.Location = new System.Drawing.Point(504, 43);
            this.cbAktivno.Name = "cbAktivno";
            this.cbAktivno.Size = new System.Drawing.Size(243, 21);
            this.cbAktivno.TabIndex = 13;
            this.cbAktivno.SelectedValueChanged += new System.EventHandler(this.CbAktivno_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sala";
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(255, 43);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(243, 21);
            this.cbSala.TabIndex = 11;
            this.cbSala.SelectedValueChanged += new System.EventHandler(this.CbSala_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Film";
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(6, 43);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(243, 21);
            this.cbFilm.TabIndex = 0;
            this.cbFilm.SelectedValueChanged += new System.EventHandler(this.CbFilm_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.btnObrisi);
            this.groupBox3.Controls.Add(this.btnUredi);
            this.groupBox3.Controls.Add(this.btnDodaj);
            this.groupBox3.Location = new System.Drawing.Point(778, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 71);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opcije";
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(278, 43);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(130, 23);
            this.btnObrisi.TabIndex = 4;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.BtnObrisi_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.Location = new System.Drawing.Point(142, 43);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(130, 23);
            this.btnUredi.TabIndex = 3;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.BtnUredi_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(6, 43);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(130, 23);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.BtnDodaj_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Film";
            this.Naziv.HeaderText = "Film";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Sala";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.Datum.DefaultCellStyle = dataGridViewCellStyle1;
            this.Datum.HeaderText = "Sala";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // JedinicaMjere
            // 
            this.JedinicaMjere.DataPropertyName = "Cijena";
            this.JedinicaMjere.HeaderText = "Cijena";
            this.JedinicaMjere.Name = "JedinicaMjere";
            this.JedinicaMjere.ReadOnly = true;
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "VrijediOd";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Sifra.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sifra.HeaderText = "Vrijedi od";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // GodinaSnimanja
            // 
            this.GodinaSnimanja.DataPropertyName = "VrijediDo";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.GodinaSnimanja.DefaultCellStyle = dataGridViewCellStyle3;
            this.GodinaSnimanja.HeaderText = "Vrijedi do";
            this.GodinaSnimanja.Name = "GodinaSnimanja";
            this.GodinaSnimanja.ReadOnly = true;
            // 
            // FrmProjekcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProjekcija";
            this.Text = "Upravljanje projekcijama";
            this.Load += new System.EventHandler(this.FrmProjekcija_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjekcije)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProjekcije;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAktivno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn JedinicaMjere;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodinaSnimanja;
    }
}