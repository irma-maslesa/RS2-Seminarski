
namespace Pelikula.WINUI.Forms.Film
{
    partial class FrmFilmDodajUredi
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
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSadrzaj = new System.Windows.Forms.TextBox();
            this.txtImdbLink = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGodinaSnimanja = new System.Windows.Forms.MaskedTextBox();
            this.txtTrajanje = new System.Windows.Forms.MaskedTextBox();
            this.txtVideoLink = new System.Windows.Forms.TextBox();
            this.cbReditelj = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajPlakat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbPlakat = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbGlumci = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ofdPlakat = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlakat)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbZanr
            // 
            this.cbZanr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(8, 188);
            this.cbZanr.Margin = new System.Windows.Forms.Padding(2);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(175, 21);
            this.cbZanr.TabIndex = 49;
            this.cbZanr.Validating += new System.ComponentModel.CancelEventHandler(this.cbZanr_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 173);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Žanr";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSadrzaj
            // 
            this.txtSadrzaj.Location = new System.Drawing.Point(6, 18);
            this.txtSadrzaj.Margin = new System.Windows.Forms.Padding(2);
            this.txtSadrzaj.Multiline = true;
            this.txtSadrzaj.Name = "txtSadrzaj";
            this.txtSadrzaj.Size = new System.Drawing.Size(470, 76);
            this.txtSadrzaj.TabIndex = 43;
            this.txtSadrzaj.Validating += new System.ComponentModel.CancelEventHandler(this.txtSadrzaj_Validating);
            // 
            // txtImdbLink
            // 
            this.txtImdbLink.Location = new System.Drawing.Point(8, 273);
            this.txtImdbLink.Margin = new System.Windows.Forms.Padding(2);
            this.txtImdbLink.Name = "txtImdbLink";
            this.txtImdbLink.Size = new System.Drawing.Size(175, 20);
            this.txtImdbLink.TabIndex = 38;
            this.txtImdbLink.Validating += new System.ComponentModel.CancelEventHandler(this.txtImdbLink_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "IMDB link";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGodinaSnimanja
            // 
            this.txtGodinaSnimanja.Location = new System.Drawing.Point(8, 105);
            this.txtGodinaSnimanja.Margin = new System.Windows.Forms.Padding(2);
            this.txtGodinaSnimanja.Mask = "0000";
            this.txtGodinaSnimanja.Name = "txtGodinaSnimanja";
            this.txtGodinaSnimanja.Size = new System.Drawing.Size(175, 20);
            this.txtGodinaSnimanja.TabIndex = 32;
            this.txtGodinaSnimanja.ValidatingType = typeof(int);
            this.txtGodinaSnimanja.Validating += new System.ComponentModel.CancelEventHandler(this.txtGodinaSnimanja_Validating);
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(8, 68);
            this.txtTrajanje.Margin = new System.Windows.Forms.Padding(2);
            this.txtTrajanje.Mask = "000";
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(175, 20);
            this.txtTrajanje.TabIndex = 30;
            this.txtTrajanje.ValidatingType = typeof(int);
            this.txtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrajanje_Validating);
            // 
            // txtVideoLink
            // 
            this.txtVideoLink.Location = new System.Drawing.Point(8, 236);
            this.txtVideoLink.Margin = new System.Windows.Forms.Padding(2);
            this.txtVideoLink.Name = "txtVideoLink";
            this.txtVideoLink.Size = new System.Drawing.Size(175, 20);
            this.txtVideoLink.TabIndex = 36;
            this.txtVideoLink.Validating += new System.ComponentModel.CancelEventHandler(this.txtVideoLink_Validating);
            // 
            // cbReditelj
            // 
            this.cbReditelj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReditelj.FormattingEnabled = true;
            this.cbReditelj.Location = new System.Drawing.Point(8, 150);
            this.cbReditelj.Margin = new System.Windows.Forms.Padding(2);
            this.cbReditelj.Name = "cbReditelj";
            this.cbReditelj.Size = new System.Drawing.Size(175, 21);
            this.cbReditelj.TabIndex = 34;
            this.cbReditelj.Validating += new System.ComponentModel.CancelEventHandler(this.cbReditelj_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Reditelj";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Godina snimanja";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Trajanje (min)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 221);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Video link";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(523, 374);
            this.btnOcisti.Margin = new System.Windows.Forms.Padding(2);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 24);
            this.btnOcisti.TabIndex = 45;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(523, 336);
            this.btnSnimi.Margin = new System.Windows.Forms.Padding(2);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(75, 24);
            this.btnSnimi.TabIndex = 44;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.BtnSpremi_Click);
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(52, 19);
            this.txtNaslov.Margin = new System.Windows.Forms.Padding(2);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(321, 20);
            this.txtNaslov.TabIndex = 28;
            this.txtNaslov.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaslov_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Naslov";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDodajPlakat
            // 
            this.btnDodajPlakat.Location = new System.Drawing.Point(6, 271);
            this.btnDodajPlakat.Name = "btnDodajPlakat";
            this.btnDodajPlakat.Size = new System.Drawing.Size(184, 23);
            this.btnDodajPlakat.TabIndex = 24;
            this.btnDodajPlakat.Text = "Dodaj plakat";
            this.btnDodajPlakat.UseVisualStyleBackColor = true;
            this.btnDodajPlakat.Click += new System.EventHandler(this.BtnDodajPlakat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajPlakat);
            this.groupBox1.Controls.Add(this.pbPlakat);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 300);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plakat";
            // 
            // pbPlakat
            // 
            this.pbPlakat.Location = new System.Drawing.Point(6, 19);
            this.pbPlakat.Name = "pbPlakat";
            this.pbPlakat.Size = new System.Drawing.Size(184, 245);
            this.pbPlakat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlakat.TabIndex = 13;
            this.pbPlakat.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbGlumci);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtNaslov);
            this.groupBox2.Controls.Add(this.cbZanr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtImdbLink);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbReditelj);
            this.groupBox2.Controls.Add(this.txtGodinaSnimanja);
            this.groupBox2.Controls.Add(this.txtVideoLink);
            this.groupBox2.Controls.Add(this.txtTrajanje);
            this.groupBox2.Location = new System.Drawing.Point(214, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 300);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacije";
            // 
            // clbGlumci
            // 
            this.clbGlumci.FormattingEnabled = true;
            this.clbGlumci.Location = new System.Drawing.Point(198, 79);
            this.clbGlumci.Name = "clbGlumci";
            this.clbGlumci.Size = new System.Drawing.Size(175, 214);
            this.clbGlumci.TabIndex = 52;
            this.clbGlumci.Validating += new System.ComponentModel.CancelEventHandler(this.clbGlumci_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(195, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Glumci";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSadrzaj);
            this.groupBox3.Location = new System.Drawing.Point(12, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 100);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sadržaj";
            // 
            // ofdPlakat
            // 
            this.ofdPlakat.FileName = "openFileDialog1";
            // 
            // FrmFilmDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 423);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmFilmDodajUredi";
            this.Text = "Dodaj film";
            this.Load += new System.EventHandler(this.FrmFilmDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlakat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbZanr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSadrzaj;
        private System.Windows.Forms.TextBox txtImdbLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtGodinaSnimanja;
        private System.Windows.Forms.MaskedTextBox txtTrajanje;
        private System.Windows.Forms.TextBox txtVideoLink;
        private System.Windows.Forms.ComboBox cbReditelj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.TextBox txtNaslov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDodajPlakat;
        private System.Windows.Forms.PictureBox pbPlakat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog ofdPlakat;
        private System.Windows.Forms.CheckedListBox clbGlumci;
    }
}