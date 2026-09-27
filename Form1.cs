using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_tech_sredstv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS\Source\repos\Uchet_tech_sredstv\Database1.mdf;Integrated Security=True;Connect Timeout=30;";

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty)
            {
                if (comboBox1.Text == "Аудитория 101") { dataGridView1.DataSource = database1DataSet.Auditoriya_1; }
                else if (comboBox1.Text == "Аудитория 102") { dataGridView1.DataSource = database1DataSet.Auditoriya_2; }
                else if (comboBox1.Text == "Аудитория 103") { dataGridView1.DataSource = database1DataSet.Auditoriya_3; }
                else if (comboBox1.Text == "Аудитория 104") { dataGridView1.DataSource = database1DataSet.Auditoriya_4; }
                else if (comboBox1.Text == "Аудитория 105") { dataGridView1.DataSource = database1DataSet.Auditoriya_5; }
                else if (comboBox1.Text == "Аудитория 106") { dataGridView1.DataSource = database1DataSet.Auditoriya_6; }
                else if (comboBox1.Text == "Аудитория 107") { dataGridView1.DataSource = database1DataSet.Auditoriya_7; }
                else if (comboBox1.Text == "Аудитория 108") { dataGridView1.DataSource = database1DataSet.Auditoriya_8; }
                dataGridView1.Update();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_8". При необходимости она может быть перемещена или удалена.
            this.auditoriya_8TableAdapter.Fill(this.database1DataSet.Auditoriya_8);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_7". При необходимости она может быть перемещена или удалена.
            this.auditoriya_7TableAdapter.Fill(this.database1DataSet.Auditoriya_7);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_6". При необходимости она может быть перемещена или удалена.
            this.auditoriya_6TableAdapter.Fill(this.database1DataSet.Auditoriya_6);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_5". При необходимости она может быть перемещена или удалена.
            this.auditoriya_5TableAdapter.Fill(this.database1DataSet.Auditoriya_5);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_4". При необходимости она может быть перемещена или удалена.
            this.auditoriya_4TableAdapter.Fill(this.database1DataSet.Auditoriya_4);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_3". При необходимости она может быть перемещена или удалена.
            this.auditoriya_3TableAdapter.Fill(this.database1DataSet.Auditoriya_3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_2". При необходимости она может быть перемещена или удалена.
            this.auditoriya_2TableAdapter.Fill(this.database1DataSet.Auditoriya_2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Auditoriya_1". При необходимости она может быть перемещена или удалена.
            this.auditoriya_1TableAdapter.Fill(this.database1DataSet.Auditoriya_1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Аудитория 101") { SaveDB(dataGridView1, "Auditoriya_1"); }
            else if (comboBox1.Text == "Аудитория 102") { SaveDB(dataGridView1, "Auditoriya_2"); }
            else if (comboBox1.Text == "Аудитория 103") { SaveDB(dataGridView1, "Auditoriya_3"); }
            else if (comboBox1.Text == "Аудитория 104") { SaveDB(dataGridView1, "Auditoriya_4"); }
            else if (comboBox1.Text == "Аудитория 105") { SaveDB(dataGridView1, "Auditoriya_5"); }
            else if (comboBox1.Text == "Аудитория 106") { SaveDB(dataGridView1, "Auditoriya_6"); }
            else if (comboBox1.Text == "Аудитория 107") { SaveDB(dataGridView1, "Auditoriya_7"); }
            else if (comboBox1.Text == "Аудитория 108") { SaveDB(dataGridView1, "Auditoriya_8"); }
        }
        private void SaveDB(DataGridView dataGridView, string table)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для обновления");
            }
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();

                    // Создаем DataTable и копируем структуру из DataGridView
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Id", typeof(int));
                    dataTable.Columns.Add("Название", typeof(string));
                    dataTable.Columns.Add("Дата_начала_эксплуатации", typeof(DateTime));
                    dataTable.Columns.Add("Наличие_неисправностей", typeof(string));
                    dataTable.Columns.Add("Примечание", typeof(string));
                    dataTable.Columns.Add("Количество", typeof(int));
                    dataTable.Columns.Add("Стоимость_ед", typeof(int));
                    dataTable.Columns.Add("Общая_стоимость", typeof(int));

                    // Заполняем DataTable данными из DataGridView
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue; // Пропускаем новую строку

                        // Создаем новую строку в DataTable
                        DataRow newRow = dataTable.NewRow();

                        // Копируем значения из ячеек DataGridView в новую строку
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            newRow[i] = row.Cells[i].Value ?? DBNull.Value; // Используем DBNull.Value для пустых значений
                        }

                        dataTable.Rows.Add(newRow);
                    }

                    // Создаем SqlDataAdapter для обновления базы данных
                    using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {table}", connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                        // Обновляем базу данных
                        adapter.Update(dataTable);
                    }
                }
                MessageBox.Show("Изменения успешно сохранены!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0)
            {
                string table = " ";
                if (comboBox2.Text == "Аудитория 101") { table = "Auditoriya_1"; }
                else if (comboBox2.Text == "Аудитория 102") { table = "Auditoriya_2"; }
                else if (comboBox2.Text == "Аудитория 103") { table = "Auditoriya_3"; }
                else if (comboBox2.Text == "Аудитория 104") { table = "Auditoriya_4"; }
                else if (comboBox2.Text == "Аудитория 105") { table = "Auditoriya_5"; }
                else if (comboBox2.Text == "Аудитория 106") { table = "Auditoriya_6"; }
                else if (comboBox2.Text == "Аудитория 107") { table = "Auditoriya_7"; }
                else if (comboBox2.Text == "Аудитория 108") { table = "Auditoriya_8"; }
                if (checkBox1.Checked) { AddtoBD(table, "Парта", Convert.ToInt32(numericUpDown2.Value), 6460); checkBox1.Checked = false; }
                else if (checkBox2.Checked) { AddtoBD(table, "Стул", Convert.ToInt32(numericUpDown2.Value), 2078); checkBox2.Checked = false; }
                else if (checkBox3.Checked) { AddtoBD(table, "Компьютер", Convert.ToInt32(numericUpDown2.Value), 23800); checkBox3.Checked = false; }
                else if (checkBox4.Checked) { AddtoBD(table, "Клавиатура", Convert.ToInt32(numericUpDown2.Value), 1500); checkBox4.Checked = false; }
                else if (checkBox5.Checked) { AddtoBD(table, "Монитор", Convert.ToInt32(numericUpDown2.Value), 5000); checkBox5.Checked = false; }
                numericUpDown2.Value = 0;
            }
        }
        private void AddtoBD(string table, string name, int kol, int cost)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();
                string column1Value = name;
                DateTime? column2Value = DateTime.Today;
                string column3Value = "Отсутствуют";
                string column4Value = " ";
                int column5Value = kol;
                int column6Value = cost;
                int column7Value = column5Value * cost;
                string query = $"INSERT INTO {table} (Название, Дата_начала_эксплуатации, Наличие_неисправностей, Примечание, Количество, Стоимость_ед, Общая_стоимость) VALUES (@Название, @Дата_начала_эксплуатации, @Наличие_неисправностей, @Примечание, @Количество, @Стоимость_ед, @Общая_стоимость)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Название", column1Value);
                    command.Parameters.AddWithValue("@Дата_начала_эксплуатации", column2Value);
                    command.Parameters.AddWithValue("@Наличие_неисправностей", column3Value);
                    command.Parameters.AddWithValue("@Примечание", column4Value);
                    command.Parameters.AddWithValue("@Количество", column5Value);
                    command.Parameters.AddWithValue("@Стоимость_ед", column6Value);
                    command.Parameters.AddWithValue("@Общая_стоимость", column7Value);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Технические средства успешно добавлены!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && numericUpDown1.Value != 0)
            {
                string table = " ";
                if (comboBox2.Text == "Аудитория 101") { table = "Auditoriya_1"; }
                else if (comboBox2.Text == "Аудитория 102") { table = "Auditoriya_2"; }
                else if (comboBox2.Text == "Аудитория 103") { table = "Auditoriya_3"; }
                else if (comboBox2.Text == "Аудитория 104") { table = "Auditoriya_4"; }
                else if (comboBox2.Text == "Аудитория 105") { table = "Auditoriya_5"; }
                else if (comboBox2.Text == "Аудитория 106") { table = "Auditoriya_6"; }
                else if (comboBox2.Text == "Аудитория 107") { table = "Auditoriya_7"; }
                else if (comboBox2.Text == "Аудитория 108") { table = "Auditoriya_8"; }
                AddtoBD(table, textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(textBox2.Text));
                textBox1.Text = "";
                textBox2.Text = "";
                numericUpDown1.Value = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string login = textBox4.Text;
            string pass = Hide_Pass(textBox3.Text);
            File.WriteAllText($"{login}.txt", pass);
            MessageBox.Show("Аккаунт успешно создан","Успех!");
            textBox4.Text = string.Empty; 
            textBox3.Text = string.Empty;
        }
        public static string Hide_Pass(string pass)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(iv, 0, iv.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(pass);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            try
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                foreach (string file in files)
                {
                    comboBox3.Items.Add(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файлов: " + ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "admin.txt") { MessageBox.Show("Нельзя удалить аккаунт администратора", "Ошибка"); }
            else
            {
                string file_path = Path.Combine(Directory.GetCurrentDirectory(), comboBox3.Text);
                try
                {
                    if (File.Exists(file_path))
                    {
                        File.Delete(file_path);
                        MessageBox.Show("Аккаунт успешно удалён", "Успех!");
                    }
                    else
                    {
                        MessageBox.Show("Файл не найден: " + file_path, "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении аккаунта: " + ex.Message);
                }
            }
        }
    }
}
