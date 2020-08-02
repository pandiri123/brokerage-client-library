using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class LoginRequest
	{
		[DataMember(Name = "grant_type")]
		public string GrantType;

		[DataMember(Name = "scope")]
		public string Scope;

		[DataMember(Name = "client_id")]
		public string ClientId;

		[DataMember(Name = "expires_in")]
		public long SecondsToExpiry;

		[DataMember(Name = "device_token")]
		public string DeviceToken;

		[DataMember(Name = "username")]
		public string UserName;

		[DataMember(Name = "password")]
		public string Password;

		[DataMember(Name = "mfa_code")]
		public string SmsCode;
	}
}
