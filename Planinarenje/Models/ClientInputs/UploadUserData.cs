
using DBLibrary.Models;
using Planinarenje.Models.ValidationArea;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planinarenje.Models.ClientInputs
{
    public class UploadUserData : BaseGuide,IModels
    {
            public bool Success = false;
            
            public Profil Profil { get; set; }
            [Required]
            [ValidateUploadUser(ErrorMessage ="Files must be provided !")]
            public IEnumerable<HttpPostedFileBase> Files { get; set; }

            public bool SaveFile(string folderPath)
            {
                if (!System.IO.Directory.Exists(folderPath)) { System.IO.Directory.CreateDirectory(folderPath); }
                foreach (var file in Files)
                {
                    if (file != null)
                    {
                        string nameAndLocation = folderPath + file.FileName;
                        file.SaveAs(nameAndLocation);
                        if (!System.IO.File.Exists(nameAndLocation)) { return false; }
                    }
                }
                return true;
            }
        
    }
}