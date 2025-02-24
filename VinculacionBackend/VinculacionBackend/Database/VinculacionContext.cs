﻿using System.Configuration;
using System.Data.Entity;
using VinculacionBackend.Entities;

namespace VinculacionBackend.Database
{
    public class VinculacionContext:DbContext
    {
        public VinculacionContext() : base(ConnectionString.Get())
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SectionProject> SectionProjectsRels { get; set; }
        public DbSet<SectionUser> SectionUserRels { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoleRels { get; set; }
        public DbSet<MajorUser> MajorUsersRels { get; set; }
    }

    public static class ConnectionString
    {
        public static string Get()
        {
            var Environment = ConfigurationManager.AppSettings["Environment"];
            return string.Format("name={0}", Environment);
        }
    }

}