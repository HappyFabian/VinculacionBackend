﻿using System.Linq;
using System.Security.Principal;

namespace VinculacionBackend
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return roles.Any(r => role.Contains(r));
        }
        public CustomPrincipal(string username)

        {
            this.Identity = new GenericIdentity(username);
        }
        public CustomPrincipal(string username, string[] roles) : this(username)
        {
            this.roles = roles;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
    }








}