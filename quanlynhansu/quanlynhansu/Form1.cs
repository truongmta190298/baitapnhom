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

namespace quanlynhansu
{
    public partial class f1 : Form
    {
        public f1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CE6UIQC\SQLEXPRESS;Initial Catalog=Bai1_baitapnhom;Integrated Security=True");
            string sqlSelect = "Select * from BangDangNhap where TaiKhoan = N'" + textBox1.Text + "'and MatKhau = N'" + textBox2.Text+"'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()==true)
            {
                this.Hide();
                Form main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Bạn đăng nhập không thành công");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            conn.Close();
        }
    }
}
