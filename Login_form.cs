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
using System.Net;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Ftp_client
{
    public partial class Login_form : MaterialForm
    {
        string ip;
        string login;
        string password;
        string port;
        const double version_soft = 0.1;
        const string url = "https://pastebin.com/raw/8BSUmDWs";
        int b = 1; 
        public Login_form()
        {
            InitializeComponent();
        }
        private void Updater()
        {
            WebClient client = new WebClient();
            if (client.DownloadString(url).Contains(version_soft.ToString()))
            {
                //
            }
            else
            {
                MessageBox.Show("Доступна новая версия!");
            }
        }
        public void Read()
        {
            int a = -1;
            string writePath = Application.StartupPath + "\\login\\login.txt";
            using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
            {
                
                string line;
                Data.login_all = new string[5];
                while ((line = sr.ReadLine()) != null)
                { 
                    a++;
                    Data.login_all[a] = line;
                }
                ip= Data.login_all[0];
                port = Data.login_all[1];
                login = Data.login_all[2];
                password = Data.login_all[3];
            }
        }
        public void Form2_load(string ip,string port)
        {
            if (ip != null || port != null)
            {
                Main_FTP_Form form2 = new Main_FTP_Form();
                this.Close();
                form2.ShowDialog();
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
                        await sw.WriteLineAsync(port);
                        await sw.WriteLineAsync(login);
                        await sw.WriteLineAsync(password);
                        
                        b = 0;
                    }
                }
                else
                {
                    System.IO.File.WriteAllBytes(writePath, new byte[0]);
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        await sw.WriteLineAsync(ip);
                        await sw.WriteLineAsync(port);
                        await sw.WriteLineAsync(login);
                        await sw.WriteLineAsync(password);
                        
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
            string _ip = ip_maskedTextBox1.Text;
            string _login = login_maskedTextBox3.Text;
            string _password = pass_maskedTextBox4.Text;
            string _port = port_maskedTextBox2.Text;
            Write(_ip, _login, _password, _port);
            Form2_load(_ip,_port);
        }

        private void Login_form_Load(object sender, EventArgs e)
        {
            Updater();
            Read();
            Form2_load(ip, port);
        }
    }

}
