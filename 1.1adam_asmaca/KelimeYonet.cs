using System.Collections.Generic;
using System.Windows.Forms;

namespace _1._1adam_asmaca
{
    public partial class KelimeYonet : Form
    {
        public DosyaOkuyucu dosyaoku;

        public KelimeYonet()
        {
            InitializeComponent();
        }

        private void KelimeYonet_Load(object sender, System.EventArgs e)
        {
            dosyaoku = new DosyaOkuyucu("C:/adam_asmaca/kelimeler.txt");
            dosyaoku.DosyayiAc();

            List<string> kelimeListesi = dosyaoku.KelimeListesi();

            for (int i = 0; i < kelimeListesi.Count; i++)
            {
                listBoxKelimeler.Items.Add(kelimeListesi[i]);
            }
        }

        private void KelimeEkleButon(object sender, System.EventArgs e)
        {
            string kelimeAl = textBoxKelime.Text;

            if (dosyaoku.KelimeEkle(kelimeAl))
            {
                MessageBox.Show("Kelime Başarıyla Eklendi.");
                listBoxKelimeler.Items.Add(kelimeAl);
            }
            else
            {
                MessageBox.Show("Kelime Zaten Mevcut!");
            }

        }

        private void KelimeSilButon(object sender, System.EventArgs e)
        {
            string kelime = listBoxKelimeler.SelectedItem.ToString();

            if(dosyaoku.KelimeSil(kelime))
            {
                MessageBox.Show("Kelime Başarıyla Silindi.");
                listBoxKelimeler.Items.Remove(kelime);
            }
            else
            {
                MessageBox.Show("Kelime Dosya İçerisinde Bulunmamaktadır.");
            }
        }

        private void FormKapat(object sender, FormClosingEventArgs e)
        {
            dosyaoku.BaglantiKapat("C:/adam_asmaca/kelimeler.txt");
        }
    }
}
