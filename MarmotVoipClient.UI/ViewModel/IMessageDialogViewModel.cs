using System.Threading.Tasks;

namespace MarmotVoipClient.UI.ViewModel
{
	public interface IMessageDialogViewModel
	{
		Task LoadAsync(int contactId);
	}
}