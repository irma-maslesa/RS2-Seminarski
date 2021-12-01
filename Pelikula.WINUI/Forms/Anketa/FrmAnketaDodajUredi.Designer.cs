
namespace Pelikula.WINUI.Forms.Anketa
{
    partial class FrmAnketaDodajUredi
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
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOdgovor5 = new System.Windows.Forms.TextBox();
            this.cbOdgovor5 = new System.Windows.Forms.CheckBox();
            this.txtOdgovor4 = new System.Windows.Forms.TextBox();
            this.cbOdgovor4 = new System.Windows.Forms.CheckBox();
            this.txtOdgovor3 = new System.Windows.Forms.TextBox();
            this.cbOdgovor3 = new System.Windows.Forms.CheckBox();
            this.txtOdgovor2 = new System.Windows.Forms.TextBox();
            this.cbOdgovor2 = new System.Windows.Forms.CheckBox();
            this.txtOdgovor1 = new System.Windows.Forms.TextBox();
            this.cbOdgovor1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(52, 18);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(320, 20);
            this.txtNaslov.TabIndex = 6;
            this.txtNaslov.Validating += new System.ComponentModel.CancelEventHandler(this.TxtNaslov_Validating);
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(216, 211);
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
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Naslov";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(297, 211);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 7;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.BtnSpremi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOdgovor5);
            this.groupBox1.Controls.Add(this.cbOdgovor5);
            this.groupBox1.Controls.Add(this.txtOdgovor4);
            this.groupBox1.Controls.Add(this.cbOdgovor4);
            this.groupBox1.Controls.Add(this.txtOdgovor3);
            this.groupBox1.Controls.Add(this.cbOdgovor3);
            this.groupBox1.Controls.Add(this.txtOdgovor2);
            this.groupBox1.Controls.Add(this.cbOdgovor2);
            this.groupBox1.Controls.Add(this.txtOdgovor1);
            this.groupBox1.Controls.Add(this.cbOdgovor1);
            this.groupBox1.Location = new System.Drawing.Point(15, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(357, 154);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odgovori";
            // 
            // txtOdgovor5
            // 
            this.txtOdgovor5.Location = new System.Drawing.Point(26, 126);
            this.txtOdgovor5.Margin = new System.Windows.Forms.Padding(2);
            this.txtOdgovor5.Name = "txtOdgovor5";
            this.txtOdgovor5.ReadOnly = true;
            this.txtOdgovor5.Size = new System.Drawing.Size(327, 20);
            this.txtOdgovor5.TabIndex = 9;
            // 
            // cbOdgovor5
            // 
            this.cbOdgovor5.AutoSize = true;
            this.cbOdgovor5.Location = new System.Drawing.Point(8, 128);
            this.cbOdgovor5.Margin = new System.Windows.Forms.Padding(2);
            this.cbOdgovor5.Name = "cbOdgovor5";
            this.cbOdgovor5.Size = new System.Drawing.Size(15, 14);
            this.cbOdgovor5.TabIndex = 8;
            this.cbOdgovor5.UseVisualStyleBackColor = true;
            this.cbOdgovor5.CheckedChanged += new System.EventHandler(this.CbOdgovor5_CheckedChanged);
            // 
            // txtOdgovor4
            // 
            this.txtOdgovor4.Location = new System.Drawing.Point(26, 99);
            this.txtOdgovor4.Margin = new System.Windows.Forms.Padding(2);
            this.txtOdgovor4.Name = "txtOdgovor4";
            this.txtOdgovor4.ReadOnly = true;
            this.txtOdgovor4.Size = new System.Drawing.Size(327, 20);
            this.txtOdgovor4.TabIndex = 7;
            // 
            // cbOdgovor4
            // 
            this.cbOdgovor4.AutoSize = true;
            this.cbOdgovor4.Location = new System.Drawing.Point(8, 102);
            this.cbOdgovor4.Margin = new System.Windows.Forms.Padding(2);
            this.cbOdgovor4.Name = "cbOdgovor4";
            this.cbOdgovor4.Size = new System.Drawing.Size(15, 14);
            this.cbOdgovor4.TabIndex = 6;
            this.cbOdgovor4.UseVisualStyleBackColor = true;
            this.cbOdgovor4.CheckedChanged += new System.EventHandler(this.CbOdgovor4_CheckedChanged);
            // 
            // txtOdgovor3
            // 
            this.txtOdgovor3.Location = new System.Drawing.Point(26, 72);
            this.txtOdgovor3.Margin = new System.Windows.Forms.Padding(2);
            this.txtOdgovor3.Name = "txtOdgovor3";
            this.txtOdgovor3.ReadOnly = true;
            this.txtOdgovor3.Size = new System.Drawing.Size(327, 20);
            this.txtOdgovor3.TabIndex = 5;
            // 
            // cbOdgovor3
            // 
            this.cbOdgovor3.AutoSize = true;
            this.cbOdgovor3.Location = new System.Drawing.Point(8, 75);
            this.cbOdgovor3.Margin = new System.Windows.Forms.Padding(2);
            this.cbOdgovor3.Name = "cbOdgovor3";
            this.cbOdgovor3.Size = new System.Drawing.Size(15, 14);
            this.cbOdgovor3.TabIndex = 4;
            this.cbOdgovor3.UseVisualStyleBackColor = true;
            this.cbOdgovor3.CheckedChanged += new System.EventHandler(this.CbOdgovor3_CheckedChanged);
            // 
            // txtOdgovor2
            // 
            this.txtOdgovor2.Location = new System.Drawing.Point(26, 46);
            this.txtOdgovor2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOdgovor2.Name = "txtOdgovor2";
            this.txtOdgovor2.ReadOnly = true;
            this.txtOdgovor2.Size = new System.Drawing.Size(327, 20);
            this.txtOdgovor2.TabIndex = 3;
            // 
            // cbOdgovor2
            // 
            this.cbOdgovor2.AutoSize = true;
            this.cbOdgovor2.Location = new System.Drawing.Point(8, 48);
            this.cbOdgovor2.Margin = new System.Windows.Forms.Padding(2);
            this.cbOdgovor2.Name = "cbOdgovor2";
            this.cbOdgovor2.Size = new System.Drawing.Size(15, 14);
            this.cbOdgovor2.TabIndex = 2;
            this.cbOdgovor2.UseVisualStyleBackColor = true;
            this.cbOdgovor2.CheckedChanged += new System.EventHandler(this.CbOdgovor2_CheckedChanged);
            // 
            // txtOdgovor1
            // 
            this.txtOdgovor1.Location = new System.Drawing.Point(26, 19);
            this.txtOdgovor1.Margin = new System.Windows.Forms.Padding(2);
            this.txtOdgovor1.Name = "txtOdgovor1";
            this.txtOdgovor1.Size = new System.Drawing.Size(327, 20);
            this.txtOdgovor1.TabIndex = 1;
            // 
            // cbOdgovor1
            // 
            this.cbOdgovor1.AutoSize = true;
            this.cbOdgovor1.Checked = true;
            this.cbOdgovor1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOdgovor1.Location = new System.Drawing.Point(8, 21);
            this.cbOdgovor1.Margin = new System.Windows.Forms.Padding(2);
            this.cbOdgovor1.Name = "cbOdgovor1";
            this.cbOdgovor1.Size = new System.Drawing.Size(15, 14);
            this.cbOdgovor1.TabIndex = 0;
            this.cbOdgovor1.UseVisualStyleBackColor = true;
            this.cbOdgovor1.CheckedChanged += new System.EventHandler(this.CbOdgovor1_CheckedChanged);
            // 
            // FrmAnketaDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 244);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNaslov);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSpremi);
            this.Name = "FrmAnketaDodajUredi";
            this.Text = "Dodaj anketu";
            this.Load += new System.EventHandler(this.FrmAnketaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.TextBox txtNaslov;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOdgovor5;
        private System.Windows.Forms.CheckBox cbOdgovor5;
        private System.Windows.Forms.TextBox txtOdgovor4;
        private System.Windows.Forms.CheckBox cbOdgovor4;
        private System.Windows.Forms.TextBox txtOdgovor3;
        private System.Windows.Forms.CheckBox cbOdgovor3;
        private System.Windows.Forms.TextBox txtOdgovor2;
        private System.Windows.Forms.CheckBox cbOdgovor2;
        private System.Windows.Forms.TextBox txtOdgovor1;
        private System.Windows.Forms.CheckBox cbOdgovor1;
    }
}