using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form4:Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Database db = new Database();

        // Добавление записи в таблицу "Сотрудники"
        private void button1_Click(object sender,EventArgs e)
        {
            db.openConnection();

            var fio = textBox2.Text;
            var np = textBox3.Text;
            var dr = textBox4.Text;
            var rt = textBox5.Text;
            var p = textBox1.Text;

            var addQuery = $"insert into СОТРУДНИКИ ([ФИО], [Номер паспорта], [Дата рождения], [Рабочий телефон], [Пароль]) " +
                $"values ('{fio}', '{np}', '{dr}', '{rt}', '{p}')";
            var command = new SqlCommand(addQuery,db.GetConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запись успешно добавлена!");

            db.closeConnection();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
