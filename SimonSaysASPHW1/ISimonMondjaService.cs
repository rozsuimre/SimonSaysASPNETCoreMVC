using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonMondjaEgybeFuzveASPNETCore.Empty
{
    interface ISimonMondjaService
    {
        public string kitalalandoString { get; set; }
         public string tipp { get; set; }

        //public List<int> kitalalandoList { get; set; }

        //public List<int> felhasznaloList { get; set; }

        public List<int> Lekerdez();

        public string Tipp(string  tipp);

        public List<int> Egyezes(int st1);

        public string Restart();

    }
}
