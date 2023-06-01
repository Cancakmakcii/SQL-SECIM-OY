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

namespace sqlsecimoy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MVCC220; Initial Catalog = secim; Integrated Security=True");
        SqlCommand komut;
        int a, b, c, d, toplam = 0, geneltoplam = 0;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLParti where ILCEAD=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr= komut.ExecuteReader();

            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());

                a = Convert.ToInt32(progressBar1.Value);
                b = Convert.ToInt32(progressBar2.Value);
                c = Convert.ToInt32(progressBar3.Value);
                    d = Convert.ToInt32(progressBar4.Value);

                label8.Text = dr[2].ToString();
                label9.Text = dr[3].ToString();
                label10.Text = dr[4].ToString();
                label11.Text = dr[5].ToString();


                toplam = (a + b + c + d);
                label2.Text= toplam.ToString();








            }
            baglanti.Close();











        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("select ILCEAD from TBLParti", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(AParti), SUM(BParti), SUM(CParti), SUM(DParti) from TBLParti", baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                Chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
                Chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
                Chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
                Chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
                for (int i = 0; i < 4; i++)
                {
                    geneltoplam += Convert.ToInt32(dr2[i]);
                    label3.Text=geneltoplam.ToString();
                }
            }
            baglanti.Close();

        }
    }
}
