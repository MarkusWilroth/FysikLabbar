namespace Redovisning2 {
    partial class Form1 {
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
            this.label1 = new System.Windows.Forms.Label();
            this.NUD_Friktion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NUD_Hastighet = new System.Windows.Forms.NumericUpDown();
            this.btn_Kurva1 = new System.Windows.Forms.Button();
            this.btn_Kurva2 = new System.Windows.Forms.Button();
            this.txb_Output = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Restart = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Friktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Hastighet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Friktionskoefficient";
            // 
            // NUD_Friktion
            // 
            this.NUD_Friktion.DecimalPlaces = 2;
            this.NUD_Friktion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUD_Friktion.Location = new System.Drawing.Point(13, 37);
            this.NUD_Friktion.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Friktion.Name = "NUD_Friktion";
            this.NUD_Friktion.Size = new System.Drawing.Size(162, 20);
            this.NUD_Friktion.TabIndex = 1;
            this.NUD_Friktion.ValueChanged += new System.EventHandler(this.NUD_Friktion_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hastighet";
            // 
            // NUD_Hastighet
            // 
            this.NUD_Hastighet.Location = new System.Drawing.Point(13, 88);
            this.NUD_Hastighet.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_Hastighet.Name = "NUD_Hastighet";
            this.NUD_Hastighet.Size = new System.Drawing.Size(162, 20);
            this.NUD_Hastighet.TabIndex = 3;
            this.NUD_Hastighet.ValueChanged += new System.EventHandler(this.NUD_Hastighet_ValueChanged);
            // 
            // btn_Kurva1
            // 
            this.btn_Kurva1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Kurva1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Kurva1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Kurva1.Location = new System.Drawing.Point(181, 12);
            this.btn_Kurva1.Name = "btn_Kurva1";
            this.btn_Kurva1.Size = new System.Drawing.Size(90, 44);
            this.btn_Kurva1.TabIndex = 4;
            this.btn_Kurva1.Text = "Kurva 1";
            this.btn_Kurva1.UseVisualStyleBackColor = false;
            this.btn_Kurva1.Click += new System.EventHandler(this.btn_Kurva1_Click);
            // 
            // btn_Kurva2
            // 
            this.btn_Kurva2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Kurva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Kurva2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Kurva2.Location = new System.Drawing.Point(181, 64);
            this.btn_Kurva2.Name = "btn_Kurva2";
            this.btn_Kurva2.Size = new System.Drawing.Size(90, 44);
            this.btn_Kurva2.TabIndex = 5;
            this.btn_Kurva2.Text = "Kurva 2";
            this.btn_Kurva2.UseVisualStyleBackColor = false;
            this.btn_Kurva2.Click += new System.EventHandler(this.btn_Kurva2_Click);
            // 
            // txb_Output
            // 
            this.txb_Output.Location = new System.Drawing.Point(12, 115);
            this.txb_Output.Name = "txb_Output";
            this.txb_Output.Size = new System.Drawing.Size(259, 20);
            this.txb_Output.TabIndex = 6;
            this.txb_Output.Text = "Aktiverad Kurva: 1";
            this.txb_Output.TextChanged += new System.EventHandler(this.txb_Output_TextChanged);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Start.Location = new System.Drawing.Point(13, 141);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(122, 50);
            this.btn_Start.TabIndex = 7;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Restart
            // 
            this.btn_Restart.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Restart.Location = new System.Drawing.Point(149, 141);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.Size = new System.Drawing.Size(122, 50);
            this.btn_Restart.TabIndex = 8;
            this.btn_Restart.Text = "Omstart";
            this.btn_Restart.UseVisualStyleBackColor = false;
            this.btn_Restart.Click += new System.EventHandler(this.btn_Restart_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Quit.Location = new System.Drawing.Point(79, 197);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(122, 50);
            this.btn_Quit.TabIndex = 9;
            this.btn_Quit.Text = "Avsluta";
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Restart);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txb_Output);
            this.Controls.Add(this.btn_Kurva2);
            this.Controls.Add(this.btn_Kurva1);
            this.Controls.Add(this.NUD_Hastighet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NUD_Friktion);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Friktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Hastighet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUD_Friktion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUD_Hastighet;
        private System.Windows.Forms.Button btn_Kurva1;
        private System.Windows.Forms.Button btn_Kurva2;
        private System.Windows.Forms.TextBox txb_Output;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Restart;
        private System.Windows.Forms.Button btn_Quit;
    }
}