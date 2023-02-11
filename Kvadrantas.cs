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
    class Kvadrantas //klase skirta laikyti kvadrantus, jeigu noretusi optimizuoti koda / daryti logika kitokiu budu
    {
        private List<PointF> Taskai = new List<PointF>();   //tasku sarasas priklausantis kvadrantui
        private PointF Koords;                              //kvadranto koordinates

        public void AddTaskas(PointF Taskas)
        {
            Taskai.Add(Taskas);
        }
        public List<PointF> GetTaskai()
        {
            return Taskai;
        }
        public PointF Koordinates
        {
            get { return Koords; }
            set { Koords = value; }
        }
    }
}
