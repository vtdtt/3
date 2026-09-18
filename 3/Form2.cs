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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;
namespace _3
{
    public partial class Form2 : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=login_system;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string tendn = textBox2.Text.Trim();
            string mk = textBox3.Text;
            string xacnhanmk = textBox4.Text;
            if (email == "" || tendn == "" || mk == "" || xacnhanmk == "")
            {
                MessageBox.Show("Vui long nhap thong tin day du");
                return;
            }
            if (mk != xacnhanmk)
            {
                MessageBox.Show("mat khau khong trung khop");
                return;
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(mk);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO users
                        (username, email, password_hash)
                        VALUES
                        (@username, @email, @password_hash)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@username", tendn);
                        cmd.Parameters.AddWithValue("@password_Hash", passwordHash);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Dang ky thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}

