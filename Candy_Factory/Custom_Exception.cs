using System;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{
    class NotCreatedCandy: Exception
    {
        public NotCreatedCandy() { }

        public NotCreatedCandy(string message)
            : base(message) { }
    }

    class ZeroCandy : Exception
    {
        public ZeroCandy() { }

        public ZeroCandy(string message)
            : base(message) { }
    }
}
