using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _1._1adam_asmaca
{
    public partial class SkorListesi : Form
    {
        DosyaOkuyucu dosyadanoku;

        public SkorListesi()
        {
            InitializeComponent();
        }

        private void SkorListesi_Load(object sender, EventArgs e)
        {
            dosyadanoku = new DosyaOkuyucu("C:/adam_asmaca/skor.txt");
            dosyadanoku.DosyayiAc();
            List<string> skorlar = dosyadanoku.SkorListesi();

            for (int i = 0; i < skorlar.Count; i++)
            {
                listBox1.Items.Add(skorlar[i]);
            }
        }

        private void SkorSıfırlaButon(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dosyadanoku.SkorBaglantiKapat("C:/adam_asmaca/skor.txt");
        }

        private void SkorKapat(object sender, FormClosingEventArgs e)
        {
            dosyadanoku.SkorBaglantiKapat("");
        }
    }
}
