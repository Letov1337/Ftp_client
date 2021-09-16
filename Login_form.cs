using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Ftp_client
{
    public partial class Login_form : Form
    {
        string ip;
        string login;
        string password;
        string port;
        int b; 
        public Login_form()
        {
            InitializeComponent();
            Read();
            
        }
        public async void Read()
        {
            int a = -1;
            string writePath = Application.StartupPath + "\\login\\login.txt";
            using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
            {
                
                string line;
                Data.login_all = new string[5];
                while ((line = await sr.ReadLineAsync()) != null)
                { 
                    a++;
                    Data.login_all[a] = line;
                }
                ip_maskedTextBox1.Text = Data.login_all[0];
                login_maskedTextBox3.Text = Data.login_all[1];
                pass_maskedTextBox4.Text = Data.login_all[2];
                port_maskedTextBox2.Text = Data.login_all[3];
            }
        }
        public async void Write(string ip, string login, string password, string port)
        {
            string writePath = Application.StartupPath + "\\login\\login.txt";
            try
            {
                if (b == 1)
                {
                    // запись
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        await sw.WriteLineAsync(ip);
                        await sw.WriteLineAsync(login);
                        await sw.WriteLineAsync(password);
                        await sw.WriteLineAsync(port);
                        b = 0;
                    }
                }
                else
                {
                    System.IO.File.WriteAllBytes(writePath, new byte[0]);
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        await sw.WriteLineAsync(ip);
                        await sw.WriteLineAsync(login);
                        await sw.WriteLineAsync(password);
                        await sw.WriteLineAsync(port);
                        b = 1;
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip = ip_maskedTextBox1.Text;
            login = login_maskedTextBox3.Text;
            password = pass_maskedTextBox4.Text;
            port = port_maskedTextBox2.Text;
            Write(ip,login,password,port);
        }
    }

}
