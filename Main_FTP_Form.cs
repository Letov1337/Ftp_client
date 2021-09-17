using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Ftp_client
{
    public partial class Main_FTP_Form : Form
    {
        Stopwatch sw = new Stopwatch();
        double down_speed;
        string selected_directory;
        string ip;
        string port;
        string login;
        string password;
        
        public Main_FTP_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        string filename;
        private string Open_File()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                
            }
            filename = openFileDialog1.FileName;
            label1.Text = filename;
            return filename;
        }
        private void SetBalloonTip(string Upload_final)
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = Upload_final;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
        }
        private void NI_BallonTipClosed(Object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        public void Read()
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "\\login\\login.txt");
            //Read the first line of text
           
            Data.login_all = new string[5];
            //Continue to read until you reach end of file
            int a = -1;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                a++;
                Data.login_all[a] = line;
                Console.WriteLine(line);
            }
            //close the file
            sr.Close();
            Console.ReadLine();
        }

        public void FTPFolder_Load(string ip,string port,string login, string pass)
        {
            
            try
            {
                // Создаем объект FtpWebRequest
                /*FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create("ftp://192.168.1.149:2221/");*/
                FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}:{1}/", ip,port));
                // Учетная запись
                reqFTP.Credentials = new NetworkCredential(login, password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string[] directory_list = reader.ReadToEnd().Split('\n');
                foreach (var item in directory_list)
                {
                    listBox1.Items.Add(item);
                }
                Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");
                reader.Close();
                response.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        private void FTPUploadFile(string filename)
        {
               FileInfo fileInf = new FileInfo(filename);
                if (selected_directory != null)
                {
                    string uri = String.Format("ftp://{0}:{1}/", ip, port) + string.Format("/{0}/", selected_directory) + fileInf.Name;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать элемент!");
                }
                FtpWebRequest reqFTP;
                // Создаем объект FtpWebRequest
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(String.Format("ftp://{0}:{1}/", ip, port) + string.Format("/{0}/", selected_directory) + fileInf.Name));
                // Учетная запись
                reqFTP.Credentials = new NetworkCredential("test", "test");
                reqFTP.KeepAlive = false;
                // Задаем команду на закачку
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                // Тип передачи файла
                reqFTP.UseBinary = true;
                // Сообщаем серверу о размере файла
                reqFTP.ContentLength = fileInf.Length;

            // Буффер в 2 кбайт
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
            sw.Start();
            // Файловый поток
                FileStream fs = fileInf.OpenRead();
            try
                {
                 Stream strm = reqFTP.GetRequestStream();
                    // Читаем из потока по 2 кбайт
                    contentLen = fs.Read(buff, 0, buffLength);
                // Пока файл не кончится
                    double total = (double)fs.Length;
                    double read = 0;
                    int counter = 0;
                    DateTime startTime = DateTime.Now;
                while (contentLen != 0)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                        read += (double)contentLen;
                        double percentage = read / total * 100;
                        backgroundWorker1.ReportProgress((int)percentage);
                        counter += contentLen;
                        down_speed = (Convert.ToDouble(counter) / DateTime.Now.Subtract(startTime).TotalSeconds)/1024/1024;

                    }
                }
                // Закрываем потоки
                    strm.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open_File();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FTPUploadFile(filename);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = $"Uploaded {e.ProgressPercentage} %";
            label2.Text = string.Format("Cкорость:{0:N2} мб/c",down_speed);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string Upload_final = "Upload complete !";
            label1.Text = Upload_final;
            SetBalloonTip(Upload_final);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_directory = listBox1.SelectedItem.ToString();
            selected_directory = selected_directory.Replace("\r", "");
            label1.Text = selected_directory.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            ip = Data.login_all[0];
            port = Data.login_all[1];
            login = Data.login_all[2];
            password = Data.login_all[3];
            FTPFolder_Load(ip,port,login,password); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in Data.login_all)
            {
                Console.WriteLine(item);
            }
        }
    }
}
