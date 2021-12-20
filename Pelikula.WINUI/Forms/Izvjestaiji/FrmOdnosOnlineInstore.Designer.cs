
namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    partial class FrmOdnosOnlineInstore
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
            this.rvOdnosOnlineInstore = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPeriod = new System.Windows.Forms.CheckBox();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // rvOdnosOnlineInstore
            // 
            this.rvOdnosOnlineInstore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rvOdnosOnlineInstore.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptProdajaPoDatumu.rdlc";
            this.rvOdnosOnlineInstore.Location = new System.Drawing.Point(128, 70);
            this.rvOdnosOnlineInstore.Name = "rvOdnosOnlineInstore";
            this.rvOdnosOnlineInstore.ServerReport.BearerToken = null;
            this.rvOdnosOnlineInstore.Size = new System.Drawing.Size(943, 518);
            this.rvOdnosOnlineInstore.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.cbPeriod);
            this.groupBox2.Controls.Add(this.dtpDo);
            this.groupBox2.Controls.Add(this.dtpOd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnPrikazi);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1178, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametri";
            // 
            // cbPeriod
            // 
            this.cbPeriod.AutoSize = true;
            this.cbPeriod.Location = new System.Drawing.Point(16, 22);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(102, 17);
            this.cbPeriod.TabIndex = 8;
            this.cbPeriod.Text = "Određeni period";
            this.cbPeriod.UseVisualStyleBackColor = true;
            this.cbPeriod.CheckedChanged += new System.EventHandler(this.CbPeriod_CheckedChanged);
            // 
            // dtpDo
            // 
            this.dtpDo.CustomFormat = "dd/MM/yyyy";
            this.dtpDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDo.Location = new System.Drawing.Point(618, 19);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(350, 20);
            this.dtpDo.TabIndex = 7;
            this.dtpDo.ValueChanged += new System.EventHandler(this.DtpDo_ValueChanged);
            // 
            // dtpOd
            // 
            this.dtpOd.CustomFormat = "dd/MM/yyyy";
            this.dtpOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOd.Location = new System.Drawing.Point(193, 19);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(350, 20);
            this.dtpOd.TabIndex = 6;
            this.dtpOd.ValueChanged += new System.EventHandler(this.DtpOd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Do datuma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Od datuma";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(974, 16);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(198, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži izvještaj";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.BtnPrikazi_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // FrmOdnosOnlineInstore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rvOdnosOnlineInstore);
            this.Name = "FrmOdnosOnlineInstore";
            this.Text = "FrmoProdajaPoDatumu";
            this.Load += new System.EventHandler(this.FrmOdnosOnlineInstore_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvOdnosOnlineInstore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.CheckBox cbPeriod;
    }
}