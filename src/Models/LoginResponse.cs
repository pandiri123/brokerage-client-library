using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class LoginResponse
	{
		[DataMember(Name = "access_token")]
		public string AccessToken;

		[DataMember(Name = "expires_in")]
		public long Expiry;

		[DataMember(Name = "token_type")]
		public string TokenType;

		[DataMember(Name = "scope")]
		public string Scope;

		[DataMember(Name = "refresh_token")]
		public string RefreshToken;

		[DataMember(Name = "mfa_code")]
		public string MfaCode;

		[DataMember(Name = "backup_code")]
		public string BackupCode;
	}
}
