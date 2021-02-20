using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.Factory
{
    public  class GuideNotGuideFactory : IFactoryGuide
    {
        private Dictionary<string ,IGuideUser> _guideUser = new Dictionary<string, IGuideUser>();
        string _key;
        public GuideNotGuideFactory(string key)
        {
            _key = key;
            _guideUser.Add(key: "Guide", value: new GuideUserDataPartial());
            _guideUser.Add(key: "NotGuide", value: new NotGuideUserData());
                        
             
        }
        public IGuideUser Create()
        {
            if (_guideUser.ContainsKey(_key) && _key=="Guide")
            {
                return _guideUser["Guide"];
                  
                
            }
            return _guideUser["NotGuide"];
        }
    }
}