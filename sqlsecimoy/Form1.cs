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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MVCC220; Initial Catalog = secim; Integrated Security=True");
            SqlCommand komut;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("INSERT INTO TBLParti (ILCEAD,AParti,BParti,CParti,DParti) VALUES (@ILCEAD,@AParti,@BParti,@CParti,@DParti)", baglanti);
            komut.Parameters.AddWithValue("@ILCEAD",textBox1.Text);
            komut.Parameters.AddWithValue("@AParti", textBox2.Text);
            komut.Parameters.AddWithValue("@BParti", textBox3.Text);
            komut.Parameters.AddWithValue("@CParti", textBox4.Text);
            komut.Parameters.AddWithValue("@DParti", textBox5.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("oy girişi başarıyla tamamlanmıştır");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr= new Form2();
            fr.Show();
            // this hide
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
