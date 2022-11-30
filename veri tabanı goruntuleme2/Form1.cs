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

namespace veri_tabanı_goruntuleme2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=ERCANMONSTER\\ERCANSERVER;Initial Catalog=SORU;Integrated Security=True");
        private void goster()
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Select * from OgrencıKayıt", connect);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["AdSoyad"].ToString();
                ekle.SubItems.Add (oku["Sınıf"].ToString());
                ekle.SubItems.Add(oku["Okul"].ToString());
                ekle.SubItems.Add(oku["Şehir"].ToString());
                ekle.SubItems.Add(oku["CINSIYET"].ToString());
                listView1.Items.Add(ekle);
            }
            connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            goster();
        }
    }
}
