using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public static class UploadUserImage
    {
        public static (bool,string) SaveFile(string folderPath,HttpPostedFileBase Image,string userName)
        {
            

            if (Image != null)
            {
               

                string newName = "IMG"+userName+ DateTime.Now.Ticks+".jpg";
                string nameAndLocation = folderPath + newName;
                Image.SaveAs(nameAndLocation);
                if (!System.IO.File.Exists(nameAndLocation)) { return (false,null); }
                return (true, newName);
            }

            return (false,null);
        }

    }
}