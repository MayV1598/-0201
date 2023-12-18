using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form6:Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Database db = new Database();

        // Добавление записи в таблицу "Предприятия"
        private void button1_Click(object sender,EventArgs e)
        {
            db.openConnection();

            var n = textBox2.Text;
            var a = textBox3.Text;
            var kt = textBox4.Text;
            
                var addQuery = $"insert into ПРЕДПРИЯТИЯ ([Название предприятия], [Адрес], [Контактный телефон]) " +
                    $"values ('{n}', '{a}', '{kt}')";
                var command = new SqlCommand(addQuery,db.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно добавлена!");

            db.closeConnection();
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
