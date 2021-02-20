using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.DBContexts
{
    public class DBEntityFrameworkProfile :IProfilInfo, IActivities
    {
        private PlaninarenjeEntities1 planinarenjeEntities;
        public DBEntityFrameworkProfile(PlaninarenjeEntities1 planinarenjeEntities)
        {
            this.planinarenjeEntities = planinarenjeEntities;

        }

        public Profil GetProfilById(string Email)
        {
            AspNetUser aspNetUser= planinarenjeEntities.AspNetUsers.FirstOrDefault(x=>x.Email.ToLower()==Email.ToLower());
            if (aspNetUser != null)
            {
                Profil_Tbl aspNetProfile = planinarenjeEntities.Profil_Tbl.FirstOrDefault(x => x.UserID == aspNetUser.Id);
                if (aspNetProfile == null) {
                    return new Profil()
                    {
                        AspNetUser = new UserInfo() { Id = aspNetUser.Id, Email = aspNetUser.Email, Image = aspNetUser.Image, IsGuid = aspNetUser.IsGuid, IsVerified = aspNetUser.EmailConfirmed, RealUserName = aspNetUser.RealUserName, PhoneNumber = aspNetUser.PhoneNumber }
                    };
                }
                Ocena_Profila_Tbl ocena_Profila_Tbl = aspNetProfile.Ocena_Profila_Tbl;
                
                

                return new Profil()
                {
                    ProfilID = aspNetProfile.ProfilID,
                    UserId = aspNetUser.Id,
                    ShortDescription = aspNetProfile.ShortDescription,
                    Aktivnosti= aktivnostis(aspNetProfile.AktivnostiProfiles_Tbl),
                    Ocena_Profila = new Ocena() { OcenaID = ocena_Profila_Tbl.OcenaID, Nivo1 = ocena_Profila_Tbl.Nivo1, Nivo2 = ocena_Profila_Tbl.Nivo2, Nivo3 = ocena_Profila_Tbl.Nivo3, Nivo4 = ocena_Profila_Tbl.Nivo4, Nivo5 = ocena_Profila_Tbl.Nivo5 },
                    AspNetUser = new UserInfo() { Id = aspNetUser.Id, Email = aspNetUser.Email, Image = aspNetUser.Image, IsGuid = aspNetUser.IsGuid, IsVerified = aspNetUser.EmailConfirmed, RealUserName = aspNetUser.RealUserName,PhoneNumber=aspNetUser.PhoneNumber }
                     
                };
            }
            return null;
        }
        private ICollection<Aktivnosti> aktivnostis(ICollection<AktivnostiProfiles_Tbl> aktivnostis) 
        {
            List<Aktivnosti> aktivnostis1 = new List<Aktivnosti>();
            aktivnostis1.AddRange(GetAktivnostis());
            foreach(var activity in aktivnostis.Where(x=>x.IsUsing==true))
            {
                
                var aktivnostFromList = aktivnostis1.SingleOrDefault(x => x.AktivnostiID == activity.Aktivnosti_Id);
                if(aktivnostFromList != null)
                {
                    aktivnostFromList.IsActive = true;
                }

                 
            }
            return aktivnostis1;
        }
        public Profil SaveProfile(Profil profil)
        {
            var localProfile= planinarenjeEntities.Profil_Tbl.SingleOrDefault(x => x.UserID == profil.UserId);

            localProfile.ShortDescription = profil.ShortDescription;
          int result=  planinarenjeEntities.SaveChanges();
            if (result > 0)
            {
                return profil;
            }
            return new Profil() { ShortDescription = localProfile.ShortDescription };
        }

        public ICollection<Aktivnosti> GetAktivnostis()
        {
            List<Aktivnosti> aktivnostis = new List<Aktivnosti>();
            var allActivities = planinarenjeEntities.Aktivnosti_Tbl;
            foreach(var ak in allActivities)
            {
                aktivnostis.Add(new Aktivnosti()
                {
                    AktivnostiID = ak.AktivnostiID,
                    ImeAktivnosti = ak.ImeAktivnosti
                });
            }
            return aktivnostis;
        }

        public ICollection<Aktivnosti> UpdateActivity(int ID,string email)
        {
          
           var profileEl= GetProfilById(email);
            if (profileEl != null)
            {
                var activity = planinarenjeEntities.AktivnostiProfiles_Tbl.SingleOrDefault(x => x.Aktivnosti_Id == ID && x.Profile_Id == profileEl.ProfilID);
                if (activity != null)
                {
                    activity.IsUsing = !activity.IsUsing;

                    int result = planinarenjeEntities.SaveChanges();

                }
                else
                {
                 var newActivityProfile=   new AktivnostiProfiles_Tbl()
                    {
                        Aktivnosti_Id=ID,
                        IsUsing=true,
                        Profile_Id=profileEl.ProfilID
                    };
                    planinarenjeEntities.AktivnostiProfiles_Tbl.Add(newActivityProfile);
                    planinarenjeEntities.SaveChanges();
                }
                 
            }
            return aktivnostis(planinarenjeEntities.AktivnostiProfiles_Tbl.Where(x => x.Profile_Id == profileEl.ProfilID).ToList());
        }

        public ICollection<Aktivnosti> GetAktivnostisByUser(string email)
        {
            var user=planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
            Profil_Tbl aspNetProfile = planinarenjeEntities.Profil_Tbl.FirstOrDefault(x => x.UserID ==  user.Id);
           var aktivities= planinarenjeEntities.AktivnostiProfiles_Tbl.Where(x=>x.Profile_Id==aspNetProfile.ProfilID).ToList();
           return aktivnostis(aktivities);
        }

        public Profil CreateProfile(string Email)
        {
            Profil profilRet = new Profil();
          var selectedUser=    planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if(selectedUser != null)
            {
             var ocenaAdded=   planinarenjeEntities.Ocena_Profila_Tbl.Add(new Ocena_Profila_Tbl()
                {
                    Nivo1 = 0,
                    Nivo2=0,
                    Nivo3=0,
                    Nivo4=0,
                    Nivo5=0,
                   
                });
             int isAdded=   planinarenjeEntities.SaveChanges();
                if (isAdded > 0)
                {
                    var profile = planinarenjeEntities.Profil_Tbl.SingleOrDefault(x => x.UserID == selectedUser.Id);
                    if (profile == null)
                    {
                        var addedProfile = planinarenjeEntities.Profil_Tbl.Add(new Profil_Tbl()
                        {
                            UserID = selectedUser.Id,
                            Ocena_Id = ocenaAdded.OcenaID,
                            ShortDescription = "Please implement"
      
                        });
                        int isPlaninarenjeAdded=    planinarenjeEntities.SaveChanges();
                        if (isPlaninarenjeAdded > 0)
                        {

                            profilRet.ProfilID = addedProfile.ProfilID;
                            profilRet.Ocena_Id = ocenaAdded.OcenaID;
                            profilRet.ShortDescription = addedProfile.ShortDescription;

                          var changeUser=  planinarenjeEntities.AspNetUsers.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                            changeUser.IsGuid = true;
                            int isUserUpdate=   planinarenjeEntities.SaveChanges();

                        }
                    }
                }

                
            }
            return profilRet;
        }
    }
}
