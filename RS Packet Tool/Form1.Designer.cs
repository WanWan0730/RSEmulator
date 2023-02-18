namespace RS_Packet_Tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.crypted_field = new System.Windows.Forms.TextBox();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.decrypted_field = new System.Windows.Forms.TextBox();
            this.utf8_view = new System.Windows.Forms.RichTextBox();
            this.packet_length = new System.Windows.Forms.TextBox();
            this.decode_key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.decode_key_field = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crypted_field
            // 
            this.crypted_field.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.crypted_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crypted_field.Location = new System.Drawing.Point(12, 313);
            this.crypted_field.Multiline = true;
            this.crypted_field.Name = "crypted_field";
            this.crypted_field.Size = new System.Drawing.Size(776, 140);
            this.crypted_field.TabIndex = 0;
            // 
            // decrypt_button
            // 
            this.decrypt_button.Location = new System.Drawing.Point(705, 459);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(83, 25);
            this.decrypt_button.TabIndex = 1;
            this.decrypt_button.Text = "Decrypt";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.decrypt_button_Click);
            // 
            // decrypted_field
            // 
            this.decrypted_field.BackColor = System.Drawing.SystemColors.Control;
            this.decrypted_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decrypted_field.Location = new System.Drawing.Point(12, 35);
            this.decrypted_field.Multiline = true;
            this.decrypted_field.Name = "decrypted_field";
            this.decrypted_field.ReadOnly = true;
            this.decrypted_field.Size = new System.Drawing.Size(383, 218);
            this.decrypted_field.TabIndex = 2;
            // 
            // utf8_view
            // 
            this.utf8_view.Location = new System.Drawing.Point(401, 35);
            this.utf8_view.Name = "utf8_view";
            this.utf8_view.ReadOnly = true;
            this.utf8_view.Size = new System.Drawing.Size(387, 218);
            this.utf8_view.TabIndex = 3;
            this.utf8_view.Text = "";
            // 
            // packet_length
            // 
            this.packet_length.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.packet_length.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packet_length.Location = new System.Drawing.Point(12, 276);
            this.packet_length.Multiline = true;
            this.packet_length.Name = "packet_length";
            this.packet_length.Size = new System.Drawing.Size(101, 31);
            this.packet_length.TabIndex = 5;
            // 
            // decode_key
            // 
            this.decode_key.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.decode_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decode_key.Location = new System.Drawing.Point(119, 276);
            this.decode_key.Multiline = true;
            this.decode_key.Name = "decode_key";
            this.decode_key.Size = new System.Drawing.Size(109, 31);
            this.decode_key.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Packet length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Decode bytes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "HEXADECIMAL View";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "ANCII View";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(673, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hexadecimal input";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Decode key";
            // 
            // decode_key_field
            // 
            this.decode_key_field.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.decode_key_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decode_key_field.Location = new System.Drawing.Point(234, 276);
            this.decode_key_field.Multiline = true;
            this.decode_key_field.Name = "decode_key_field";
            this.decode_key_field.Size = new System.Drawing.Size(109, 31);
            this.decode_key_field.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.decode_key_field);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decode_key);
            this.Controls.Add(this.packet_length);
            this.Controls.Add(this.utf8_view);
            this.Controls.Add(this.decrypted_field);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.crypted_field);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "RS Packet Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox crypted_field;
        private Button decrypt_button;
        private TextBox decrypted_field;
        private RichTextBox utf8_view;
        private TextBox packet_length;
        private TextBox decode_key;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox decode_key_field;
    }
}