using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _3
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=login_system;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tendn = textBox1.Text.Trim();
            string mk = textBox2.Text;

            if (tendn == "" || mk == "")
            {
                MessageBox.Show("Vui long nhap day du tai khoan va mat khau");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                SELECT password_hash
                FROM users
                WHERE username = @username
                AND is_active = 1";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", tendn);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Tai khoan khong ton tai");
                            return;
                        }

                        string passwordHash = result.ToString();

                        bool dungMatKhau =
                            BCrypt.Net.BCrypt.Verify(mk, passwordHash);

                        if (dungMatKhau)
                        {
                            MessageBox.Show("Dang nhap thanh cong");
                            Form3 form3 = new Form3();
                            form3.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Sai tai khoan hoac mat khau");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi: " + ex.Message);
                }
                    
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}