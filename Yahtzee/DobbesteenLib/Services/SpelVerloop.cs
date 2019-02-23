using DobbesteenLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobbesteenLib.Services
{
    public class SpelVerloop
    {
        public List<Dobbelstenen> StenenList { get; set; }
        public static Random rnd = new Random();

        public SpelVerloop()
        {
            StenenList = new List<Dobbelstenen>();
            MaakStenen();
        }

        private void MaakStenen()
        {
            for (int i = 1; i <= 6; i++)
            {
                
                Dobbelstenen nieuweSteen = new Dobbelstenen();
                StenenList.Add(nieuweSteen);
                
            }
        }

        public void RolSteen1()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[0].Waarde = waarde;
        }
        public void RolSteen2()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[1].Waarde = waarde;
        }
        public void RolSteen3()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[2].Waarde = waarde;
        }
        public void RolSteen4()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[3].Waarde = waarde;
        }
        public void RolSteen5()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[4].Waarde = waarde;
        }
        public void RolSteen6()
        {
            int waarde = rnd.Next(1, 7);
            StenenList[5].Waarde = waarde;
        }
    }
}
