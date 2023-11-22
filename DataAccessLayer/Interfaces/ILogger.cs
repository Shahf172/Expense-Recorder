using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ILogger
    {
        void Info(string msg);
        void Info(object obj);
        void Error(string msg);
        void Error(object obj);
        void Verbose(string msg);
        void Verbose(object obj);
        void Debug(string msg);
        void Debug(object obj);
    }
}
