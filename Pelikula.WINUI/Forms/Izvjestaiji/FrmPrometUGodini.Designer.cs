
namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    partial class FrmPrometUGodini
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
            this.rvProdajaPoDatumu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvProdajaPoDatumu
            // 
            this.rvProdajaPoDatumu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rvProdajaPoDatumu.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.Report1.rdlc";
            this.rvProdajaPoDatumu.Location = new System.Drawing.Point(128, 70);
            this.rvProdajaPoDatumu.Name = "rvProdajaPoDatumu";
            this.rvProdajaPoDatumu.ServerReport.BearerToken = null;
            this.rvProdajaPoDatumu.Size = new System.Drawing.Size(943, 518);
            this.rvProdajaPoDatumu.TabIndex = 0;
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
            this.btnPrikazi.Location = new System.Drawing.Point(369, 21);
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
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbZanr);
            this.groupBox2.Controls.Add(this.btnPrikazi);
            this.groupBox2.Location = new System.Drawing.Point(298, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 51);
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
            // FrmPrometUGodini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rvProdajaPoDatumu);
            this.Name = "FrmPrometUGodini";
            this.Text = "FrmoProdajaPoDatumu";
            this.Load += new System.EventHandler(this.FrmPrometUGodini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvProdajaPoDatumu;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbZanr;
    }
}