using SafeShopping.Core.Entitiy.Concrete.Helper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace SafeShopping.Core.Entitiy.Concrete
{
    public class Account:IEntity
    {
        public int Id { get; set; }       
        public string MyGuid { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Account()
        {

            MyGuid = Utilities.GuidGenerator();
        }

    }
}
