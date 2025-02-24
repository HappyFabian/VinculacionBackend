﻿using System.Linq;
using VinculacionBackend.Entities;
using VinculacionBackend.Models;

namespace VinculacionBackend.Services
{
    interface IStudentsServices
    {
        User Map(UserEntryModel userModel);
        void Add(User user);
        User Find(string accountId);
        IQueryable<User> ListbyStatus(string status);
        User RejectUser(string accountId);
        User ActivateUser(string accountId);
        User VerifyUser(string accountId);
        User DeleteUser(string accountId);


    }
}
