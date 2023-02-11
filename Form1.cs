////////////////////////////////////////////////

//         Made By Gytis Mockevičius          //

////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ScatterPlot
{
    public partial class Form1 : Form           //pagrindine klase atsakinga uz visos programos veikla
    {
        Generate GeneratePlot = new Generate();
        List<Taskas> Taskai;
        List<Trikampis> Trikampiai = new List<Trikampis>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, EventArgs e)                     //generuojame taskus
        {
            GeneratePlot.ClearLists();
            int n = int.Parse(Amount.Text);
            {
                for (int i = 0; i < n; i++)                                                //ciklas generuojantis taskus
                {
                    int Rx = pictureBox1.Width, Ry = pictureBox1.Height;            //nustatome max W ir H
                    GeneratePlot.Gen(ref Rx, ref Ry);                               //F-ja kuri generuoja taska
                }
                Piesiam(GeneratePlot.GetTaskai(), null, null, null, null);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //f-ja skirta trackinti kokiose koordinates yra pele
        {
            Bitmap dummy = (Bitmap)pictureBox1.Image;
            if (dummy == null) return;
            Color spalva = dummy.GetPixel(e.X, e.Y);
            if (spalva.R == Color.White.R && spalva.G == Color.White.G && spalva.B == Color.White.B)
                label1.Text = null;
            else label1.Text = "X=" + e.X.ToString() + " Y=" + e.Y.ToString();
        }
        private void DelauneyTiangulation(object sender, EventArgs e)   //f-ja skaiciuojanti delauney trikampius
        {
            DelauneyTriangulation.Enabled = false;  //isjungiam mygtuka kai pradedam skaiciuoti
            Taskai = GeneratePlot.GetTaskai();      //susirenkam taskus
            Thread Th = new Thread(Trianguliacija); //padarom nauja thread kuriame skaiciuosime
            Th.Start();                             //pradedam skaiciuoti
        }

        delegate void piesiam0cb(List<Taskas> Taskai, List<Trikampis> Trikampiai, Trikampis ETrik, Taskas ETask); //call back
        private void Piesiam0(List<Taskas> Taskai, List<Trikampis> Trikampiai, Trikampis ETrik, Taskas ETask)     //f-ja kuri gauna atsakyma is naujo thread
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new piesiam0cb(Piesiam0), new object[] { Taskai, Trikampiai, ETrik, ETask });
            }
            else Piesiam(Taskai, Trikampiai, ETrik, ETask, null);
        }

        delegate void EnableCTLCB(Button p, bool pEnable);  //call back
        private void EnableCTL(Button p, bool pEnable)      //f-ja kuri gauna atsakymus is kito thread
        {
            if (p.InvokeRequired)
            {
                p.Invoke(new EnableCTLCB(EnableCTL), new object[] { p, pEnable });
            }
            else p.Enabled = pEnable;
        }

        private void Piesiam(List<Taskas> Taskai, List<Trikampis> Trikampiai, Trikampis ETrik, Taskas ETask,Taskas Apsk)    //f-ja kuri piesia turimus objektus
        {
            Bitmap kbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);    //laikome taskus bitmape
            Graphics kgr = Graphics.FromImage(kbmp);                            //pasakome kur laikoma bus nuotrauka
            kgr.Clear(Color.White);                                             //Nudazome kanvasa baltai
            Brush brsh = new SolidBrush(Color.Red);                             //brush kuris nurodo tasku spalva

            foreach (Taskas T in Taskai)                                        //piesiam visus taskus
            {
                kgr.FillEllipse(brsh, T.X, T.Y, 7, 7);
            }
            if (Trikampiai != null)                                             //jeigu turim trikampius tai piesiam
                foreach (Trikampis Trik in Trikampiai)                          //piesiam trikampius
                {
                    PiesTrik(kgr, brsh, Trik);
                }
            if(ETrik!=null)                                                     //tikrinamojo trikampio piesimas (del grozio)
            {
                kgr.FillEllipse(Brushes.Blue, ETrik.Tas1.X, ETrik.Tas1.Y, 7, 7);
                kgr.FillEllipse(Brushes.Blue, ETrik.Tas2.X, ETrik.Tas2.Y, 7, 7);
                kgr.FillEllipse(Brushes.Blue, ETrik.Tas3.X, ETrik.Tas3.Y, 7, 7);
            }
            if(ETask!=null)                                                     //tirkinamojo tasko piesimas (del grozio)
            {
                kgr.FillEllipse(Brushes.Cyan, ETask.X, ETask.Y, 14, 14);
            }
            if(Apsk!=null)
            {
                kgr.DrawEllipse(new Pen(Brushes.Blue), Apsk.X - Apsk.X, Apsk.Y - Apsk.X, Apsk.X * 2, Apsk.X * 2);
            }
            kgr.Dispose();  //duodam piest infomacija
            pictureBox1.Image = kbmp;   //paveiksliukas
        }

        private void PiesTrik(Graphics kgr, Brush brsh, Trikampis Trik) //piesiam trikampius
        {
            //Pen tusinas = new Pen(Brushes.Red);
            if(CB_SpalvLinijos.Checked) //jeigu yra custom setting del spalvu
            {
                kgr.DrawLine(new Pen(Brushes.Red), Trik.Tas1.P, Trik.Tas2.P);
                kgr.DrawLine(new Pen(Brushes.Cyan), Trik.Tas2.P, Trik.Tas3.P);
                kgr.DrawLine(new Pen(Brushes.Black), Trik.Tas3.P, Trik.Tas1.P);
            }
            else
            {
                kgr.DrawLine(new Pen(Brushes.Black), Trik.Tas1.P, Trik.Tas2.P);
                kgr.DrawLine(new Pen(Brushes.Black), Trik.Tas2.P, Trik.Tas3.P);
                kgr.DrawLine(new Pen(Brushes.Black), Trik.Tas3.P, Trik.Tas1.P);
            }
            if (CB_Apskritimai.Checked) //ar piesti trikampius gaubiancius apskritimus su ju centrais
            {
                kgr.FillEllipse(Brushes.Blue, Trik.Circle().X, Trik.Circle().Y, 10, 10);
                kgr.DrawEllipse(new Pen(Brushes.Blue), Trik.Circle().X - Trik.Spindulys(), Trik.Circle().Y - Trik.Spindulys(), Trik.Spindulys() * 2, Trik.Spindulys() * 2);
            }
        }

        private void Trianguliacija()   //smagumelis
        {
            foreach(Taskas tsk in Taskai)
                tsk.Trikampiai.Clear();
            Trikampiai.Clear();
            Trikampis Didysis = new Trikampis(new Taskas(0, 0), new Taskas(pictureBox1.Width * 4, 0), new Taskas(0, pictureBox1.Height * 4));
            Trikampiai.Add(Didysis);
            for (int i = 0; i < Trikampiai.Count(); i++)
            {
                Trikampis Einamasis = Trikampiai[i];
                //if (Trikampiai.Count() > 500)
                //{
                //    break;
                //}
                for (int j = 0; j < Taskai.Count(); j++)
                {
                    Taskas TasEinamasis = Taskai[j];
                    if (TasEinamasis.Trikampiai.Count() > 0) continue;
                    float atstumas = Pitagoras(Einamasis.Circle(), Taskai[j]);
                    if (Einamasis.Spindulys() > atstumas)
                    {
                        if (Einamasis.Duplikatas(Taskai[j]))
                        {
                            if (ArTrikampy(Einamasis, Taskai[j]))
                            {
                                //trikampiu kurimas
                                AddTrikampis(ref Trikampiai, Taskai[j], Einamasis.Tas2, Einamasis.Tas3);
                                AddTrikampis(ref Trikampiai, Einamasis.Tas1, Taskai[j], Einamasis.Tas3);
                                AddTrikampis(ref Trikampiai, Einamasis.Tas1, Einamasis.Tas2, Taskai[j]);
                                //Piesiam(Taskai, Trikampiai, Einamasis, Taskai[j],null);
                                //Thread.Sleep(500);
                                Einamasis.RemT();
                                Trikampiai.Remove(Einamasis);

                                //trapeciju nuoseklumo tikrinimas
                                Trikampis FliperisKitas = null;
                                Trikampis FliperisAs = null;
                                Taskas TasFlip = null, TasPap1 = null, TasPap2 = null;
                                if (TasEinamasis.ArFlip(ref FliperisKitas, ref FliperisAs, ref TasFlip, ref TasPap1, ref TasPap2))
                                {
                                    AddTrikampis(ref Trikampiai, TasEinamasis, TasFlip, TasPap1);
                                    AddTrikampis(ref Trikampiai, TasEinamasis, TasFlip, TasPap2);

                                    FliperisAs.RemT();
                                    FliperisKitas.RemT();
                                    Trikampiai.Remove(FliperisAs);
                                    Trikampiai.Remove(FliperisKitas);
                                }

                                i = -1;
                                break;
                            }
                        }
                    }
                    //Piesiam(Taskai, Trikampiai, Einamasis, Taskai[j],null);
                   // Thread.Sleep(500);
                }
            }

            //didziojo trikampio panaikinimas
            List<Trikampis> Didieji = new List<Trikampis>();
            Didieji.AddRange(Didysis.Tas1.Trikampiai);
            Didieji.AddRange(Didysis.Tas2.Trikampiai);
            Didieji.AddRange(Didysis.Tas3.Trikampiai);
            foreach (Trikampis Trik in Didieji) Trikampiai.Remove(Trik);//panaikinam trikampius kurie yra susije su didziuoju trikampiu

            for (int i = 0; i <int.Parse(Flip_Count.Text); i++)         //perziurima ar yra lengvai/pamirsta kas flipinti
            {
                foreach (Taskas Tsk in Taskai)
                {
                    ////trapeciju nuoseklumo tikrinimas
                    //Trikampis FliperisKitas = null;
                    //Trikampis FliperisAs = null;
                    //Taskas TasFlip = null, TasPap1 = null, TasPap2 = null;
                    //if (Tsk.ArFlip(ref FliperisKitas, ref FliperisAs, ref TasFlip, ref TasPap1, ref TasPap2))
                    //{
                    //    AddTrikampis(ref Trikampiai, Tsk, TasFlip, TasPap1);
                    //    AddTrikampis(ref Trikampiai, Tsk, TasFlip, TasPap2);

                    //    FliperisAs.RemT();
                    //    FliperisKitas.RemT();
                    //    Trikampiai.Remove(FliperisAs);
                    //    Trikampiai.Remove(FliperisKitas);
                    //}
                }
            }
            Piesiam(Taskai, Trikampiai, null, null, null); //piesiam
            EnableCTL(DelauneyTriangulation, true);  //ijungiam mygtuka atgal
        }
        private bool ArTrikampy(Trikampis Trik, Taskas Taskas)  //f-ja skirta patikrinti ar tikrinamasis taskas jau trikampyje (pusiau reduntant)
        {
            //pagrindinio trikampio plotas
            float A = plotas(Trik.Tas1, Trik.Tas2, Trik.Tas3);
            //mazesniu trikampiu plotas
            float A1 = plotas(Trik.Tas1, Trik.Tas2, Taskas);
            float A2 = plotas(Taskas, Trik.Tas2, Trik.Tas3);
            float A3 = plotas(Trik.Tas1, Taskas, Trik.Tas3);
            if (A == A1 + A2 + A3)
                return true;
            else return false;
        }
        static float plotas(Taskas Taskas1, Taskas Taskas2, Taskas Taskas3) //f-ja skirta apskaiciuoti trikampiu plotus
        {
            return (float)Math.Abs((Taskas1.X * (Taskas2.Y - Taskas3.Y) + Taskas2.X * (Taskas3.Y - Taskas1.Y) + Taskas3.X * (Taskas1.Y - Taskas2.Y)) / 2.0);
        }
        private float Pitagoras(Taskas Taskas1, Taskas Taskas2) //dede pitagoras
        {
            float atstumasX2 = (Taskas1.X - Taskas2.X) * (Taskas1.X - Taskas2.X);
            float atstumasY2 = (Taskas1.Y - Taskas2.Y) * (Taskas1.Y - Taskas2.Y);
            float atstumas = (float)Math.Sqrt(atstumasX2 + atstumasY2);

            return atstumas;
        }
        private void AddTrikampis(ref List<Trikampis> Trikampiai, Taskas Taskas1, Taskas Taskas2, Taskas Taskas3) //pridedam trikampi i trikampiu sarasa
        {
            Trikampis Trik = new Trikampis(Taskas1, Taskas2, Taskas3);
            Trikampiai.Add(Trik);
        }

        private void MonteKA_Click(object sender, EventArgs e)
        {
            GeneratePlot.ClearLists();
            int n = int.Parse(MonteKATB.Text);
            {
                int krastineX,krastineY;
                if (pictureBox1.Height > pictureBox1.Width)
                    krastineX = pictureBox1.Width;
                else krastineX = pictureBox1.Height;
                krastineY = krastineX;
                Taskas Centras = new Taskas(krastineX/2, krastineY/2);
                List<Taskas> Apskritimo = new List<Taskas>();
                for (int i = 0; i < n; i++)                                                //ciklas generuojantis taskus
                {
                    int Rx = krastineX, Ry = krastineY;            //nustatome max W ir H
                    GeneratePlot.Gen(ref Rx, ref Ry);                               //F-ja kuri generuoja taska
                    Taskas dummy = new Taskas(Rx, Ry);
                    float atstumas = Pitagoras(Centras, dummy);
                    if (atstumas < Centras.X)
                        Apskritimo.Add(dummy);
                    if (Apskritimo.Count() > 0)
                        Tikslumas.Text = (4*((float)Apskritimo.Count() / (float)GeneratePlot.GetTaskai().Count())).ToString();
                }
                Piesiam(GeneratePlot.GetTaskai(), null, null, null, Centras);
            }
        }
    }
}
