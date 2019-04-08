using MarmotVoipClient.DataAccess.DAO;
using MarmotVoipClient.Model;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.UI.Data.Lookups
{
	public class ContactLookupDataService : IContactLookupDataService
	{
		private readonly MessagesDAO _messagesDAO;
		private readonly ContactDisplayItemDAO _contactDisplayItemDAO;

		public ContactLookupDataService(ContactDisplayItemDAO contactDisplayItemDAO,
			MessagesDAO messagesDAO)
		{
			_messagesDAO = messagesDAO;
			_contactDisplayItemDAO = contactDisplayItemDAO;
		}

		public IEnumerable<ContactLookupItem> GetContactLookups()
		{
			var contacts = _contactDisplayItemDAO.GetAll();

			// TODO: Get contact of my user!
			//return contacts.Select(contactDisplay => new ContactLookupItem()
			//{
			//	Id = contactDisplay.Contact.Id,
			//	DisplayMember = $"{contactDisplay.Contact.FirstName} {contactDisplay.Contact.LastName}",
			//	Gliph = contactDisplay.Gliph,
			//	LastMessage = _messagesDAO.GetLastFromTo()
			//});

			return new List<ContactLookupItem>();
		}
	}
}
