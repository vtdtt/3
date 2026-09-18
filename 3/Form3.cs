using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _3
{
    public partial class Form3 : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=QuanLyTacGia;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("nam");
            comboBox1.Items.Add("nu");
            comboBox1.Items.Add("khac");
            LoadTacGia();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string matg = textBox1.Text.Trim();
            string hovaten = textBox2.Text.Trim();
            DateTime ngaysinh = dateTimePicker1.Value;
            string gioitinh = comboBox1.Text.Trim();
            string sdt = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string diachi = textBox5.Text.Trim();
            if (matg == "" || hovaten == "" || gioitinh == ""
                || sdt == "" || email == "" || diachi == "")
            {
                MessageBox.Show("Nhap day du thong tin");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO TacGia
        (
            MaTacGia,
            HoTen,
            NgaySinh,
            GioiTinh,
            SoDienThoai,
            Email,
            DiaChi
        )
        VALUES
        (
            @MaTacGia,
            @HoTen,
            @NgaySinh,
            @GioiTinh,
            @SoDienThoai,
            @Email,
            @DiaChi
        )";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTacGia", matg);
                        cmd.Parameters.AddWithValue("@HoTen", hovaten);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                        cmd.Parameters.AddWithValue("@SoDienThoai", sdt);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@DiaChi", diachi);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm tác giả thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    LoadTacGia();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi khi thêm tác giả: " + ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon tac gia can sua");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("khong duoc de trong o nao");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string maTacGiaCu =
                dataGridView1.CurrentRow.Cells["MaTacGia"]
                .Value.ToString();
                    string sql = @"UPDATE TacGia
        SET
            MaTacGia = @MaTacGia,
            HoTen = @HoTen,
            NgaySinh = @NgaySinh,
            GioiTinh = @GioiTinh,
            SoDienThoai = @SoDienThoai,
            Email = @Email,
            DiaChi = @DiaChi
        WHERE MaTacGia = @MaTacGiaCu";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTacGiaCu", maTacGiaCu);
                        cmd.Parameters.AddWithValue("@MaTacGia", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTen", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", comboBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", textBox5.Text.Trim());
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Cập nhật thông tin thành công!");
                            LoadTacGia();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy tác giả!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tác giả cần xóa!");
                return;
            }


            string maTacGia = dataGridView1.CurrentRow.Cells["MaTacGia"].Value.ToString();


            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tác giả " + maTacGia + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }


            string sql = "DELETE FROM TacGia WHERE MaTacGia = @MaTacGia";

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);

                    conn.Open();

                    int soDongXoa = cmd.ExecuteNonQuery();

                    if (soDongXoa > 0)
                    {
                        MessageBox.Show(
                            "Đã xóa tác giả khỏi Database!");
                        LoadTacGia();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tác giả trong Database!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xóa: " + ex.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void LoadTacGia()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY MaTacGia) AS STT,
                    MaTacGia,
                    HoTen,
                    NgaySinh,
                    GioiTinh,
                    SoDienThoai,
                    Email,
                    DiaChi
                FROM TacGia
                ORDER BY MaTacGia";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    // Xóa các cột tạo thủ công trước đó
                    dataGridView1.Columns.Clear();

                    // Cho DataGridView tự tạo cột theo DataTable
                    dataGridView1.AutoGenerateColumns = true;

                    // Đưa dữ liệu lên DataGridView
                    dataGridView1.DataSource = dt;

                    // Không cho sửa trực tiếp trên bảng
                    dataGridView1.ReadOnly = true;

                    // Cho phép chọn cả dòng
                    dataGridView1.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    // Không cho thêm dòng mới
                    dataGridView1.AllowUserToAddRows = false;

                    // Tự điều chỉnh độ rộng
                    dataGridView1.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi khi tải dữ liệu: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}

