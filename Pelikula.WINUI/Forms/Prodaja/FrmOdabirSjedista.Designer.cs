
namespace Pelikula.WINUI.Forms.Prodaja
{
    partial class FrmOdabirSjedista
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
            this.flpSjedista = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOcisti
            // 
            this.btnOcisti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcisti.Location = new System.Drawing.Point(336, 35);
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
            this.btnSpremi.Location = new System.Drawing.Point(417, 35);
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
            // flpSjedista
            // 
            this.flpSjedista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flpSjedista.AutoSize = true;
            this.flpSjedista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSjedista.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpSjedista.Location = new System.Drawing.Point(202, 10);
            this.flpSjedista.MaximumSize = new System.Drawing.Size(481, 0);
            this.flpSjedista.MinimumSize = new System.Drawing.Size(100, 5);
            this.flpSjedista.Name = "flpSjedista";
            this.flpSjedista.Size = new System.Drawing.Size(100, 5);
            this.flpSjedista.TabIndex = 13;
            // 
            // FrmOdabirSjedista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(508, 70);
            this.Controls.Add(this.flpSjedista);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnSpremi);
            this.Name = "FrmOdabirSjedista";
            this.Text = "Odaberi sjedišta";
            this.Load += new System.EventHandler(this.FrmOdabirSjedista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.FlowLayoutPanel flpSjedista;
    }
}