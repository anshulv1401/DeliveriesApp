using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("Uri for Azure server");

        public static bool Insert<T>(ref T objectToInsert)
        {
            try
            {
                MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
