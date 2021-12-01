
namespace Pelikula.WINUI.Forms.Korisnik
{
    partial class FrmKorisnikDodajUredi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKorisnikDodajUredi));
            this.txtIme = new System.Windows.Forms.TextBox();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDatumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTipKorisnika = new System.Windows.Forms.ComboBox();
            this.cbSpol = new System.Windows.Forms.ComboBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.ofdSlika = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(13, 38);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(150, 20);
            this.txtIme.TabIndex = 6;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.TxtIme_Validating);
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(404, 283);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 23);
            this.btnOcisti.TabIndex = 10;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ime";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(485, 283);
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
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpDatumRodjenja);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbTipKorisnika);
            this.groupBox2.Controls.Add(this.cbSpol);
            this.groupBox2.Controls.Add(this.txtLozinka);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtKorisnickoIme);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPrezime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtIme);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(214, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 264);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacije";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(305, 209);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Datum rođenja";
            // 
            // dtpDatumRodjenja
            // 
            this.dtpDatumRodjenja.Location = new System.Drawing.Point(93, 117);
            this.dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            this.dtpDatumRodjenja.Size = new System.Drawing.Size(231, 20);
            this.dtpDatumRodjenja.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tip korisnika";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Spol";
            // 
            // cbTipKorisnika
            // 
            this.cbTipKorisnika.FormattingEnabled = true;
            this.cbTipKorisnika.Location = new System.Drawing.Point(93, 233);
            this.cbTipKorisnika.Name = "cbTipKorisnika";
            this.cbTipKorisnika.Size = new System.Drawing.Size(231, 21);
            this.cbTipKorisnika.TabIndex = 19;
            this.cbTipKorisnika.Validating += new System.ComponentModel.CancelEventHandler(this.CbTipKorisnika_Validating);
            // 
            // cbSpol
            // 
            this.cbSpol.FormattingEnabled = true;
            this.cbSpol.Location = new System.Drawing.Point(93, 90);
            this.cbSpol.Name = "cbSpol";
            this.cbSpol.Size = new System.Drawing.Size(231, 21);
            this.cbSpol.TabIndex = 14;
            this.cbSpol.Validating += new System.ComponentModel.CancelEventHandler(this.CbSpol_Validating);
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(93, 207);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.PasswordChar = '*';
            this.txtLozinka.Size = new System.Drawing.Size(231, 20);
            this.txtLozinka.TabIndex = 17;
            this.txtLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLozinka_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Lozinka";
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(93, 181);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(231, 20);
            this.txtKorisnickoIme.TabIndex = 15;
            this.txtKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.TxtKorisnickoIme_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Korisničko ime";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(93, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 20);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmail_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Email";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(185, 38);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(139, 20);
            this.txtPrezime.TabIndex = 9;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPrezime_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Prezime";
            // 
            // pbSlika
            // 
            this.pbSlika.Location = new System.Drawing.Point(6, 19);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(184, 245);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 13;
            this.pbSlika.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajSliku);
            this.groupBox1.Controls.Add(this.pbSlika);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 300);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slika";
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(6, 271);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(184, 23);
            this.btnDodajSliku.TabIndex = 24;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.BtnDodajSliku_Click);
            // 
            // ofdSlika
            // 
            this.ofdSlika.FileName = "openFileDialog1";
            // 
            // FrmKorisnikDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnSpremi);
            this.Name = "FrmKorisnikDodajUredi";
            this.Text = "Dodaj korisnika";
            this.Load += new System.EventHandler(this.FrmKorisnikDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDatumRodjenja;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTipKorisnika;
        private System.Windows.Forms.ComboBox cbSpol;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdSlika;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}