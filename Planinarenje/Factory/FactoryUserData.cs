using DBLibrary.Models;
using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Factory
{
    public static class FactoryUserData
    {
        private static UploadUserData _factoryCreator1;


        
        public static void Create()
        {
            _factoryCreator1 = new UploadUserData() ;
 
           
        }
        public static UploadUserData Initialization()
        {
            return _factoryCreator1;
        }
    }
}