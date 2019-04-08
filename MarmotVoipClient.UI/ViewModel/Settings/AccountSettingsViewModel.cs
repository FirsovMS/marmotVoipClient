using lindotnet.Classes.Component.Implementation;
using MarmotVoipClient.UI.Data.Repositories;

namespace MarmotVoipClient.UI.ViewModel.Settings
{
	public struct AccountData
	{
		public string AccountName;
		public string UserID;
		public string Domain;
		public string Password;
	}

	public struct DomainData
	{
		public bool IsProxyUsed;
		public bool IsDomainSelected;
		public bool IsProxyAddressSelected;
		public string ProxyAddress;
	}

	public class AccountSettingsViewModel : ViewModelBase
	{
		private readonly IAccountRepository _accountRepository;
		private AccountData _accountData;
		private DomainData _domainData;

		public AccountData AccountData
		{
			get
			{
				return _accountData;
			}
			set
			{
				_accountData = value;
				OnPropertyChanged();
			}
		}

		public DomainData DomainData
		{
			get
			{
				return _domainData;
			}
			set
			{
				_domainData = value;
				OnPropertyChanged();
			}
		}

		public AccountSettingsViewModel(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;

			AccountData = new AccountData()
			{
				AccountName = "test",
				Domain = "local.dev",
				Password = "test",
				UserID = "test"
			};
			DomainData = new DomainData()
			{
				ProxyAddress = "localhost",
				IsProxyUsed = true,
				IsProxyAddressSelected = true,
				IsDomainSelected = false
			};
		}

		public void Load(string previousID)
		{
			Account account = null;
			if (string.IsNullOrEmpty(previousID) && _accountRepository.TryGetAccount(previousID, out account))
			{
				var accountData = new AccountData()
				{
					AccountName = account.AccountName,
					Domain = account.Server,
					Password = account.Password,
					UserID = account.Username
				};

				var isProxyUsed = string.IsNullOrWhiteSpace(account.ProxyHost);
				var domainData = new DomainData()
				{
					IsDomainSelected = !isProxyUsed,
					IsProxyUsed = isProxyUsed,
					ProxyAddress = account.ProxyHost,
					IsProxyAddressSelected = isProxyUsed
				};

				AccountData = accountData;
				DomainData = domainData;
			};
		}
	}
}
