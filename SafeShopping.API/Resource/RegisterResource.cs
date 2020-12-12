using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.API.Resource
{
    public class RegisterResource
    {      
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public int SuccessfulOperationCount { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
