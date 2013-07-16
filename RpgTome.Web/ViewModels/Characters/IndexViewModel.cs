using System.Collections.Generic;
using RpgTome.Model;

namespace RpgTome.Web.ViewModels.Characters
{
    public class IndexViewModel
    {
        public IEnumerable<Character> Characters { get; set; }
    }
}