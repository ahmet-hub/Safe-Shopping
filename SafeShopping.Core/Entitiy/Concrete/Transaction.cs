using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Core.Entitiy.Concrete
{
    public class Transaction:IEntity
    {
        public int Id { get; set; }
        public string ReceiverGuid { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverLastName { get; set; }
        public string SenderGuid { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOfOperation { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
