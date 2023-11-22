using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helpers
{
    public class Logger : Interfaces.ILogger
    {
        //static Logger()
        //{
        //    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
        //        .Build();
        //    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        //}

        public void Info(string msg)
        {
            Log.Information(msg);
        }
        public void Info(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            Log.Logger.Information(json);
        }
        public void Error(string msg)
        {
            Log.Logger.Error(msg);
        }
        public void Error(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            Log.Logger.Error(json);
        }
        public void Verbose(string msg)
        {
            Log.Logger.Verbose(msg);
        }
        public void Verbose(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            Log.Logger.Verbose(json);
        }
        public void Debug(string msg)
        {
            Log.Logger.Debug(msg);
        }
        public void Debug(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            Log.Logger.Debug(json);
        }
    }
}
