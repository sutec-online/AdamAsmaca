using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1adam_asmaca
{
    public partial class OyunAyar : Form
    {
        public OyunAyar()
        {
            InitializeComponent();
        }

        private void RandomButon(object sender, EventArgs e)
        {
            OyunForm oyunform = new OyunForm("random");
            oyunform.Show();
            Hide();
        }

        private void UzunlukButon(object sender, EventArgs e)
        {
            OyunForm oyunform = new OyunForm(textBox1.Text);
            oyunform.Show();
            Hide();
        }
    }
}
