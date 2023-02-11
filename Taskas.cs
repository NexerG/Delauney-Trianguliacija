////////////////////////////////////////////////

//         Made By Gytis Mockevičius          //

////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScatterPlot
{
    class Taskas //klase skirta laikyti tasko informacija
    {
        private PointF T0;                                          //paties tasko koordinates
        public List<Trikampis> Trikampiai= new List<Trikampis>();   //trikampiai kuriems priklauso tas taskas
        public Taskas(PointF T) { T0 = T; }                         //konstravimo operatorius, kai turime ka priskirti (objekta)
        public Taskas() { }                                         //konstravimo op, kai neturime ka priskirt
        public Taskas(float x, float y) { T0 = new PointF(x, y); }  //konstravimo op, kai turime ka priskirt (grynas koordinates)
        public Taskas(int x, int y) { T0 = new PointF(x, y); }

        public float X                                              //C# get set operatorius
        {
            get { return T0.X; }
            set { T0.X = value; }
        }
        public float Y
        {
            get { return T0.Y; }
            set { T0.Y = value; }
        }
        public PointF P
        {
            get { return T0; }
        }
        public void AddTrik(Trikampis Trik)
        {
            Trikampiai.Add(Trik);
        }
        public void RemTrik(Trikampis Trik)
        {
            Trikampiai.Remove(Trik);
        }

        internal bool ArFlip(ref Trikampis Trikas,ref Trikampis Mano,ref Taskas TasFlip,ref Taskas TasPap1,ref Taskas TasPap2)
        {
            //f-ja skirta aptikti ar is trikampio kaimynu gaunasi trapecija ir kuriu skirtingu kampu
            //sumos >180 Deg. Tokiu atveju trikampiai flipinami, taip kad trikampiai butu "grazus"
            foreach (Trikampis trik in Trikampiai)
            {
                if (this == trik.Tas1)
                {
                    foreach (Trikampis trik2 in trik.Tas2.Trikampiai)
                    {
                        Taskas Tolimiausias = null;
                        if (trik != trik2 && trik2.Contains(trik.Tas2, trik.Tas3, ref Tolimiausias))
                        {
                            float AB = Pitagoras(this, trik.Tas2);
                            float AC = Pitagoras(this, trik.Tas3);
                            float BC = Pitagoras(trik.Tas2, trik.Tas3);
                            float BAC = (float)Math.Acos((AB * AB + AC * AC - BC * BC) / (2 * AB * AC));//kampas vienas

                            float DB = Pitagoras(Tolimiausias, trik.Tas2);
                            float DC = Pitagoras(Tolimiausias, trik.Tas3);
                            float BDC = (float)Math.Acos((DB * DB + DC * DC - BC * BC) / (2 * DB * DC));//kampas kitas
                            if (BDC + BAC > Math.PI)
                            {
                                TasPap1 = trik.Tas2;
                                TasPap2 = trik.Tas3;
                                Mano = trik;
                                TasFlip = Tolimiausias;
                                Trikas = trik2;
                                return true;
                            }
                        }
                    }
                }
                else if (this == trik.Tas2)
                {
                    foreach (Trikampis trik2 in trik.Tas3.Trikampiai)
                    {
                        Taskas Tolimiausias = null;
                        if (trik != trik2 && trik2.Contains(trik.Tas1, trik.Tas3, ref Tolimiausias))
                        {
                            float AB = Pitagoras(this, trik.Tas1);
                            float AC = Pitagoras(this, trik.Tas3);
                            float BC = Pitagoras(trik.Tas1, trik.Tas3);
                            float BAC = (float)Math.Acos((AB * AB + AC * AC - BC * BC) / (2 * AB * AC));

                            float DB = Pitagoras(Tolimiausias, trik.Tas1);
                            float DC = Pitagoras(Tolimiausias, trik.Tas3);
                            float BDC = (float)Math.Acos((DB * DB + DC * DC - BC * BC) / (2 * DB * DC));
                            if (BDC + BAC > Math.PI)
                            {
                                TasPap1 = trik.Tas1;
                                TasPap2 = trik.Tas3;
                                Mano = trik;
                                TasFlip = Tolimiausias;
                                Trikas = trik2;
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Trikampis trik2 in trik.Tas1.Trikampiai)
                    {
                        Taskas Tolimiausias = null;
                        if (trik != trik2 && trik2.Contains(trik.Tas2, trik.Tas1, ref Tolimiausias))
                        {
                            float AB = Pitagoras(this, trik.Tas2);
                            float AC = Pitagoras(this, trik.Tas1);
                            float BC = Pitagoras(trik.Tas2, trik.Tas1);
                            float BAC = (float)Math.Acos((AB * AB + AC * AC - BC * BC) / (2 * AB * AC));

                            float DB = Pitagoras(Tolimiausias, trik.Tas2);
                            float DC = Pitagoras(Tolimiausias, trik.Tas1);
                            float BDC = (float)Math.Acos((DB * DB + DC * DC - BC * BC) / (2 * DB * DC));
                            if (BDC + BAC > Math.PI)
                            {
                                TasPap1 = trik.Tas2;
                                TasPap2 = trik.Tas1;
                                Mano = trik;
                                TasFlip = Tolimiausias;
                                Trikas = trik2;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        
        private float Pitagoras(Taskas Taskas1, Taskas Taskas2) //f-ja skirta grazinti atstuma tarp dvieju tasku 2D erdveje
        {
            float atstumasX2 = (Taskas1.X - Taskas2.X) * (Taskas1.X - Taskas2.X);
            float atstumasY2 = (Taskas1.Y - Taskas2.Y) * (Taskas1.Y - Taskas2.Y);
            float atstumas = (float)Math.Sqrt(atstumasX2 + atstumasY2);

            return atstumas;
        }

    }
}
