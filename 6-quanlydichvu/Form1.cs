using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace _6_quanlydichvu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dulieu = @"Data Source=LAPTOP-QJB0H525;Initial Catalog=baitaplon;Integrated Security=True;Encrypt=False";
        string sql;
        SqlConnection ketnoi;
        SqlCommand th;
        SqlDataAdapter da;
        DataTable dt;


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            hienthi();
        }
        public void hienthi()
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            sql = "select *from quanlydichvu";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            SqlDataAdapter da = new SqlDataAdapter(th);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int sodong = -1;
            sodong = dataGridView2.CurrentCell.RowIndex;
            if (sodong >= 0)
            {
                txtdv.Text = dataGridView2[0, sodong].Value.ToString();
                txttendv.Text = dataGridView2[1, sodong].Value.ToString();
                txtmota.Text = dataGridView2[2, sodong].Value.ToString();
                txtgia.Text = dataGridView2[3, sodong].Value.ToString();
                cbodanhmuc.Text = dataGridView2[4, sodong].Value.ToString();
                txtsoluong.Text = dataGridView2[5, sodong].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"insert into quanlydichvu values( @iddv,@tendv,@mota,@gia,@danhmuc,@soluong)";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            th.Parameters.AddWithValue("@iddv", txtdv.Text);
            th.Parameters.AddWithValue("@tendv", txttendv.Text);
            th.Parameters.AddWithValue("@mota", txtmota.Text);
            th.Parameters.AddWithValue("@gia", int.Parse(txtgia.Text));
            th.Parameters.AddWithValue("@danhmuc", cbodanhmuc.Text);
            th.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text));
            if (int.Parse(txtsoluong.Text) > 50000)
            {
                MessageBox.Show("số lượng không vuot qua 500000");
                return;
            }
            th.ExecuteNonQuery();
            MessageBox.Show("thêm thành công");
              
            hienthi();
            ketnoi.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"update quanlydichvu set iddv=@iddv,tendv=@tendv,mota=@mota,gia=@gia,danhmuc=@danhmuc,soluong=@soluong where iddv=@iddv";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            th.Parameters.AddWithValue("@iddv", txtdv.Text);
            th.Parameters.AddWithValue("@tendv", txttendv.Text);
            th.Parameters.AddWithValue("@mota", txtmota.Text);
            th.Parameters.AddWithValue("@gia", int.Parse(txtgia.Text));
            th.Parameters.AddWithValue("@danhmuc", cbodanhmuc.Text);
            th.Parameters.AddWithValue("@soluong", int.Parse(txtsoluong.Text));
            th.ExecuteNonQuery();
            MessageBox.Show("sửa thành công");
            hienthi();
            ketnoi.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"delete quanlydichvu where iddv='" + txtdv.Text + "'";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            if(MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                th.ExecuteNonQuery();
            }

            ketnoi.Close();
            hienthi();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection ketnoi = new SqlConnection(dulieu);
            ketnoi.Open();
            sql = @"select *from quanlydichvu where iddv ='" + txttimkiem.Text + "'";
            SqlCommand th = new SqlCommand(sql, ketnoi);
            SqlDataAdapter da = new SqlDataAdapter(th);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            ketnoi.Close();



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
