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


namespace Ftp_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FTPUploadFile(filename);
        }
        string filename;
        private string Open_File()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                
            }
            // получаем выбранный файл
            filename = openFileDialog1.FileName;
            label1.Text = filename;
            return filename;
            //string file = Path.GetFileName(filename);
            //// читаем файл в строку
            
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
            // Файловый поток
            FileStream fs = fileInf.OpenRead();
                try
                {
                Stream strm = reqFTP.GetRequestStream();
                    // Читаем из потока по 2 кбайт
                    contentLen = fs.Read(buff, 0, buffLength);
                    // Пока файл не кончится
                    while (contentLen != 0)
                    {
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    // Закрываем потоки
                    strm.Close();
                    fs.Close();
                    label1.Text = "файл загружен!";
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
    }
}
