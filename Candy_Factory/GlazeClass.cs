using System;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{
    class Glaze
    {
        public int cost { get; protected set; }
        public string title { get; protected set; }
    }

    class WithoutGlaze : Glaze
    {
        public WithoutGlaze() : base()
        {
            base.cost = 0;
            base.title = "Глазурь: Без глазури";
        }
    }
    class DarkChocolateGlaze : Glaze
    {
        public DarkChocolateGlaze() : base()
        {
            base.cost = 15;
            base.title = "Глазурь: Темный шоколад";
        }
    }
    /*
    class MilkChocolateGlaze : Glaze
    {
        public MilkChocolateGlaze() : base()
        {
            base.Cost = 10;
        }
    }
    class WhiteChocolateGlaze : Glaze
    {
        public WhiteChocolateGlaze() : base()
        {
            base.Cost = 5;
        }
    }
    */
}
