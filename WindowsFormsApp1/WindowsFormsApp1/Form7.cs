using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form7:Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        Database db = new Database();

        // Добавление записи в таблицу "Выполненная работа"
        private void button1_Click(object sender,EventArgs e)
        {
            db.openConnection();

            var dv = textBox4.Text;
            var kch = textBox5.Text;
            int kp;
            int ks;

            if(int.TryParse(textBox2.Text,out kp) && int.TryParse(textBox3.Text,out ks))
            {
                var addQuery = $"insert into [ВЫПОЛНЕННАЯ РАБОТА] ([Код предприятия], [Код сотрудника], [Дата выполнения], [Количество отработанных часов]) " +
                    $"values ('{kp}', '{ks}', '{dv}', '{kch}')";
                var command = new SqlCommand(addQuery,db.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно добавлена!");
            }
            else
            {
                MessageBox.Show("Код сотрудника, код предприятия и код работы должны быть числового формата!");
            }

            db.closeConnection();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
