
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
            this.login_label2 = new System.Windows.Forms.Label();
            this.pass_label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.log_pass_checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ip_maskedTextBox1
            // 
            this.ip_maskedTextBox1.Location = new System.Drawing.Point(56, 73);
            this.ip_maskedTextBox1.Name = "ip_maskedTextBox1";
            this.ip_maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.ip_maskedTextBox1.TabIndex = 0;
            this.ip_maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // port_maskedTextBox2
            // 
            this.port_maskedTextBox2.Location = new System.Drawing.Point(197, 70);
            this.port_maskedTextBox2.Mask = "00000";
            this.port_maskedTextBox2.Name = "port_maskedTextBox2";
            this.port_maskedTextBox2.Size = new System.Drawing.Size(40, 20);
            this.port_maskedTextBox2.TabIndex = 1;
            // 
            // login_maskedTextBox3
            // 
            this.login_maskedTextBox3.Location = new System.Drawing.Point(56, 109);
            this.login_maskedTextBox3.Name = "login_maskedTextBox3";
            this.login_maskedTextBox3.Size = new System.Drawing.Size(100, 20);
            this.login_maskedTextBox3.TabIndex = 2;
            this.login_maskedTextBox3.Visible = false;
            // 
            // pass_maskedTextBox4
            // 
            this.pass_maskedTextBox4.Location = new System.Drawing.Point(56, 146);
            this.pass_maskedTextBox4.Name = "pass_maskedTextBox4";
            this.pass_maskedTextBox4.Size = new System.Drawing.Size(100, 20);
            this.pass_maskedTextBox4.TabIndex = 3;
            this.pass_maskedTextBox4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(31, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ip:";
            // 
            // login_label2
            // 
            this.login_label2.AutoSize = true;
            this.login_label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.login_label2.Location = new System.Drawing.Point(17, 112);
            this.login_label2.Name = "login_label2";
            this.login_label2.Size = new System.Drawing.Size(36, 13);
            this.login_label2.TabIndex = 5;
            this.login_label2.Text = "Login:";
            this.login_label2.Visible = false;
            // 
            // pass_label3
            // 
            this.pass_label3.AutoSize = true;
            this.pass_label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pass_label3.Location = new System.Drawing.Point(17, 149);
            this.pass_label3.Name = "pass_label3";
            this.pass_label3.Size = new System.Drawing.Size(33, 13);
            this.pass_label3.TabIndex = 6;
            this.pass_label3.Text = "Pass:";
            this.pass_label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(162, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // log_pass_checkBox1
            // 
            this.log_pass_checkBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.log_pass_checkBox1.Location = new System.Drawing.Point(165, 94);
            this.log_pass_checkBox1.Name = "log_pass_checkBox1";
            this.log_pass_checkBox1.Size = new System.Drawing.Size(88, 50);
            this.log_pass_checkBox1.TabIndex = 9;
            this.log_pass_checkBox1.Text = "Имеется логин и пароль?";
            this.log_pass_checkBox1.UseVisualStyleBackColor = false;
            this.log_pass_checkBox1.CheckedChanged += new System.EventHandler(this.log_pass_checkBox1_CheckedChanged);
            // 
            // Login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 224);
            this.Controls.Add(this.log_pass_checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pass_label3);
            this.Controls.Add(this.login_label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_maskedTextBox4);
            this.Controls.Add(this.login_maskedTextBox3);
            this.Controls.Add(this.port_maskedTextBox2);
            this.Controls.Add(this.ip_maskedTextBox1);
            this.Name = "Login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label login_label2;
        private System.Windows.Forms.Label pass_label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox log_pass_checkBox1;
    }
}