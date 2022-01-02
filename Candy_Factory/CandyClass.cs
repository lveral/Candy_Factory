using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candy_Factory
{
    class Candy
    {
        protected Flavor flavor;
        protected Glaze glaze;
        protected Wrapper wrapper;

        public delegate void CandyCreated(string mes);
        public event CandyCreated Created;

        public int cost { get; protected set; }

        public Candy(Flavor _flavor, Glaze _glaze, Wrapper _wrapper)
        {
            flavor = _flavor;
            glaze = _glaze;
            wrapper = _wrapper;
            cost = flavor.cost + glaze.cost + wrapper.cost;
            
        }
        public void LogEntry()
        {
            Created?.Invoke("Создана конфета.Информация о конфете:"+ GetFlavor() + ", " + GetGlaze() + ", " + GetWrapper());
        }
        public Candy()
        {

        }
        public string GetFlavor()
        {
            return flavor.title;
        }

        public string GetGlaze()
        {
            return glaze.title;
        }

        public string GetWrapper()
        {
            return wrapper.title;
        }
    }
}
