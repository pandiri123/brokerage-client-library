using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class User
	{
		[DataMember(Name = "id")]
		public string UserId;

		[DataMember(Name = "url")]
		public string Url;

		[DataMember(Name = "first_name")]
		public string FirstName;

		[DataMember(Name = "last_name")]
		public string LastName;

		[DataMember(Name = "email")]
		public string Email;

		[DataMember(Name = "username")]
		public string UserName;
	}
}
