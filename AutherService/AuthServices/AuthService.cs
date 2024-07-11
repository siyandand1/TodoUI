using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutherService
{
    public class AuthService
    {
       
            private readonly LocalStorage _localStorage;
            private const string AuthStateKey = "AuthState";

            public AuthService(LocalStorage localStorage)
            {
                _localStorage = localStorage;
            }

            public async Task<bool> IsAuthenticatedAsync()
            {
                await Task.Delay(2000);

                var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

                return authState;
            }

            public async Task<bool> LoginAsync(string username, string password)
            {
              var user = await _localStorage.GetUserAsync(username);
                if (user != null && user.Password == password)
                {
                    Preferences.Default.Set<bool>(AuthStateKey, true);
                    return true;
                }
                return false;
            }

            public async Task<bool> RegisterAsync(string username, string password)
            {
                var user = await _localStorage.GetUserAsync(username);
                if (user == null)
                {
                    var newUser = new User
                    {
                        Username = username,
                        Password = password
                    };
                    await _localStorage.SaveUserAsync(newUser);
                    return true;
                }
                return false;
            }

            public void Logout()
            {
                Preferences.Default.Remove(AuthStateKey);
            }
        
    }
}
