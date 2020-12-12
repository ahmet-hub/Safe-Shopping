using SafeShopping.Core.Entitiy.Concrete.Helper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SafeShopping.Core.Entitiy.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public int SuccessfulOperationCount { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }


        public User()
        {

            Guid = Utilities.GuidGenerator();
            Balance = 0;
            RefreshTokenEndDate = DateTime.Now.AddDays(5);
        }

    }
}
