using lindotnet.Classes.Component.Implementation;
using System;
using System.Collections.Generic;

namespace MarmotVoipClient.UI.Data.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly Dictionary<string, Account> _accountRepository;

		public AccountRepository()
		{
			_accountRepository = new Dictionary<string, Account>();
		}

		public void CreateNew(Account account)
		{
			var key = GetKey(account);
			if (_accountRepository.ContainsKey(key))
			{
				throw new Exception($"Account with key: {key} already exist! Choose another!");
			}

			_accountRepository.Add(key, account);
		}

		public void Delete(Account account)
		{
			var key = GetKey(account);
			if (_accountRepository.ContainsKey(key))
			{
				_accountRepository.Remove(key);
			}
			else
			{
				throw new Exception($"Account with key: {key} doesn't exist!");
			}
		}

		public bool TryGetAccount(string accountName, out Account account)
		{
			account = null;
			if (_accountRepository.ContainsKey(accountName))
			{
				account = _accountRepository[accountName];
				return true;
			}
			return false;
		}

		public bool TryUpdate(Account account)
		{
			var key = GetKey(account);
			if (_accountRepository.ContainsKey(key))
			{
				_accountRepository.Remove(key);
				return true;
			}
			return false;
		}

		private static string GetKey(Account account)
		{
			return string.IsNullOrEmpty(account.AccountName) ? account.Username : account.AccountName;
		}
	}
}
