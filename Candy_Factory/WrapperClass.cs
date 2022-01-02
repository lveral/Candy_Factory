using System;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{
    class Wrapper
    {
        public int cost { get; protected set; }

        public string title { get; protected set; }

    }
    class FoilWrapper : Wrapper
    {
        public FoilWrapper() : base()
        {
            base.cost = 10;

            base.title = "Упаковка: фольга";
        }
    }
    class PaperWrapper : Wrapper
    {
        public PaperWrapper() : base()
        {
            base.cost = 5;

            base.title = "Упаковка: бумага";
        }
    }
}
