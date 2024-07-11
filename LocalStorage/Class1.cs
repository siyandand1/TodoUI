namespace LocalStorage
{
    // All the code in this file is included in all platforms.
    public class LocalStorage
    {
        private readonly Realm _realm;

        public LocalStorage(Realm realm)
        {
            _realm = realm;
        }

        public Task<User> GetUserAsync(string username)
        {
            return Task.FromResult(_realm.Find<User>(username));
        }

        public async Task SaveUserAsync(User user)
        {
            using (var transaction = _realm.BeginWrite())
            {
                _realm.Add(user, update: true);
                await transaction.CommitAsync();
            }
        }

        public async Task DeleteUserAsync(string username)
        {
            using (var transaction = _realm.BeginWrite())
            {
                var user = _realm.Find<User>(username);
                if (user != null)
                {
                    _realm.Remove(user);
                }
                await transaction.CommitAsync();
            }
        }
    }
}
