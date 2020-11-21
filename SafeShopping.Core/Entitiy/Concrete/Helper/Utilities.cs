using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Core.Entitiy.Concrete.Helper
{
    public static class Utilities
    {
        public static string GuidGenerator()
        {
          
            Random r = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
               
                stringBuilder.Append(r.Next(1, 9));
            }

            var MyGuid = stringBuilder.ToString();

            return MyGuid;
           
        }
    }
}
