using Paises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Paises.ViewModel
{
    public class Multipledata
    {
        public IEnumerable<pais> Paises { get; set; }

        public IEnumerable<persona> Personas { get; set; }

    }
}