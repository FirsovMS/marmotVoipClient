using lindotnet.Classes.Component.Implementation;

namespace MarmotVoipClient.UI.Data.Repositories
{
	public interface IAccountRepository
	{
		bool TryGetAccount(string accountName, out Account account);

		void CreateNew(Account account);

		void Delete(Account account);

		bool TryUpdate(Account account);
	}
}
