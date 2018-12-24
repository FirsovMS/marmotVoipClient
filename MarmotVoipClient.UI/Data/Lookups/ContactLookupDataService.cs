using MarmotVoipClient.DataAccess.DAO;
using MarmotVoipClient.Model;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.UI.Data.Lookups
{
	public class ContactLookupDataService : IContactLookupDataService
	{
		private readonly MessagesDAO messagesDAO;
		private readonly ContactDisplayItemDAO contactDisplayItemDAO;

		public ContactLookupDataService(ContactDisplayItemDAO contactDisplayItemDAO,
			MessagesDAO messagesDAO)
		{
			this.messagesDAO = messagesDAO;
			this.contactDisplayItemDAO = contactDisplayItemDAO;
		}

		public IEnumerable<ContactLookupItem> GetContactLookups()
		{
			var contacts = contactDisplayItemDAO.GetAll();
			// TODO: Get contact of my user!

			// 
			return contacts.Select(contactDisplay => new ContactLookupItem()
			{
				Id = contactDisplay.Contact.Id,
				DisplayMember = $"{contactDisplay.Contact.FirstName} {contactDisplay.Contact.LastName}",
				Gliph = contactDisplay.Gliph,
				LastMessage = messagesDAO.GetLastFromTo
			});
		}
	}
}
