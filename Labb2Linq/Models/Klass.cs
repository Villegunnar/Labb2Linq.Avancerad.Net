using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq
{
    public class Klass
    {

        public int Id { get; set; }
        public string KlassNamn { get; set; }


        public ICollection<Kurs> Kurser { get; set; }



    }
}
