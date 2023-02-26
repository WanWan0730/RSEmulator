namespace HEXDIF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.input_1 = new System.Windows.Forms.TextBox();
            this.input_2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.field_result = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.offset_field = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.len_field = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rvalue_field = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input_1
            // 
            this.input_1.Location = new System.Drawing.Point(12, 33);
            this.input_1.Multiline = true;
            this.input_1.Name = "input_1";
            this.input_1.Size = new System.Drawing.Size(534, 125);
            this.input_1.TabIndex = 0;
            // 
            // input_2
            // 
            this.input_2.Location = new System.Drawing.Point(552, 33);
            this.input_2.MaxLength = 999999;
            this.input_2.Multiline = true;
            this.input_2.Name = "input_2";
            this.input_2.Size = new System.Drawing.Size(537, 125);
            this.input_2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input 2";
            // 
            // field_result
            // 
            this.field_result.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.field_result.Location = new System.Drawing.Point(12, 272);
            this.field_result.MaxLength = 99999;
            this.field_result.Multiline = true;
            this.field_result.Name = "field_result";
            this.field_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.field_result.Size = new System.Drawing.Size(1077, 247);
            this.field_result.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1006, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result";
            // 
            // offset_field
            // 
            this.offset_field.Location = new System.Drawing.Point(12, 197);
            this.offset_field.Name = "offset_field";
            this.offset_field.Size = new System.Drawing.Size(113, 25);
            this.offset_field.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "offset to catch";
            // 
            // len_field
            // 
            this.len_field.Location = new System.Drawing.Point(131, 197);
            this.len_field.Name = "len_field";
            this.len_field.Size = new System.Drawing.Size(60, 25);
            this.len_field.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "length";
            // 
            // rvalue_field
            // 
            this.rvalue_field.Location = new System.Drawing.Point(197, 197);
            this.rvalue_field.Name = "rvalue_field";
            this.rvalue_field.ReadOnly = true;
            this.rvalue_field.Size = new System.Drawing.Size(125, 25);
            this.rvalue_field.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 528);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rvalue_field);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.len_field);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.offset_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.field_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_2);
            this.Controls.Add(this.input_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HEXDIF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox input_1;
        private TextBox input_2;
        private Label label1;
        private Label label2;
        private TextBox field_result;
        private Button button1;
        private Label label3;
        private TextBox offset_field;
        private Label label4;
        private TextBox len_field;
        private Label label5;
        private TextBox rvalue_field;
        private Label label6;
    }
}