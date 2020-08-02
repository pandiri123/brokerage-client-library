using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class Account
	{
		[DataMember(Name = "user_id")]
		public string UserId;

		[DataMember(Name = "url")]
		public string AccountUrl;

		[DataMember(Name = "portfolio_cash")]
		public double PortfolioCash;

		[DataMember(Name = "account_number")]
		public string Number;

		[DataMember(Name = "buying_power")]
		public string BuyingPower;

		[DataMember(Name = "cash_available_for_withdrawal")]
		public double CashAvailableForWithdrawal;

		[DataMember(Name = "cash")]
		public double Cash;

		[DataMember(Name = "rhs_account_number")]
		public long RHSAccountNumber;

		[DataMember(Name = "crypto_buying_power")]
		public string CryptoBuyingPower;
	}

	[DataContract]
	public class AccountsResponse
	{
		[DataMember(Name = "results")]
		public Account[] Results;
	}
}
