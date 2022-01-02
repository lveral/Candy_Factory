using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Core;


namespace Candy_Factory
{
    class Logging
    {
        public static Logger _log;

        public Logging(string toWrite)
        {
            if (toWrite == "Console")
            {
                _log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            }
            else if (toWrite == "File")
            {
                _log = new LoggerConfiguration()
                .WriteTo.File(@"C:\Users\ureki\Documents\GitHub\Candy_Factory\Candy_Factory\SinkLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            } 
            else if(toWrite == "Console&File")
            {
                _log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"C:\Users\ureki\Documents\GitHub\Candy_Factory\Candy_Factory\SinkLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            }
        }
        public void Information(string mes)
        {
            _log.Information(mes);
        }

        public void Error(string mes)
        {
            _log.Error(mes);
        }

    }
}
