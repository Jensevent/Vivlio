using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Dier
    {
        public Grootte grootte { get; private set; }
        public Type type { get; private set; }
        public int Punten {get; private set; }


        public Dier(Type GivenType, Grootte GivenGrootte)
        {
            this.type = GivenType;
            this.grootte = GivenGrootte;
            Punten = (int)this.grootte;
        }

    }
}
