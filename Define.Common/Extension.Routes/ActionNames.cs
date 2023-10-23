using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define.Common.Extension.Routes
{
    public static class ActionNames
    {
        public const string Controller = "actyin/[controller]";
        public const string RegisterUser = "actyin/registerUser";
        public const string LoginUser = "actyin/loginUser";
        public const string DeleteUser = "actyin/deleteUserById/{id}";
        public const string GetUserById = "actyin/deleteUserById/{id}";
        public const string GetAllUsers= "actyin/getAllUsers";
        public const string EditFavoriteActivity = "actyin/editFavoriteActivity";
        public const string EditAthleteLocation = "actyin/editAthleteLocation";
        public const string EditAthletePassword = "actyin/editAthletePassword";
        public const string EditAthleteUsernameAndEmailRequest = "actyin/editAthleteUsernameAndEmailRequest";
    }
}
