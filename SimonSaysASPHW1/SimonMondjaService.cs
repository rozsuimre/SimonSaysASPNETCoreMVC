using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonMondjaEgybeFuzveASPNETCore.Empty
{
    public class SimonMondjaService : ISimonMondjaService
    {

        public SimonMondjaService()
        {
            Ra = new Random();
           
        }
        public Random Ra { get; }
        
        public string kitalalandoString { get; set; }
        List<int> kitalalandoList = new List<int>() {};

        List<int> felhasznaloList = new List<int>() {};
        public string felhasznaloString = "";

        public string tipp { get; set; }

        public string Restart() //miazelso
        {
            kitalalandoString = "";
            int uj = Ra.Next(1, 100);
            kitalalandoList.Add(uj);
            kitalalandoString = uj.ToString();
            return kitalalandoString;
        }

        public List<int> Lekerdez() 
        {
            return kitalalandoList;
        }

        public string Tipp(string tipp) 
        {

            // felhasznaloList.Add(tipp);
            // var a = kitalalandoList.All(felhasznaloList.Contains);

           

            kitalalandoString = "";
            for (int j = 0; j < kitalalandoList.Count(); j++)
            {
                kitalalandoString += kitalalandoList[j].ToString();
            }

            felhasznaloString = "";
            for (int k = 0; k < felhasznaloList.Count(); k++)
            {
                felhasznaloString += felhasznaloList[k].ToString();
            }

            bool a = kitalalandoString.Equals(tipp);
            string result = string.Empty;
            int i = tipp.IndexOf(felhasznaloString);
            if (i >= 0) 
            {
                string marad = tipp.Remove(i, felhasznaloString.Length);
            }
            if (a)
            {
                felhasznaloString = tipp;
                felhasznaloList.Add(int.Parse(tipp));
               int uj = Ra.Next(1, 100);
                kitalalandoList.Add(uj);
                 return uj.ToString();
            }
            else { return "Vége"; }
        
        }

        public List<int> Egyezes(int tipp) //, out int uj) 
        {
            //if(Eqyezes.Item1[0])


            //if (tipp == kitalalando)
            //{
            //    int uj = Ra.Next(1, 100);
            //    kitalalando += uj.ToString();
            //    vissza = ,kitalalando);
            //    return vissza;//uj.ToString();

            //}
            //else
            //{
            //    vissza=new ("Vége",kitalalando);

            //    return vissza;
            //}
            //uj = 0; //valami érték kötelező
            return kitalalandoList;
        }

      

        
    }
}
