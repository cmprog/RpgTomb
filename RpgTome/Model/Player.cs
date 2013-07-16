using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgTome.Model
{
    public class Player
    {
        public virtual int Id { get; set; }

        public virtual PersonName Name { get; set; }
    }
}
