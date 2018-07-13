﻿using FYHomeV1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYHomeV1.Utils
{
    public class UserUtil
    {
        public static void SetUserLogin(Person user)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(user);
        }

        public static Person GetUserLogin()
        {
            if (App.Current.Properties.ContainsKey("LOGIN"))
            {
                return JsonConvert.DeserializeObject<Person>((string)App.Current.Properties["LOGIN"]);
            }
            else
            {
                return null;
            }
        }
    }
}
