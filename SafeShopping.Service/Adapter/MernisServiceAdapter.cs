using MernisServiceReference;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Adapter
{
    public class MernisServiceAdapter : IAccountCheckService
    {
        //public bool CheckIfRealPerson(Account account)
        //{
        //    KPSPublicSoapClient kPSPublicSoapClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
        //    var response = kPSPublicSoapClient.TCKimlikNoDogrulaAsync(Convert.ToInt64(account.IdentificationNumber), account.Name.ToUpper(), account.LastName.ToUpper(), account.DateOfBirth.Year);
        //    return response.Result.Body.TCKimlikNoDogrulaResult;
        //}
        public bool CheckIfRealPerson(Account account)
        {
            return true;
        }
    }
}
