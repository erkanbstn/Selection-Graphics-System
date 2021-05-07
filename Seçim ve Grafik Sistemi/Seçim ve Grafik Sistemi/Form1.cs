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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection adres = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBSeçimProje;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand komut = new SqlCommand("Select İlçeAd From Tblİlçe", adres);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0]);
            }
            adres.Close();


            adres.Open();
            SqlCommand komut2 = new SqlCommand("Select Sum(AParti),Sum(BParti),sum(CParti),sum(DParti),sum(EParti) from Tblİlçe", adres);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr[4]);
              
            }
            adres.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand komut = new SqlCommand("select * from Tblİlçe where İlçeAd=@p1", adres);
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString()); 
                progressBar2.Value = int.Parse(dr[3].ToString()); 
                progressBar5.Value = int.Parse(dr[4].ToString()); 
                progressBar4.Value = int.Parse(dr[5].ToString()); 
                progressBar3.Value = int.Parse(dr[6].ToString());

                label7.Text = dr[2].ToString();
                label10.Text = dr[3].ToString();
                label9.Text = dr[4].ToString();
                label8.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();
            }
            adres.Close();
        }
    }
}
