using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labb2Linq
{
    public class Kurs
    {

        public int Id { get; set; }
        public string KursNamn { get; set; }

        public Lärare Lärarna { get; set; }

        public Klass Klasser { get; set; }




    }
}
