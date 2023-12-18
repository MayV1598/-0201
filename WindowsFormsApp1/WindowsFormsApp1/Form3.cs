using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3:Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Database db = new Database();

        // Закгрузка таблиц и данных из них
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Код сотрудника","Код сотрудника");
            dataGridView1.Columns.Add("ФИО","ФИО");
            dataGridView1.Columns.Add("Номер паспорта","Номер паспорта");
            dataGridView1.Columns.Add("Дата рождения","Дата рождения");
            dataGridView1.Columns.Add("Рабочий телефон","Рабочий телефон");
            dataGridView1.Columns.Add("Пароль","Пароль");
        }
        private void CreateColumns1()
        {
            dataGridView2.Columns.Add("Категория","Категория");
            dataGridView2.Columns.Add("Ставка за 1 час(тыс.руб.)","Ставка за 1 час(тыс.руб.)");
        }
        private void CreateColumns2()
        {
            dataGridView3.Columns.Add("Код сотрудника","Код сотрудника");
            dataGridView3.Columns.Add("Категория","Категория");
        }
        private void CreateColumns3()
        {
            dataGridView4.Columns.Add("Код предприятия","Код предприятия");
            dataGridView4.Columns.Add("Название предприятия","Название предприятия");
            dataGridView4.Columns.Add("Адрес","Адрес");
            dataGridView4.Columns.Add("Контактный телефон","Контактный телефон");
        }
        private void CreateColumns4()
        {
            dataGridView5.Columns.Add("Код работы","Код работы");
            dataGridView5.Columns.Add("Код предприятия","Код предприятия");
            dataGridView5.Columns.Add("Код сотрудника","Код сотрудика");
            dataGridView5.Columns.Add("Дата выполнения","Дата выполнения");
            dataGridView5.Columns.Add("Количество отработанных часов","Количество отработанных часов");
        }

        private void ReadSingleRow(DataGridView dgw,IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetString(1),record.GetInt32(2),record.GetDateTime(3),record.GetString(4),record.GetInt32(5));
        }
        private void ReadSingleRow1(DataGridView dgw,IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetInt32(1));
        }
        private void ReadSingleRow2(DataGridView dgw,IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetInt32(1));
        }
        private void ReadSingleRow3(DataGridView dgw,IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetString(1),record.GetString(2),record.GetString(3));
        }
        private void ReadSingleRow4(DataGridView dgw,IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0),record.GetInt32(1),record.GetInt32(2),record.GetDateTime(3),record.GetInt32(4));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from СОТРУДНИКИ";
            SqlCommand command = new SqlCommand(queryString,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw,reader);
            }

            reader.Close();
        }
        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from КАТЕГОРИИ";
            SqlCommand command = new SqlCommand(queryString,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow1(dgw,reader);
            }

            reader.Close();
        }
        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from [КАТЕГОРИИ СОТРУДНИКОВ]";
            SqlCommand command = new SqlCommand(queryString,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow2(dgw,reader);
            }

            reader.Close();
        }
        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from ПРЕДПРИЯТИЯ";
            SqlCommand command = new SqlCommand(queryString,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow3(dgw,reader);
            }

            reader.Close();
        }
        private void RefreshDataGrid4(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from [ВЫПОЛНЕННАЯ РАБОТА]";
            SqlCommand command = new SqlCommand(queryString,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow4(dgw,reader);
            }

            reader.Close();
        }

        private void loadComboBox()
        {
            string sql = $"select * from СОТРУДНИКИ";
            using(SqlCommand cmd = new SqlCommand(sql,db.GetConnection()))
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox1.DisplayMember = "ФИО";
                comboBox1.ValueMember = "Код сотрудника";
                comboBox1.DataSource = table;
            }
        }

        private void Form3_Load(object sender,EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            int rc = dataGridView1.Rows.Count;
            label9.Text = $"Количество строк: {rc}";
            loadComboBox();
            CreateColumns1();
            RefreshDataGrid1(dataGridView2);
            rc = dataGridView2.Rows.Count;
            label10.Text = $"Количество строк: {rc}";
            CreateColumns2();
            RefreshDataGrid2(dataGridView3);
            rc = dataGridView3.Rows.Count;
            label11.Text = $"Количество строк: {rc}";
            CreateColumns3();
            RefreshDataGrid3(dataGridView4);
            rc = dataGridView4.Rows.Count;
            label12.Text = $"Количество строк: {rc}";
            CreateColumns4();
            RefreshDataGrid4(dataGridView5);
            rc = dataGridView5.Rows.Count;
            label13.Text = $"Количество строк: {rc}";
        }


        // Распределение уровня доступа
        public void Fio(string i)
        {
            label6.Text = "Директор";
            label7.Text = "Полный доступ";

            if(i != "1")
            {
                tabPage1.Parent = null;
                tabPage3.Parent = null;
                tabPage4.Parent = null;
                tabPage6.Parent = null;
                button14.Enabled = false;
                label6.Text = "Рядовой сотрудник";
                label7.Text = "Обычный доступ";
                pictureBox2.Image = (Image)Properties.Resources._640961;
            }

            string searchFIO = $"select ФИО from СОТРУДНИКИ where [Код сотрудника] = '{i}'";
            SqlCommand command = new SqlCommand(searchFIO,db.GetConnection());
            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                label1.Text = reader["ФИО"].ToString();
            }

            reader.Close();
        }

        // Фильтрация данных
        private void button21_Click(object sender,EventArgs e)
        {
            int rc = dataGridView1.Rows.Count;

            dataGridView1.Rows.Clear();

            string searching = $"select * from СОТРУДНИКИ where ФИО = '{comboBox1.Text}'";

            SqlCommand command = new SqlCommand(searching,db.GetConnection());

            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dataGridView1,reader);
            }

            reader.Close();
            
            int rcc = dataGridView1.Rows.Count;
            label9.Text = $"Количество строк: {rcc} из {rc}";
        }

        // Вывод всех данных
        private void button22_Click(object sender,EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            int rc = dataGridView1.Rows.Count;
            label9.Text = $"Количество строк: {rc}";
        }

        // Добавление записи
        private void button1_Click(object sender,EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        // Обновление данных
        private void button4_Click(object sender,EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            int rc = dataGridView1.Rows.Count;
            label9.Text = $"Количество строк: {rc}";
        }

        // Добавление записи
        private void button12_Click(object sender,EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        // Обновление данных
        private void button9_Click(object sender,EventArgs e)
        {
            RefreshDataGrid2(dataGridView3);
            int rc = dataGridView3.Rows.Count;
            label11.Text = $"Количество строк: {rc}";
        }

        // Добавление записи
        private void button16_Click(object sender,EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        // Обновление данных
        private void button13_Click(object sender,EventArgs e)
        {
            RefreshDataGrid3(dataGridView4);
            int rc = dataGridView4.Rows.Count;
            label12.Text = $"Количество строк: {rc}";
        }

        // Добавление записи
        private void button20_Click(object sender,EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        // Обновление данных
        private void button17_Click(object sender,EventArgs e)
        {
            RefreshDataGrid4(dataGridView5);
            int rc = dataGridView5.Rows.Count;
            label13.Text = $"Количество строк: {rc}";
        }

        // Редактирование записи
        private void button7_Click(object sender,EventArgs e)
        {
            var selectedRowIndex = dataGridView2.CurrentCell.RowIndex;
            var kk = dataGridView2.Rows[selectedRowIndex].Cells[0].Value.ToString();
            var sch = textBox1.Text;

            dataGridView2.Rows[selectedRowIndex].SetValues(kk, sch);

            textBox1.Text = "";
        }

        private void button5_Click(object sender,EventArgs e)
        {
            db.openConnection();

            for(int index = 0;index < dataGridView2.Rows.Count;index++)
            {
                var kk = dataGridView2.Rows[index].Cells[0].Value.ToString();
                var sch = dataGridView2.Rows[index].Cells[1].Value.ToString();

                var changeQuery = $"update КАТЕГОРИИ set [Ставка за 1 час(тыс.руб.)] = '{sch}' where [Категория] = '{kk}'";
                var command = new SqlCommand(changeQuery,db.GetConnection());
                command.ExecuteNonQuery();
            }

            db.closeConnection();
        }

        private void button6_Click(object sender,EventArgs e)
        {
            var selectedRowIndex = dataGridView3.CurrentCell.RowIndex;
            var ks = dataGridView3.Rows[selectedRowIndex].Cells[0].Value.ToString();
            var k = textBox2.Text;

            dataGridView3.Rows[selectedRowIndex].SetValues(ks,k);

            textBox2.Text = "";
        }

        private void button2_Click(object sender,EventArgs e)
        {
            db.openConnection();

            for(int index = 0;index < dataGridView3.Rows.Count;index++)
            {
                var ks = dataGridView3.Rows[index].Cells[0].Value.ToString();
                var k = dataGridView3.Rows[index].Cells[1].Value.ToString();

                var changeQuery = $"update [КАТЕГОРИИ СОТРУДНИКОВ] set [Категория] = '{k}' where [Код сотрудника] = '{ks}'";
                var command = new SqlCommand(changeQuery,db.GetConnection());
                command.ExecuteNonQuery();
            }

            db.closeConnection();
        }

        // Удаление записи
        private void button10_Click(object sender,EventArgs e)
        {
            int rc = dataGridView3.Rows.Count;

            db.openConnection();

            var selectedRowIndex = dataGridView3.CurrentCell.RowIndex;
            var ks = dataGridView3.Rows[selectedRowIndex].Cells[0].Value.ToString();
            dataGridView3.Rows.RemoveAt(selectedRowIndex);
            dataGridView3.Refresh();
            var changeQuery = $"delete from [КАТЕГОРИИ СОТРУДНИКОВ] where [Код сотрудника] = '{ks}'";
            var command = new SqlCommand(changeQuery,db.GetConnection());
            command.ExecuteNonQuery();

            db.closeConnection();

            int rcc = dataGridView3.Rows.Count;
            label11.Text = $"Количество строк: {rcc}";
        }

        private void button14_Click(object sender,EventArgs e)
        {
            int rc = dataGridView4.Rows.Count;

            db.openConnection();

            var selectedRowIndex = dataGridView4.CurrentCell.RowIndex;
            var ks = dataGridView4.Rows[selectedRowIndex].Cells[0].Value.ToString();
            dataGridView4.Rows.RemoveAt(selectedRowIndex);
            dataGridView4.Refresh();
            var changeQuery = $"delete from [ПРЕДПРИЯТИЯ] where [Код предприятия] = '{ks}'";
            var command = new SqlCommand(changeQuery,db.GetConnection());
            command.ExecuteNonQuery();

            db.closeConnection();

            int rcc = dataGridView4.Rows.Count;
            label12.Text = $"Количество строк: {rcc}";
        }

        private void button18_Click(object sender,EventArgs e)
        {
            int rc = dataGridView5.Rows.Count;

            db.openConnection();

            var selectedRowIndex = dataGridView5.CurrentCell.RowIndex;
            var ks = dataGridView5.Rows[selectedRowIndex].Cells[0].Value.ToString();
            dataGridView5.Rows.RemoveAt(selectedRowIndex);
            dataGridView5.Refresh();
            var changeQuery = $"delete from [ВЫПОЛНЕННАЯ РАБОТА] where [Код работы] = '{ks}'";
            var command = new SqlCommand(changeQuery,db.GetConnection());
            command.ExecuteNonQuery();

            db.closeConnection();

            int rcc = dataGridView5.Rows.Count;
            label13.Text = $"Количество строк: {rcc}";
        }

        private void button3_Click(object sender,EventArgs e)
        {
            int rc = dataGridView1.Rows.Count;

            db.openConnection();

            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var ks = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            dataGridView1.Rows.RemoveAt(selectedRowIndex);
            dataGridView1.Refresh();
            var changeQuery = $"delete from [СОТРУДНИКИ] where [Код сотрудника] = '{ks}'";
            var command = new SqlCommand(changeQuery,db.GetConnection());
            command.ExecuteNonQuery();

            db.closeConnection();

            int rcc = dataGridView1.Rows.Count;
            label9.Text = $"Количество строк: {rcc}";
        }
    }
}
