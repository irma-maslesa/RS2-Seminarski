
namespace Pelikula.WINUI.Forms.Sala
{
    partial class FrmSalaDodajUredi
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.errNaziv = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBrojSjedistaRed = new System.Windows.Forms.NumericUpDown();
            this.nudBrojRedova = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojSjedistaRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojRedova)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(114, 22);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(246, 20);
            this.txtNaziv.TabIndex = 0;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(285, 127);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 2;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.BtnSpremi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv";
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(204, 127);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(75, 23);
            this.btnOcisti.TabIndex = 5;
            this.btnOcisti.Text = "Očisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            this.btnOcisti.Click += new System.EventHandler(this.BtnOcisti_Click);
            // 
            // errNaziv
            // 
            this.errNaziv.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Broj sjedišta u redu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Broj redova";
            // 
            // nudBrojSjedistaRed
            // 
            this.nudBrojSjedistaRed.Location = new System.Drawing.Point(114, 58);
            this.nudBrojSjedistaRed.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudBrojSjedistaRed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrojSjedistaRed.Name = "nudBrojSjedistaRed";
            this.nudBrojSjedistaRed.Size = new System.Drawing.Size(246, 20);
            this.nudBrojSjedistaRed.TabIndex = 12;
            this.nudBrojSjedistaRed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudBrojRedova
            // 
            this.nudBrojRedova.Location = new System.Drawing.Point(114, 93);
            this.nudBrojRedova.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudBrojRedova.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrojRedova.Name = "nudBrojRedova";
            this.nudBrojRedova.Size = new System.Drawing.Size(246, 20);
            this.nudBrojRedova.TabIndex = 13;
            this.nudBrojRedova.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmSalaDodajUredi
            // 
            this.AcceptButton = this.btnSpremi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 163);
            this.Controls.Add(this.nudBrojRedova);
            this.Controls.Add(this.nudBrojSjedistaRed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtNaziv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalaDodajUredi";
            this.ShowIcon = false;
            this.Text = "Dodaj jedinicu mjere";
            this.Load += new System.EventHandler(this.FrmSalaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojSjedistaRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrojRedova)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.ErrorProvider errNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBrojRedova;
        private System.Windows.Forms.NumericUpDown nudBrojSjedistaRed;
    }
}