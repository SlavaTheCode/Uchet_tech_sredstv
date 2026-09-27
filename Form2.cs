using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_tech_sredstv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS\Source\repos\Uchet_tech_sredstv\Database1.mdf;Integrated Security=True;Connect Timeout=30;";
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (comboBox1.Text == "Аудитория 101") { SearchByName("Auditoriya_1", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 102") { SearchByName("Auditoriya_2", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 103") { SearchByName("Auditoriya_3", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 104") { SearchByName("Auditoriya_4", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 105") { SearchByName("Auditoriya_5", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 106") { SearchByName("Auditoriya_6", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 107") { SearchByName("Auditoriya_7", textBox1.Text); }
                else if (comboBox1.Text == "Аудитория 108") { SearchByName("Auditoriya_8", textBox1.Text); }
            }
        }
        private void SearchByName(string table, string name)
        {
            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();
                string query = $"SELECT * FROM {table} WHERE Название LIKE @name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
