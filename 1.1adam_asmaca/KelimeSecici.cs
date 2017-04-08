using System;
using System.Collections.Generic;

namespace _1._1adam_asmaca
{
    class KelimeSecici
    {
        int uzunluk = 0;
        public string kelime { get; set; }

        public KelimeSecici()
        {

        }

        public KelimeSecici(int uzunluk)
        {
            this.uzunluk = uzunluk;
        }

        public void KelimeGetir()
        {
            if (uzunluk == 0)
            {
                DosyaOkuyucu dosyadanoku = new DosyaOkuyucu("C:/adam_asmaca/kelimeler.txt");
                dosyadanoku.DosyayiAc();
                List<string> kelimelistesi = dosyadanoku.KelimeListesi();

                Random rn = new Random();
                int random = rn.Next(0, kelimelistesi.Count);

                kelime = kelimelistesi[random];

                dosyadanoku.BaglantiKapat("");
            }
            else
            {
                DosyaOkuyucu dosyadanoku = new DosyaOkuyucu("C:/adam_asmaca/kelimeler.txt");
                dosyadanoku.DosyayiAc();
                List<string> kelimelistesi = dosyadanoku.KelimeListesi();

                for (int i = 0; i < kelimelistesi.Count; i++)
                {
                    if (kelimelistesi[i].Length == uzunluk)
                    {
                        kelime = kelimelistesi[i].Trim();
                        break;
                    }
                }

                dosyadanoku.BaglantiKapat("");
            }
        }

        public int HakSayisiHesapla()
        {
            return kelime.Length + 2;
        }


    }
}
