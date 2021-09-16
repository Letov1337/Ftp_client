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
        int a = 1;
        public Login_form()
        {
            InitializeComponent();
        }
        public async void Write(string ip, string login, string password/*, string port*/)
        {
            string writePath = Application.StartupPath + "\\login\\login.txt";
            //string text = "Привет мир!\nПока мир...";
            try
            {
                //using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                //{
                //    await sw.WriteLineAsync(text);
                //}
                
                if (a == 1)
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        await sw.WriteLineAsync(ip);
                        await sw.WriteLineAsync(login);
                        await sw.WriteLineAsync(password);
                        a = 0;
                        Console.WriteLine("Запись выполнена");
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
                        a = 1;
                        Console.WriteLine("Очистка выполнена");
                        Console.WriteLine("Запись выполнена");
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip = ip_maskedTextBox1.Text;
            login = login_maskedTextBox3.Text;
            password = pass_maskedTextBox4.Text;
            Write(ip,login,password);
        }
    }

}
