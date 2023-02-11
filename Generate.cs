////////////////////////////////////////////////

//         Made By Gytis Mockevičius          //

////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScatterPlot
{
    class Generate                                  //klase skirta generuoti random taskus, kuriuos desim ant ekrano
    {
        int skc = 1;
        List<Taskas> Taskai = new List<Taskas>();
       public void Gen(ref int rezX, ref int rezY)  //Generacija
        {
            int Dx = rezX, Dy = rezY;
            Random rndX = new Random(DateTime.Now.Millisecond^3*skc);
            Random rndY = new Random(DateTime.Now.Millisecond^2*skc);
            skc++;
            rezX = rndX.Next(1, Dx);
            rezY = rndY.Next(1, Dy);
            addTaskas(rezX, rezY);
        }
        public void addTaskas(int TaskasX, int TaskasY)     //f-ja kad prideti taskus i sarasa
        {
            Taskas tikrinamasis = new Taskas(TaskasX, TaskasY);
            if (Taskai.Contains(tikrinamasis)) Gen(ref TaskasX, ref TaskasY);
            else Taskai.Add(new Taskas(TaskasX, TaskasY));
        }
        public List<Taskas> GetTaskai()                     //F-ja skirta duoti tuos taskus on request
        {
            return Taskai;
        }
        public void ClearLists()                            //F-ja isvalanti sarasa. Naudojamas TIK kai kuriamas naujas sarasas
        {
            Taskai.Clear();
        }
    }
}
