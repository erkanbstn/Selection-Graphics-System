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
namespace Seçim_ve_Grafik_Sistemi
{
    public partial class FrmSeçim : Form
    {
        public void listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tblİlçe", adres);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.DataSource = table;
        }
        public FrmSeçim()
        {
            InitializeComponent();
        }
        SqlConnection adres = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBSeçimProje;Integrated Security=True");
        private void FrmSeçim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            adres.Open();
            SqlCommand ekle = new SqlCommand("insert into Tblİlçe (İlçeAd) values (@p1)", adres);
            ekle.Parameters.AddWithValue("@p1", textBox1.Text);
            ekle.ExecuteNonQuery();
            adres.Close();
            MessageBox.Show("İlçe Başarıyla Girildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand ekle = new SqlCommand(" update Tblİlçe set AParti=@p1,BParti=@p2,CParti=@p3,DParti=@p4,EParti=@p5 where İlçeAd=@p6", adres);
            ekle.Parameters.AddWithValue("@p1", textBox4.Text);
            ekle.Parameters.AddWithValue("@p2", textBox3.Text);
            ekle.Parameters.AddWithValue("@p3", textBox2.Text);
            ekle.Parameters.AddWithValue("@p4", textBox5.Text);
            ekle.Parameters.AddWithValue("@p5", textBox6.Text);
            ekle.Parameters.AddWithValue("@p6", textBox1.Text);
            ekle.ExecuteNonQuery();
            adres.Close();
            MessageBox.Show("Oylar Başarıyla Girildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand ekle = new SqlCommand(" update Tblİlçe set İlçeAd=@p1 where İlçeID=@p2", adres);
            ekle.Parameters.AddWithValue("@p1",textBox1.Text);
            ekle.Parameters.AddWithValue("@p2",textBox7.Text);
            ekle.ExecuteNonQuery();
            adres.Close();
            MessageBox.Show("İlçe Başarıyla Güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            MessageBox.Show("Parametreler Başarıyla Temizlendi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
