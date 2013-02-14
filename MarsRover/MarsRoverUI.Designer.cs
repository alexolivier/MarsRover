namespace MarsRover
{
    partial class MarsRoverUI
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
            this.instructions_Txt = new System.Windows.Forms.TextBox();
            this.output_Txt = new System.Windows.Forms.TextBox();
            this.calcPosition_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // instructions_Txt
            // 
            this.instructions_Txt.Location = new System.Drawing.Point(12, 12);
            this.instructions_Txt.Multiline = true;
            this.instructions_Txt.Name = "instructions_Txt";
            this.instructions_Txt.Size = new System.Drawing.Size(260, 154);
            this.instructions_Txt.TabIndex = 0;
            this.instructions_Txt.Text = "5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM";
            // 
            // output_Txt
            // 
            this.output_Txt.Location = new System.Drawing.Point(12, 172);
            this.output_Txt.Multiline = true;
            this.output_Txt.Name = "output_Txt";
            this.output_Txt.Size = new System.Drawing.Size(260, 108);
            this.output_Txt.TabIndex = 1;
            // 
            // calcPosition_Btn
            // 
            this.calcPosition_Btn.Location = new System.Drawing.Point(12, 286);
            this.calcPosition_Btn.Name = "calcPosition_Btn";
            this.calcPosition_Btn.Size = new System.Drawing.Size(260, 23);
            this.calcPosition_Btn.TabIndex = 2;
            this.calcPosition_Btn.Text = "Calculate Position";
            this.calcPosition_Btn.UseVisualStyleBackColor = true;
            this.calcPosition_Btn.Click += new System.EventHandler(this.calcPosition_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(144, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Developed by Alex Olivier";
            // 
            // MarsRoverUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 338);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calcPosition_Btn);
            this.Controls.Add(this.output_Txt);
            this.Controls.Add(this.instructions_Txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MarsRoverUI";
            this.Text = "Mars Rover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox instructions_Txt;
        private System.Windows.Forms.TextBox output_Txt;
        private System.Windows.Forms.Button calcPosition_Btn;
        private System.Windows.Forms.Label label1;
    }
}

