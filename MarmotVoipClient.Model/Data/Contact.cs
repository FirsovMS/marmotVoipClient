using Addititonals.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace MarmotVoipClient.Model.Data
{
	public class Contact : ICloneable
	{
		[Key]
		public int Id { get; private set; }

		[Required]
		[StringLength(45)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(45)]
		public string LastName { get; set; }

		[Required]
		[StringLength(45)]
		public string Sip { get; set; }

		public Contact(string firstName, string lastName, string sip)
		{
			FirstName = firstName;
			LastName = lastName;
			Sip = sip;
		}

		public Contact(int id, string firstName, string lastName, string sip) : this(firstName, lastName, sip)
		{
			Id = id;
		}

		public static Contact Default()
		{
			return new Contact(0, string.Empty, string.Empty, string.Empty);
		}

		public object Clone()
		{
			return new Contact(this.Id, this.FirstName, this.LastName, this.Sip);
		}

		public override string ToString()
		{
			return this.SerializeObject();
		}
	}
}
