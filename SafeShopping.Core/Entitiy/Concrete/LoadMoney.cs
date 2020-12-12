using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Core.Entitiy.Concrete
{
    public class LoadMoney : IEntity
    {
        public int Id { get; set; }
        public string UserGuid { get; set; }
        public decimal Balance { get; set; }
    }
}
