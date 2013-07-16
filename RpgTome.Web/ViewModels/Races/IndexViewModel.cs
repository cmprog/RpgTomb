using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RpgTome.Model;

namespace RpgTome.Web.ViewModels.Races
{
    public class IndexViewModel
    {
        public IEnumerable<Race> Races { get; set; }
    }
}