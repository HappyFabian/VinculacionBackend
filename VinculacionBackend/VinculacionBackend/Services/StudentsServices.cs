﻿using System;
using System.Linq;
using VinculacionBackend.Entities;
using VinculacionBackend.Enums;
using VinculacionBackend.Models;
using VinculacionBackend.Repositories;

namespace VinculacionBackend.Services
{
    public class StudentsServices : IStudentsServices
    {
        private readonly StudentRepository _studentRepository;
        private readonly MajorRepository _majorRepository;

        public StudentsServices(StudentRepository studentRepository, MajorRepository majorRepository)
        {
            _studentRepository = studentRepository;
            _majorRepository = majorRepository;
        }

        public  User Map(UserEntryModel userModel)
        {
            var newUser = new User();
            newUser.AccountId = userModel.AccountId;
            newUser.Name = userModel.Name;
            newUser.Password = EncryptDecrypt.Encrypt(userModel.Password);
            newUser.Major = _majorRepository.GetMajorByMajorId(userModel.MajorId); ;
            newUser.Campus = userModel.Campus;
            newUser.Email = userModel.Email;
            newUser.Status = Status.Inactive;
            newUser.CreationDate = DateTime.Now;
            newUser.ModificationDate = DateTime.Now;
            return newUser;
        }

        public void Add(User user)
        {
            _studentRepository.Insert(user);
            _studentRepository.Save();
            
        }

        public User Find(string accountId)
        {
        return _studentRepository.GetByAccountNumber(accountId);
        }

        public IQueryable<User> ListbyStatus(string status)
        {
            return _studentRepository.GetStudentsByStatus(status) as IQueryable<User>;
        }

        public User RejectUser(string accountId)
        {

            var student = Find(accountId);
            if (student != null)
            {
                student.Status = Status.Rejected;
                _studentRepository.Save();
           }
            return student;
        }

        public User ActivateUser(string accountId)
        {
            var student = Find(accountId);
            if (student != null)
            {
                student.Status = Status.Active;
                _studentRepository.Save();
                
            }
            return student;
        }

        public User VerifyUser(string accountId)
        {
            var student = Find(accountId);
            if (student != null)
            {
                student.Status = Status.Verified;
                _studentRepository.Save();
            }
            return student;
        }

       

        public User DeleteUser(string accountId)
        {
            var user = _studentRepository.DeleteByAccountNumber(accountId);
            _studentRepository.Save();
            return user;
        }

        public IQueryable<User> AllUsers()
        {
            return _studentRepository.GetAll();
        }

        public int GetStudentHours(string accountId)
        {
           return _studentRepository.GetStudentHours(accountId);
        }
    }
}