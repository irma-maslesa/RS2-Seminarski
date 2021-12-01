
namespace Pelikula.WINUI.Forms.Projekcija
{
    partial class FrmProjekcijaDodajUredi
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
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOcisti = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.btnFilmInfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVrijediDo = new System.Windows.Forms.DateTimePicker();
            this.dtpVrijediOd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTermin1 = new System.Windows.Forms.CheckBox();
            this.dtpTermin1 = new System.Windows.Forms.DateTimePicker();
            this.txtCijena = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTermin6 = new System.Windows.Forms.CheckBox();
            this.dtpTermin6 = new System.Windows.Forms.DateTimePicker();
            this.cbTermin5 = new System.Windows.Forms.CheckBox();
            this.dtpTermin5 = new System.Windows.Forms.DateTimePicker();
            this.cbTermin4 = new System.Windows.Forms.CheckBox();
            this.dtpTermin4 = new System.Windows.Forms.DateTimePicker();
            this.cbTermin3 = new System.Windows.Forms.CheckBox();
            this.dtpTermin3 = new System.Windows.Forms.DateTimePicker();
            this.cbTermin2 = new System.Windows.Forms.CheckBox();
            this.dtpTermin2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(379, 160);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 23);
            this.btnOcisti.TabIndex = 7;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(461, 160);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 7;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.BtnSpremi_Click);
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(47, 12);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(223, 21);
            this.cbFilm.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Film";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sala";
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(47, 48);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(252, 21);
            this.cbSala.TabIndex = 16;
            // 
            // btnFilmInfo
            // 
            this.btnFilmInfo.Location = new System.Drawing.Point(276, 10);
            this.btnFilmInfo.Name = "btnFilmInfo";
            this.btnFilmInfo.Size = new System.Drawing.Size(23, 23);
            this.btnFilmInfo.TabIndex = 18;
            this.btnFilmInfo.Text = "i";
            this.btnFilmInfo.UseVisualStyleBackColor = true;
            this.btnFilmInfo.Click += new System.EventHandler(this.BtnFilmInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cijena";
            // 
            // dtpVrijediDo
            // 
            this.dtpVrijediDo.CustomFormat = "dd/MM/yyyy";
            this.dtpVrijediDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVrijediDo.Location = new System.Drawing.Point(184, 122);
            this.dtpVrijediDo.Name = "dtpVrijediDo";
            this.dtpVrijediDo.Size = new System.Drawing.Size(115, 20);
            this.dtpVrijediDo.TabIndex = 1;
            this.dtpVrijediDo.ValueChanged += new System.EventHandler(this.DtpVrijediDo_ValueChanged);
            this.dtpVrijediDo.Validating += new System.ComponentModel.CancelEventHandler(this.Dtp_Validating);
            // 
            // dtpVrijediOd
            // 
            this.dtpVrijediOd.CustomFormat = "dd/MM/yyyy";
            this.dtpVrijediOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVrijediOd.Location = new System.Drawing.Point(47, 122);
            this.dtpVrijediOd.Name = "dtpVrijediOd";
            this.dtpVrijediOd.Size = new System.Drawing.Size(115, 20);
            this.dtpVrijediOd.TabIndex = 20;
            this.dtpVrijediOd.ValueChanged += new System.EventHandler(this.DtpVrijediOd_ValueChanged);
            this.dtpVrijediOd.Validating += new System.ComponentModel.CancelEventHandler(this.Dtp_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Vrijedi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "-";
            // 
            // cbTermin1
            // 
            this.cbTermin1.AutoSize = true;
            this.cbTermin1.Checked = true;
            this.cbTermin1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin1.Location = new System.Drawing.Point(8, 23);
            this.cbTermin1.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin1.Name = "cbTermin1";
            this.cbTermin1.Size = new System.Drawing.Size(15, 14);
            this.cbTermin1.TabIndex = 0;
            this.cbTermin1.UseVisualStyleBackColor = true;
            // 
            // dtpTermin1
            // 
            this.dtpTermin1.CustomFormat = "HH:mm";
            this.dtpTermin1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin1.Location = new System.Drawing.Point(28, 19);
            this.dtpTermin1.Name = "dtpTermin1";
            this.dtpTermin1.ShowUpDown = true;
            this.dtpTermin1.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin1.TabIndex = 23;
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(47, 85);
            this.txtCijena.Mask = "0000.00";
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(252, 20);
            this.txtCijena.TabIndex = 23;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCijena_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTermin6);
            this.groupBox1.Controls.Add(this.dtpTermin6);
            this.groupBox1.Controls.Add(this.cbTermin5);
            this.groupBox1.Controls.Add(this.dtpTermin5);
            this.groupBox1.Controls.Add(this.cbTermin4);
            this.groupBox1.Controls.Add(this.dtpTermin4);
            this.groupBox1.Controls.Add(this.cbTermin3);
            this.groupBox1.Controls.Add(this.dtpTermin3);
            this.groupBox1.Controls.Add(this.cbTermin2);
            this.groupBox1.Controls.Add(this.dtpTermin2);
            this.groupBox1.Controls.Add(this.cbTermin1);
            this.groupBox1.Controls.Add(this.dtpTermin1);
            this.groupBox1.Location = new System.Drawing.Point(321, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 130);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Termin";
            // 
            // cbTermin6
            // 
            this.cbTermin6.AutoSize = true;
            this.cbTermin6.Checked = true;
            this.cbTermin6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin6.Location = new System.Drawing.Point(114, 99);
            this.cbTermin6.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin6.Name = "cbTermin6";
            this.cbTermin6.Size = new System.Drawing.Size(15, 14);
            this.cbTermin6.TabIndex = 32;
            this.cbTermin6.UseVisualStyleBackColor = true;
            this.cbTermin6.Click += new System.EventHandler(this.CbTermin6_CheckedChanged);
            // 
            // dtpTermin6
            // 
            this.dtpTermin6.CustomFormat = "HH:mm";
            this.dtpTermin6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin6.Location = new System.Drawing.Point(134, 95);
            this.dtpTermin6.Name = "dtpTermin6";
            this.dtpTermin6.ShowUpDown = true;
            this.dtpTermin6.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin6.TabIndex = 33;
            // 
            // cbTermin5
            // 
            this.cbTermin5.AutoSize = true;
            this.cbTermin5.Checked = true;
            this.cbTermin5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin5.Location = new System.Drawing.Point(8, 99);
            this.cbTermin5.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin5.Name = "cbTermin5";
            this.cbTermin5.Size = new System.Drawing.Size(15, 14);
            this.cbTermin5.TabIndex = 30;
            this.cbTermin5.UseVisualStyleBackColor = true;
            this.cbTermin5.Click += new System.EventHandler(this.CbTermin5_CheckedChanged);
            // 
            // dtpTermin5
            // 
            this.dtpTermin5.CustomFormat = "HH:mm";
            this.dtpTermin5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin5.Location = new System.Drawing.Point(28, 95);
            this.dtpTermin5.Name = "dtpTermin5";
            this.dtpTermin5.ShowUpDown = true;
            this.dtpTermin5.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin5.TabIndex = 31;
            // 
            // cbTermin4
            // 
            this.cbTermin4.AutoSize = true;
            this.cbTermin4.Checked = true;
            this.cbTermin4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin4.Location = new System.Drawing.Point(114, 61);
            this.cbTermin4.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin4.Name = "cbTermin4";
            this.cbTermin4.Size = new System.Drawing.Size(15, 14);
            this.cbTermin4.TabIndex = 28;
            this.cbTermin4.UseVisualStyleBackColor = true;
            this.cbTermin4.Click += new System.EventHandler(this.CbTermin4_CheckedChanged);
            // 
            // dtpTermin4
            // 
            this.dtpTermin4.CustomFormat = "HH:mm";
            this.dtpTermin4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin4.Location = new System.Drawing.Point(134, 57);
            this.dtpTermin4.Name = "dtpTermin4";
            this.dtpTermin4.ShowUpDown = true;
            this.dtpTermin4.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin4.TabIndex = 29;
            // 
            // cbTermin3
            // 
            this.cbTermin3.AutoSize = true;
            this.cbTermin3.Checked = true;
            this.cbTermin3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin3.Location = new System.Drawing.Point(8, 61);
            this.cbTermin3.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin3.Name = "cbTermin3";
            this.cbTermin3.Size = new System.Drawing.Size(15, 14);
            this.cbTermin3.TabIndex = 26;
            this.cbTermin3.UseVisualStyleBackColor = true;
            this.cbTermin3.Click += new System.EventHandler(this.CbTermin3_CheckedChanged);
            // 
            // dtpTermin3
            // 
            this.dtpTermin3.CustomFormat = "HH:mm";
            this.dtpTermin3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin3.Location = new System.Drawing.Point(28, 57);
            this.dtpTermin3.Name = "dtpTermin3";
            this.dtpTermin3.ShowUpDown = true;
            this.dtpTermin3.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin3.TabIndex = 27;
            // 
            // cbTermin2
            // 
            this.cbTermin2.AutoSize = true;
            this.cbTermin2.Checked = true;
            this.cbTermin2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTermin2.Location = new System.Drawing.Point(114, 23);
            this.cbTermin2.Margin = new System.Windows.Forms.Padding(2);
            this.cbTermin2.Name = "cbTermin2";
            this.cbTermin2.Size = new System.Drawing.Size(15, 14);
            this.cbTermin2.TabIndex = 24;
            this.cbTermin2.UseVisualStyleBackColor = true;
            this.cbTermin2.Click += new System.EventHandler(this.CbTermin2_CheckedChanged);
            // 
            // dtpTermin2
            // 
            this.dtpTermin2.CustomFormat = "HH:mm";
            this.dtpTermin2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTermin2.Location = new System.Drawing.Point(134, 19);
            this.dtpTermin2.Name = "dtpTermin2";
            this.dtpTermin2.ShowUpDown = true;
            this.dtpTermin2.Size = new System.Drawing.Size(70, 20);
            this.dtpTermin2.TabIndex = 25;
            // 
            // FrmProjekcijaDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 195);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpVrijediOd);
            this.Controls.Add(this.dtpVrijediDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilmInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilm);
            this.Controls.Add(this.btnOcisti);
            this.Name = "FrmProjekcijaDodajUredi";
            this.Text = "Dodaj projekciju";
            this.Load += new System.EventHandler(this.FrmProjekcijaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpVrijediOd;
        private System.Windows.Forms.DateTimePicker dtpVrijediDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilmInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.DateTimePicker dtpTermin1;
        private System.Windows.Forms.CheckBox cbTermin1;
        private System.Windows.Forms.MaskedTextBox txtCijena;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbTermin6;
        private System.Windows.Forms.DateTimePicker dtpTermin6;
        private System.Windows.Forms.CheckBox cbTermin5;
        private System.Windows.Forms.DateTimePicker dtpTermin5;
        private System.Windows.Forms.CheckBox cbTermin4;
        private System.Windows.Forms.DateTimePicker dtpTermin4;
        private System.Windows.Forms.CheckBox cbTermin3;
        private System.Windows.Forms.DateTimePicker dtpTermin3;
        private System.Windows.Forms.CheckBox cbTermin2;
        private System.Windows.Forms.DateTimePicker dtpTermin2;
    }
}