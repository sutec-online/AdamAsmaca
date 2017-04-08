using System;
using System.Windows.Forms;

namespace _1._1adam_asmaca
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void KelimeYonetButon(object sender, EventArgs e)
        {
            KelimeYonet kelimeyonetform = new KelimeYonet();
            kelimeyonetform.Show();
        }

        private void SkorButon(object sender, EventArgs e)
        {
            SkorListesi skorliste = new SkorListesi();
            skorliste.Show();
        }

        private void OyunBaslaButon(object sender, EventArgs e)
        {
            OyunAyar oyunayar = new OyunAyar();
            oyunayar.Show();
            Hide();
        }
    }
}
