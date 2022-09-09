using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence
{
    static class ConnectionstringHelper
    {
        static public string PostgreString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/ETicaretAPI.API"));
                return configurationManager.GetConnectionString("PostgreSql");
            }
        }

        static public string MssqlString
        {
            get {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
