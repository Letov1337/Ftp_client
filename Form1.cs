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
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch();
        double down_speed;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FTPUploadFile(filename);
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
        private void FTPUploadFile(string filename)
        {
                
                FileInfo fileInf = new FileInfo(filename);
                string uri = "ftp://" + "192.168.1.149:2221" + "/bluetooth/" + fileInf.Name;
                FtpWebRequest reqFTP;
                // Создаем объект FtpWebRequest
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + "192.168.1.149:2221" + "/bluetooth/" + fileInf.Name));
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
            label1.Text = "Upload complete !";
        }
    }
}
