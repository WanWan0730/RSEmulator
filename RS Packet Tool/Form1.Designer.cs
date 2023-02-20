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
            this.label7 = new System.Windows.Forms.Label();
            this.port_field = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ip_field = new System.Windows.Forms.TextBox();
            this.send_data_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Port";
            // 
            // port_field
            // 
            this.port_field.AutoCompleteCustomSource.AddRange(new string[] {
            "55661",
            "54631",
            "56621"});
            this.port_field.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.port_field.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.port_field.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.port_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.port_field.Location = new System.Drawing.Point(12, 484);
            this.port_field.Multiline = true;
            this.port_field.Name = "port_field";
            this.port_field.Size = new System.Drawing.Size(101, 31);
            this.port_field.TabIndex = 14;
            this.port_field.Text = "55661";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 464);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "IP";
            // 
            // ip_field
            // 
            this.ip_field.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ip_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ip_field.Location = new System.Drawing.Point(127, 484);
            this.ip_field.Multiline = true;
            this.ip_field.Name = "ip_field";
            this.ip_field.Size = new System.Drawing.Size(142, 31);
            this.ip_field.TabIndex = 16;
            this.ip_field.Text = "127.0.0.1";
            // 
            // send_data_button
            // 
            this.send_data_button.Location = new System.Drawing.Point(699, 490);
            this.send_data_button.Name = "send_data_button";
            this.send_data_button.Size = new System.Drawing.Size(89, 31);
            this.send_data_button.TabIndex = 18;
            this.send_data_button.Text = "Send Data";
            this.send_data_button.UseVisualStyleBackColor = true;
            this.send_data_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "Reconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.send_data_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ip_field);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.port_field);
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
        private Label label7;
        private TextBox port_field;
        private Label label8;
        private TextBox ip_field;
        private Button send_data_button;
        private Button button1;
    }
}