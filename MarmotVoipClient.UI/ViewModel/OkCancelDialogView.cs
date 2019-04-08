namespace MarmotVoipClient.UI.ViewModel
{
	using Prism.Commands;
	using System.Collections.Generic;
	using System.Windows.Input;

	public enum DialogResult
	{
		Undefined,
		Yes,
		No
	}

	public class OkCancelDialogView : ViewModelBase
	{
		public Dictionary<string, object> PropertyBag { get; private set; } = new Dictionary<string, object>();

		public DialogResult Result { get; private set; } = DialogResult.Undefined;

		public ICommand ApplyCommand { get; }

		public ICommand CancelCommand { get; }

		public OkCancelDialogView()
		{
			ApplyCommand = new DelegateCommand(OnApplyCommandExecute);
			CancelCommand = new DelegateCommand(OnCancelCommandExecute);
		}

		public virtual void OnCancelCommandExecute()
		{
			Result = DialogResult.No;
		}

		public virtual void OnApplyCommandExecute()
		{
			Result = DialogResult.Yes;
		}
	}
}
