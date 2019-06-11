using DeliveriesApp.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveriesApp.Droid
{
    public class User
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                result = false;
            }
            else
            {
                var user = (await AzureHelper.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user.Password == password)
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public static async Task<bool> Register(string email, string password, string confirm)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(password))
            {
                if (password == confirm)
                {
                    var user = new User()
                    {
                        Email = email,
                        Password = password
                    };
                    await AzureHelper.MobileService.GetTable<User>().InsertAsync(user);
                    result = true;
                }
            }
            return result;
        }
    }
}