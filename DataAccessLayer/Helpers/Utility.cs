using DataAccessLayer.Interfaces;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helpers
{
    public static class Utility
    {
        public static Result GetException(Exception ex, ILogger logger, Result result)
        {
            logger.Info(ex.Message);
            result.SetError("Unknown internal server error");
            return result;
        }
    }
}
