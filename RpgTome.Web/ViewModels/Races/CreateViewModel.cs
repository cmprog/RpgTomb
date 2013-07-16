using System.Collections.Generic;
using RpgTome.Model;

namespace RpgTome.Web.ViewModels.Races
{
    public class CreateViewModel
    {
        public SizeCategory DefaultSize { get; set; }
        public IEnumerable<SizeCategory> Sizes { get; set; }
    }
}