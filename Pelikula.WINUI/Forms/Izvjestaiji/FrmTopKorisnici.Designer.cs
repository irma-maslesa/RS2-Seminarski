
namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    partial class FrmTopKorisnici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.rvTopKorisnici = new Microsoft.Reporting.WinForms.ReportViewer();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.nudBrojKorisnika = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojKorisnika)).BeginInit();
            this.SuspendLayout();
            // 
            // rvTopKorisnici
            // 
            this.rvTopKorisnici.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rvTopKorisnici.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.Report1.rdlc";
            this.rvTopKorisnici.Location = new System.Drawing.Point(128, 70);
            this.rvTopKorisnici.Name = "rvTopKorisnici";
            this.rvTopKorisnici.ServerReport.BearerToken = null;
            this.rvTopKorisnici.Size = new System.Drawing.Size(943, 518);
            this.rvTopKorisnici.TabIndex = 0;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(583, 21);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(221, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži izvještaj";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.BtnPrikazi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudBrojKorisnika);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbZanr);
            this.groupBox2.Controls.Add(this.btnPrikazi);
            this.groupBox2.Location = new System.Drawing.Point(191, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Žanr";
            // 
            // cbZanr
            // 
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(41, 23);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(310, 21);
            this.cbZanr.TabIndex = 11;
            // 
            // nudBrojKorisnika
            // 
            this.nudBrojKorisnika.Location = new System.Drawing.Point(440, 24);
            this.nudBrojKorisnika.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrojKorisnika.Name = "nudBrojKorisnika";
            this.nudBrojKorisnika.Size = new System.Drawing.Size(120, 20);
            this.nudBrojKorisnika.TabIndex = 13;
            this.nudBrojKorisnika.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "BrojKorisnika";
            // 
            // FrmTopKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rvTopKorisnici);
            this.Name = "FrmTopKorisnici";
            this.Text = "FrmoProdajaPoDatumu";
            this.Load += new System.EventHandler(this.FrmTopKorisnici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojKorisnika)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvTopKorisnici;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbZanr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudBrojKorisnika;
    }
}