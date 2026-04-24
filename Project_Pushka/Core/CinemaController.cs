using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Configuration
    {
        public string Version { get; set; } = "1.0.0";
        public string Env { get; set; } = "Production";
    }

    public class CinemaController
    {
        private readonly Configuration _config;

        public Cinema ManagedCinema { get; private set; }

        public CinemaController(string cinemaName)
        {
            _config = new Configuration();
            ManagedCinema = new Cinema(cinemaName);
        }

        public void PrintSystemStatus()
        {
            Console.WriteLine($"Система кінотеатру (v{_config.Version} - {_config.Env}) запущена.");
        }
    }
}
