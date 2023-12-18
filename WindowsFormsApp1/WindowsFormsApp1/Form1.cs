using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        Database db = new Database();
        bool c = false;
        int cc = 0;
        int m = 2, s = 59;

        // Вход в учетную запись
        private void button1_Click(object sender,EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select [Код сотрудника], [Пароль] from СОТРУДНИКИ where [Код сотрудника] = '{login}' and Пароль = '{password}'";

            SqlCommand command = new SqlCommand(querystring,db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Первый не успешный вход, вывод окна с капчей
            if(c == true)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
                this.Show();
            }
            // Успешный вход
            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!","Вход",MessageBoxButtons.OK,MessageBoxIcon.Information);
                c = false;
                cc = 0;
                Form3 f3 = new Form3();
                f3.Fio(textBox1.Text);
                this.Hide();
                f3.ShowDialog();
                this.Show();
            }
            else
            // Второй не успешный вход, запуск таймера
            {
                cc++;
                MessageBox.Show("Такого аккаунта не существует!","Ошибка входа",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(cc == 2)
                {
                    button1.Enabled = false;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;
                    label6.ForeColor = Color.Black;
                    timer1.Enabled = true;
                }
                // Третий неуспешный вход, блокировка кнопки
                if(cc == 3)
                {
                    button1.Enabled = false;
                }
                c = true;
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void timer1_Tick(object sender,EventArgs e)
        {
            if(s > 0)
            {
                s--;
                if(s < 10)
                {
                    label6.Text = "0" + s.ToString();
                }
                else
                {
                    label6.Text = s.ToString();
                }
            }
            else if(m > 0)
            {
                m--;
                label4.Text = "0" + m.ToString();
                s = 60;
                label6.Text = "60";
            }
            else if(s == 0 && m == 0)
            {
                timer1.Enabled = false;
                button1.Enabled = true;
            }
        }

        // Скрыть/показать пароль
        private void checkBox1_CheckedChanged(object sender,EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
