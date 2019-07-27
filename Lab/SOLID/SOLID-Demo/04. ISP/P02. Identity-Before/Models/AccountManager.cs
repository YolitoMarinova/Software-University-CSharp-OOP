namespace P02._Identity_Before.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class AccountManager : IAccount
    {
        public  bool RequireUniqueEmail { get; set; }

        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }

        public void Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }

        
    }
}
