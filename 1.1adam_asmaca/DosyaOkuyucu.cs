using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _1._1adam_asmaca
{
    public class DosyaOkuyucu
    {
        public string dosyayolu { get; set; }
        public FileStream filestream;
        public StreamReader streamreader;
        public static List<string> kelimeler;
        public static List<string> skorlar;

        public DosyaOkuyucu(string dosyayolu)
        {
            this.dosyayolu = dosyayolu;
        }

        public void DosyayiAc()
        {
            filestream = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            streamreader = new StreamReader(filestream, Encoding.GetEncoding("iso-8859-9"));
        }

        public List<string> KelimeListesi()
        {
            kelimeler = new List<string>();

            while (true)
            {
                string satir = streamreader.ReadLine();

                if (satir == null)
                    break;

                kelimeler.Add(satir);
            }

            return kelimeler;
        }

        public List<string> SkorListesi()
        {
            skorlar = new List<string>();

            while (true)
            {
                string satir = streamreader.ReadLine();

                if (satir == null)
                    break;

                skorlar.Add(satir);
            }

            return skorlar;
        }

        private static bool KelimeKontrolcusu(string kelime)
        {
            for (int i = 0; i < kelimeler.Count; i++)
            {
                if (kelime == kelimeler[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool KelimeEkle(string kelime)
        {
            if (KelimeKontrolcusu(kelime))
            {
                return false;
            }

            kelimeler.Add(kelime);

            return true;
        }

        public bool KelimeSil(string kelime)
        {
            if (KelimeKontrolcusu(kelime) == false)
            {
                return false;
            }

            kelimeler.Remove(kelime);

            return true;
        }

        private static void DosyaGuncelle(string dosyayolu)
        {
            File.Delete(dosyayolu);
            FileStream fs = new FileStream(dosyayolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < kelimeler.Count; i++)
            {
                sw.WriteLine(kelimeler[i]);
            }

            sw.Close();
            fs.Close();
        }

        public void SkorGuncelle(string dosyayolu)
        {
            File.Delete(dosyayolu);
            FileStream fs = new FileStream(dosyayolu, FileMode.Create);
            fs.Close();
        }

        public void SkorBaglantiKapat(string dosyayolu)
        {
            streamreader.Close();
            filestream.Close();
            if (dosyayolu != "")
                SkorGuncelle(dosyayolu);
        }

        public void SkorEkle(string dosyayolu, string deger)
        {
            FileStream fs = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(deger);
            sw.Close();
            fs.Close();
        }

        public void BaglantiKapat(string dosyayolu)
        {
            streamreader.Close();
            filestream.Close();
            if (dosyayolu != "")
                DosyaGuncelle(dosyayolu);
        }
    }
}
