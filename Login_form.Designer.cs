
namespace Ftp_client
{
    partial class Login_form
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
            this.ip_maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.port_maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.login_maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.pass_maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip_maskedTextBox1
            // 
            this.ip_maskedTextBox1.Location = new System.Drawing.Point(63, 39);
            this.ip_maskedTextBox1.Name = "ip_maskedTextBox1";
            this.ip_maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.ip_maskedTextBox1.TabIndex = 0;
            this.ip_maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // port_maskedTextBox2
            // 
            this.port_maskedTextBox2.Location = new System.Drawing.Point(207, 36);
            this.port_maskedTextBox2.Mask = "00000";
            this.port_maskedTextBox2.Name = "port_maskedTextBox2";
            this.port_maskedTextBox2.Size = new System.Drawing.Size(40, 20);
            this.port_maskedTextBox2.TabIndex = 1;
            // 
            // login_maskedTextBox3
            // 
            this.login_maskedTextBox3.Location = new System.Drawing.Point(63, 75);
            this.login_maskedTextBox3.Name = "login_maskedTextBox3";
            this.login_maskedTextBox3.Size = new System.Drawing.Size(100, 20);
            this.login_maskedTextBox3.TabIndex = 2;
            // 
            // pass_maskedTextBox4
            // 
            this.pass_maskedTextBox4.Location = new System.Drawing.Point(63, 112);
            this.pass_maskedTextBox4.Name = "pass_maskedTextBox4";
            this.pass_maskedTextBox4.Size = new System.Drawing.Size(100, 20);
            this.pass_maskedTextBox4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Login:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pass:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_maskedTextBox4);
            this.Controls.Add(this.login_maskedTextBox3);
            this.Controls.Add(this.port_maskedTextBox2);
            this.Controls.Add(this.ip_maskedTextBox1);
            this.Name = "Login_form";
            this.Text = "Login_form";
            this.Load += new System.EventHandler(this.Login_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox ip_maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox port_maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox login_maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox pass_maskedTextBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}