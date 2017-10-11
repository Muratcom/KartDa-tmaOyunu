using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Poker_Oyun_Sinav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] kartlar = new string[52];
        string[] oyuncu1 = new string[13];
        string[] oyuncu2 = new string[13];
        string[] oyuncu3 = new string[13];
        string[] oyuncu4 = new string[13];
        int eleman_sayisi;
        int sayac = 0;
        string bilgi;

        public void bilgilendir()
        {
            if (sayac==0)
            {
                bilgi = "Elinizde hiçbirşey yok";
            }

            if (sayac == 1)
            {
                bilgi = "Elinizde ikili var";
            }

            if (sayac == 2)
            {
                bilgi = "Elinizde üçlü var";
            }

            if (sayac == 3)
            {
                bilgi = "Elinizde dörtlü var";
            }

            if (sayac == 4)
            {
                bilgi = "Elinizde beşli var";
            }


        }


        public  string [] olustur()
        {
            for (int i = 0; i < 4; i++)
            {
                string renk = "";
                switch (i)
                {
                    case 0:
                        renk = "Karo";
                        break;
                    case 1:
                        renk = "Kupa";
                        break;
                    case 2:
                        renk = "Maça";
                        break;
                    case 3:
                        renk = "Sinek";
                        break;
                }

                for (int j = 1; j <= 13; j++)
                {
                    string numara = (j + 1).ToString();
                    switch (numara)
                    {
                        case ("11"):
                            numara = "Vale";
                            break;
                        case ("12"):
                            numara = "Kız";
                            break;
                        case ("13"):
                            numara = "Papaz";
                            break;
                        case ("14"):
                            numara = "As";
                            break;
                        default:
                            numara = (j + 1).ToString();
                            break;
                    }
                    kartlar[(i * 13) - 1 + j] = renk + " " + numara;
                }
            }
            return kartlar;
        }



       public void temizle(int indis)
        {
            for (int i = indis; i < kartlar.Length - 1; i++)
            {
                kartlar[i] = kartlar[i + 1];
            }
            Array.Resize(ref kartlar, kartlar.Length - 1);
        }

        public void ekranTemizle()
        {
            label6.Visible = false;
            listBox4.Visible = false;

            label3.Visible = false;
            listBox3.Visible = false;

            label2.Visible = false;
            listBox2.Visible = false;

            label4.Visible = false;
            listBox1.Visible = false;
        }


        public void kar()
        {
            Random rasgele = new Random();
            string[] array = new string[52];

            for (int i = 0; i < array.Length; i++)
            {
                int index = rasgele.Next(0, kartlar.Length);
                array[i] = kartlar[index];
                temizle(index);
            }
            kartlar = array;
            listBox5.Items.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                listBox5.Items.Add(kartlar[i]);
            }
            eleman_sayisi = listBox5.Items.Count;
            label10.Text = eleman_sayisi.ToString();

        }

        public void dagit()
        {
            for (int i = 0; i < 13; i++)
            {
                oyuncu1[i] = kartlar[i];
                oyuncu2[i] = kartlar[i + 13];
                oyuncu3[i] = kartlar[i + 26];
                oyuncu4[i] = kartlar[i + 39];
            }


            Array.Sort(oyuncu1);
            Array.Sort(oyuncu2);
            Array.Sort(oyuncu3);
            Array.Sort(oyuncu4);

            btnKaristir.Enabled = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    listBox4.Items.AddRange(oyuncu1);
                    listBox3.Items.AddRange(oyuncu2);
                    for (int i = 0; i <listBox4.Items.Count; i++)
                    {
                        for (int j = 0; j <listBox5.Items.Count; j++)
                        {
                            if (listBox4.Items[i]==listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                            if (listBox3.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }
                        }

                    }
  
                    int kalan = listBox5.Items.Count;
                    label10.Text = kalan.ToString();

                    break;

                case 1:
                    listBox4.Items.AddRange(oyuncu1);
                    listBox3.Items.AddRange(oyuncu2);
                    listBox2.Items.AddRange(oyuncu3);

                    for (int i = 0; i < listBox4.Items.Count; i++)
                    {
                        for (int j = 0; j < listBox5.Items.Count; j++)
                        {
                            if (listBox4.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                            if (listBox3.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                            if (listBox2.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }
                        }

                    }

                    int kalan2 = listBox5.Items.Count;
                    label10.Text = kalan2.ToString();

                    break;

                case 2:
                    listBox4.Items.AddRange(oyuncu1);
                    listBox3.Items.AddRange(oyuncu2);
                    listBox2.Items.AddRange(oyuncu3);
                    listBox1.Items.AddRange(oyuncu4);

                    for (int i = 0; i < 13; i++)
                    {
                        for (int j = 0; j < listBox5.Items.Count; j++)
                        {
                            if (listBox4.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                            if (listBox3.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                            if (listBox2.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }
                            if (listBox1.Items[i] == listBox5.Items[j])
                            {
                                listBox5.Items.RemoveAt(j);
                            }

                        }

                    }

                    int kalan3 = listBox5.Items.Count;
                    label10.Text = kalan3.ToString();
                    break;

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBilgi.Enabled = false;
            btnDagit.Enabled = false;
            btnKaristir.Enabled = false;
            comboBox1.Enabled = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            btnDagit.Enabled = false;
            //comboBox1.SelectedIndex = 0;
            ekranTemizle();
            kartlar = olustur();
            for (int i = 0; i < 52; i++)
            {
                listBox5.Items.Add(kartlar[i]);
            }

            eleman_sayisi = listBox5.Items.Count;
            label10.Text = eleman_sayisi.ToString();
        }

        private void btnKaristir_Click(object sender, EventArgs e)
        {
            kar();
            btnDagit.Enabled = true;
            btnKaristir.Enabled = false;
        }

        private void btnDagit_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();



            dagit();
    
            btnKaristir.Enabled = true;
            btnDagit.Enabled = false;

        }
        
         private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            if (comboBox1.SelectedIndex==0)
            {
                label13.Text = "";
                label14.Text = "";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label14.Text = "";

            }

            ekranTemizle();


            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    label6.Visible = true;
                    listBox4.Visible = true;
                    label11.Visible = true;
                    label11.Text = "";

                    label3.Visible = true;
                    listBox3.Visible = true;
                    label12.Visible = true;
                    label12.Text = "";
                    break;

                case 1:

                    label6.Visible = true;
                    listBox4.Visible = true;
                    label11.Visible = true;
                    label11.Text = "";

                    label3.Visible = true;
                    listBox3.Visible = true;
                    label12.Visible = true;
                    label12.Text = "";

                    label2.Visible = true;
                    listBox2.Visible = true;
                    label13.Visible = true;
                    label13.Text = "";

                    break;


                case 2:

                    label6.Visible = true;
                    listBox4.Visible = true;
                    label11.Visible = true;
                    label11.Text = "";

                    label3.Visible = true;
                    listBox3.Visible = true;
                    label12.Visible = true;
                    label12.Text = "";

                    label2.Visible = true;
                    listBox2.Visible = true;
                    label13.Visible = true;
                    label13.Text = "";

                    label4.Visible = true;
                    listBox1.Visible = true;
                    label14.Visible = true;
                    label14.Text = "";

                    break;



            }

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            {
                if (sonuc == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult karsilama = new DialogResult();
            MessageBox.Show("Hoşgeldiniz!!! Oyuna başlamak için öncelikle oyuncu sayısı seçmeyi unutmayınız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (karsilama == DialogResult.OK)
            {
                
            }

            btnBilgi.Enabled = true;
            btnDagit.Enabled = true;
            btnKaristir.Enabled = true;
            comboBox1.Enabled = true;

            button1.Visible = false;
        }

        private void btnBilgi_Click(object sender, EventArgs e) //5 kagıt dagıtılıyomus gibi bilgilendirme verim mantığını tam bilmiyorum oyunun amac ekrana ellerdeki kartların durumunu basabilmekti.
        {
            if (comboBox1.SelectedIndex==0)
            {
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = false;
                label14.Visible = false;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = false;


            }
            if (comboBox1.SelectedIndex == 2)
            {
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;

            }

          
            
            foreach (string  item in listBox4.Items)
            {
                string[] deger = item.Split(' ');

                for (int i = 0; i < oyuncu1.Length; i++)
                {
                    for (int j = 1; j < deger.Length; j+=2)
                    {
                        if (oyuncu1[i].Contains(deger[j]))
                        {
                            sayac++;
                        }
                    }
                }
                

                bilgilendir();
                label11.Text = bilgi;
                sayac = 0;
            }


            foreach (string item in listBox3.Items)
            {
                string[] deger = item.Split(' ');

                for (int i = 0; i < oyuncu1.Length; i++)
                {
                    for (int j = 1; j < deger.Length; j += 2)
                    {
                        if (oyuncu1[i].Contains(deger[j]))
                        {
                            sayac++;
                        }
                    }
                }


                bilgilendir();
                label12.Text = bilgi;
                sayac = 0;
            }


            foreach (string item in listBox2.Items)
            {
                string[] deger = item.Split(' ');

                for (int i = 0; i < oyuncu1.Length; i++)
                {
                    for (int j = 1; j < deger.Length; j += 2)
                    {
                        if (oyuncu1[i].Contains(deger[j]))
                        {
                            sayac++;
                        }
                    }
                }


                bilgilendir();
                label13.Text = bilgi;
                sayac = 0;
            }



            foreach (string item in listBox1.Items)
            {
                string[] deger = item.Split(' ');

                for (int i = 0; i < oyuncu1.Length; i++)
                {
                    for (int j = 1; j < deger.Length; j += 2)
                    {
                        if (oyuncu1[i].Contains(deger[j]))
                        {
                            sayac++;
                        }
                    }
                }


                bilgilendir();
                label14.Text = bilgi;
                sayac = 0;
            }


        }
    }
}


