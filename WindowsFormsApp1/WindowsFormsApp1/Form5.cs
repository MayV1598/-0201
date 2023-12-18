using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form5:Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Database db = new Database();

        // Добавление записи в таблицу "Категории сотрудников"
        private void button1_Click(object sender,EventArgs e)
        {
            db.openConnection();

            var k = textBox2.Text;
            int ks;

            if(int.TryParse(textBox1.Text,out ks))
            {
                var addQuery = $"insert into [КАТЕГОРИИ СОТРУДНИКОВ] ([Код сотрудника], [Категория]) " +
                    $"values ('{ks}', '{k}')";
                var command = new SqlCommand(addQuery,db.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно добавлена!");
            }
            else
            {
                MessageBox.Show("Код сотрудника должен быть числового формата!");
            }

            db.closeConnection();

            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
