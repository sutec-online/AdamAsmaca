using System;
using System.Windows.Forms;

namespace _1._1adam_asmaca
{
    public partial class OyunForm : Form
    {
        string kelime;
        int hak_sayisi;

        public OyunForm(string veri)
        {
            InitializeComponent();

            if (veri == "random")
            {
                KelimeSecici kelimesec = new KelimeSecici();
                kelimesec.KelimeGetir();
                kelime = kelimesec.kelime;
                hak_sayisi = kelimesec.HakSayisiHesapla();
            }
            else
            {
                KelimeSecici kelimesec = new KelimeSecici(Convert.ToInt32(veri));
                kelimesec.KelimeGetir();
                kelime = kelimesec.kelime;
                hak_sayisi = kelimesec.HakSayisiHesapla();
            }

            if (kelime == null)
            {
                MessageBox.Show("Veritabanında Kelime Bulunamadı!");
            }
        }

        private void OyunForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < kelime.Length+1; i++)
            {
                var panel = Controls[1];
                var textbox = panel.Controls["textbox" + i];
                textbox.Visible = true;
            }

            label4.Text = hak_sayisi.ToString();
        }

        private void TahminBox(object sender, EventArgs e)
        {
            bool durum = false;

            for (int i = 0; i < kelime.Length; i++)
            {
                if (kelime[i].ToString() == textBox11.Text)
                {
                    var panel = Controls[1];
                    int tb = i + 1;
                    var textbox = panel.Controls["textbox" + tb];
                    textbox.Text = kelime[i].ToString();
                    durum = true;
                }
            }

            if (durum == false)
            {
                if (!listBox1.Items.Contains(textBox11.Text))
                {
                    label4.Text = (Convert.ToInt32(label4.Text) - 1).ToString();
                    listBox1.Items.Add(textBox11.Text);
                }
            }

            if (Convert.ToInt32(label4.Text) == 0)
            {
                MessageBox.Show("HAKKINIZ BİTTİ! SKORUNUZ KAYDEDİLİYOR.");
                DosyaOkuyucu skorekle = new DosyaOkuyucu("C:/adam_asmaca/skor.txt");

                float skor = ((hak_sayisi * 20) * 30) / 100;
                skorekle.SkorEkle("C:/adam_asmaca/skor.txt", skor.ToString());
            }

            int sayac = 0;
            for (int i = 1; i < kelime.Length+1; i++)
            {
                var panel = Controls[1];
                var textbox = panel.Controls["textbox" + i];
                string harf = textbox.Text;

                if (harf != "")
                {
                    sayac++;
                }
            }

            if (sayac == kelime.Length)
            {
                MessageBox.Show("BAŞARDINIZ! SKORUNUZ KAYDEDİLİYOR.");
                DosyaOkuyucu skorekle = new DosyaOkuyucu("C:/adam_asmaca/skor.txt");

                float skor = ((hak_sayisi * 20) * 30) / 100;
                skorekle.SkorEkle("C:/adam_asmaca/skor.txt", skor.ToString());
            }
            else
            {
                sayac = 0;
            }

            durum = false;
        }
    }
}
