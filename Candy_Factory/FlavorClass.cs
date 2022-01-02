using System;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{
    class Flavor{
        public int cost { get;protected set; }
        public string title { get; protected set; }
    }


    class JellyFlavor: Flavor {
        public JellyFlavor(): base()
        {
            base.cost = 5;
            base.title = "Начинка: Желе";
        }

    }
    class MarzipanFlavor : Flavor
    {
        public MarzipanFlavor() : base()
        {
            base.cost = 10;
            base.title = "Начинка: Марципан";
            
        }
    }
    class PralineFlavor : Flavor
    {
        public PralineFlavor() : base()
        {
            base.cost = 15;
            base.title = "Начинка: Пралине";
        }
    }
}
