using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace Uchet_tech_sredstv
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Thread thread;
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pass = "";
            try 
            { 
                pass = Show_Pass(File.ReadAllText($"{login}.txt"));
                if (textBox2.Text == pass)
                {
                    this.Close();
                    thread = new Thread(open_Main);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else { MessageBox.Show("Неправильный пароль", "Ошибка"); }
            }
            catch { MessageBox.Show("Неправильный логин", "Ошибка"); }
        }
        public void open_Main() { Application.Run(new Form1()); }
        public static string Show_Pass(string pass)
        {
            byte[] fullCipher = Convert.FromBase64String(pass);
            byte[] iv = new byte[16]; 
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream msDecrypt = new MemoryStream(fullCipher))
                {
                    msDecrypt.Seek(iv.Length, SeekOrigin.Begin);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
