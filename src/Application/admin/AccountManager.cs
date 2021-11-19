using Data.admin;
using Domain.Entities;

namespace Application.admin
{
    public class AccountManager
    {
        private readonly AccountDal _accountManager;

        public AccountManager(AccountDal accountManager)
        {
            _accountManager = accountManager;
        }

        public Employee Login(string username, string password) => _accountManager.Login(username, password);
    }
}