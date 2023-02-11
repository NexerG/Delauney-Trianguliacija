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
    class Trikampis //klase skirta laikyti trikampio duomenis ir daryt tam tikrus veiksmus su trikampiu
    {
        private float izambine;
        private Taskas T1, T2, T3;      //trikampio taskai
        private Taskas C;               //trikampi gaubiancio apskritimo centras

        public Trikampis(Taskas T1, Taskas T2, Taskas T3) { setPoints(T1, T2, T3); }
        public Trikampis() { }
        public bool Duplikatas(Taskas Taskas)   //f-ja skirta tikrinti ar tikrinamasis taskas nera jau sito trikampio dalis
        {                                       //realiai nereikalinga funkcija
            if (Taskas != T1 && Taskas != T2 && Taskas != T3)
            {
                return true;
            }
            else return false;
        }
        public void setPoints(Taskas pirmas, Taskas antras, Taskas trecias) //f-ja sutvarkanti trikampi
        { 
            T1 = pirmas;                        //pasetinam pirma taska
            T2 = antras;                        //set taskas 2
            T3 = trecias;                       //set taskas 3
            C = setCircleCenter(T1, T2, T3);    //surandam trikampi gaubiancio apskritimo centra
            izam();                             //surandam spinduli
            T1.AddTrik(this);                   //taskams pridedam kad jie priklauso sitam trikampiui
            T2.AddTrik(this);
            T3.AddTrik(this);
        }
        public void RemT()  //f-ja skirta panaikinti trikampius panaikinant trikampi (turbut galima butu naudoti destruktoriu)
        {
            T1.RemTrik(this);
            T2.RemTrik(this);
            T3.RemTrik(this);
        }

        public Taskas Tas1
        {
            get { return T1; }
        }
        public Taskas Tas2
        {
            get { return T2; }
        }
        public Taskas Tas3
        {
            get { return T3; }
        }
        public Taskas Circle()
        {
            return C;
        }
        public float Spindulys()
        {
            return izambine;
        }

        private void izam()
        {
            float izamX2 = (C.X - T1.X) * (C.X - T1.X);
            float izamY2 = (C.Y - T1.Y) * (C.Y - T1.Y);
            izambine = (float)Math.Sqrt(izamY2 + izamX2);
        }

        private Taskas setCircleCenter(Taskas Taskas1, Taskas Taskas2, Taskas Taskas3) //skaiciuojam apskritimo centra
        {
            //pirma linija
            float a = 0;
            float b = 0;
            float c = 0;
            Statiniai(Taskas1, Taskas2, ref a, ref b, ref c);

            //antra linija
            float d = 0;
            float e = 0;
            float f = 0;
            Statiniai(Taskas2, Taskas3, ref d, ref e, ref f);

            //bisektors
            Bisektorius(Taskas1, Taskas2, ref a, ref b, ref c);
            Bisektorius(Taskas2, Taskas3, ref d, ref e, ref f);

            Taskas Vidurys = Susikirtimas(a, b, c, d, e, f);

            return Vidurys;
        }
        private void Statiniai(Taskas Taskas1, Taskas Taskas2, ref float a, ref float b, ref float c)
        {
            a = Taskas2.Y - Taskas1.Y;
            b = Taskas1.X - Taskas2.X;
            c = a * Taskas1.X + b * Taskas1.Y;
        }

        private void Bisektorius(Taskas Taskas1, Taskas Taskas2, ref float a, ref float b, ref float c)
        {
            PointF mid_point = new PointF((Taskas1.X + Taskas2.X) / 2,
                                          (Taskas1.Y + Taskas2.Y) / 2);
            c = -b * (mid_point.X) + a * (mid_point.Y);
            float temp = a;
            a = -b;
            b = temp;
        }

        private Taskas Susikirtimas(float a1, float b1, float c1,
                                    float a2, float b2, float c2)
        {
            float determinantas = a1 * b2 - a2 * b1;
            float x = (b2 * c1 - b1 * c2) / determinantas;
            float y = (a1 * c2 - a2 * c1) / determinantas;
            return new Taskas(x, y);
        }

        public bool ArSusikertam(Taskas pT1, Taskas pT2)    //redundant f-ja skirta kitokiam skaiciavimo budui
        {
            if (doIntersect(pT1, pT2, T1, T2) && pT2!= T1 && pT2!=T2) return true;
            if (doIntersect(pT1, pT2, T2, T3) && pT2 != T2 && pT2 != T3) return true;
            if (doIntersect(pT1, pT2, T3, T1) && pT2 != T3 && pT2 != T1) return true;
            return false;
        }
        static Boolean doIntersect(Taskas p1, Taskas q1, Taskas p2, Taskas q2)    //redundant f-ja skirta kitokiam skaiciavimo budui
        {
            // Find the four orientations needed for general and
            // special cases
            float o1 = orientation(p1, q1, p2);
            float o2 = orientation(p1, q1, q2);
            float o3 = orientation(p2, q2, p1);
            float o4 = orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1
            if (o1 == 0 && onSegment(p1, p2, q1)) return false;

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1
            if (o2 == 0 && onSegment(p1, q2, q1)) return false;

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2
            if (o3 == 0 && onSegment(p2, p1, q2)) return false;

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2
            if (o4 == 0 && onSegment(p2, q1, q2)) return false;

            return false; // Doesn't fall in any of the above cases
        }
        static float orientation(Taskas p, Taskas q, Taskas r)    //redundant f-ja skirta kitokiam skaiciavimo budui
        {
            float val = (q.Y - p.Y) * (r.X - q.X) -
                    (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0; // collinear

            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }
        static Boolean onSegment(Taskas p, Taskas q, Taskas r)    //redundant f-ja skirta kitokiam skaiciavimo budui
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }
        public bool Contains(Taskas Tas2, Taskas Tas3, ref Taskas Tolimiausias) //f-ja skirta patikrinti ar sitam trikampiui priklauso duotas taskas
        {
            List<Taskas> kk = new List<Taskas>(new Taskas[] { T1, T2, T3 });
            bool krez =kk.Contains(Tas2) && kk.Contains(Tas3);
            if(krez)
            {
                kk.Remove(Tas2);
                kk.Remove(Tas3);
                Tolimiausias = kk[0];
            }
            return krez;
        }

    }
}
