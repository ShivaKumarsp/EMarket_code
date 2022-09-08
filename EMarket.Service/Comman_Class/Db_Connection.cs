using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMarket.BLL.Comman_Class
{
   public class Db_Connection
    {
        public readonly string ConnectionString = string.Empty;
        public string _ConnectionString { get => ConnectionString; }
        public Db_Connection()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            ConnectionString = root.GetSection("ConnectionStrings").GetSection("PostgreSql1").Value;

        }
        public string postgreconnection()
        {
            return "Host=192.168.1.31;Port=5432;User ID=shivakumar;Password=Avani@002;Database=EMarket_v2;Pooling=true;";
        }
    }
}
