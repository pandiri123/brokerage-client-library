using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class OrderRequest
	{
		[DataMember(Name = "ref_id")]
		public string RefId;

		[DataMember(Name = "account")]
		public string Account;

		[DataMember(Name = "instrument")]
		public string Instrument;

		[DataMember(Name = "symbol")]
		public string Symbol;

		[DataMember(Name = "quantity")]
		public double Quantity;

		[DataMember(Name = "side")]
		public string Side;

		[DataMember(Name = "type")]
		public string Type;

		[DataMember(Name = "trigger")]
		public string Trigger;

		[DataMember(Name = "time_in_force")]
		public string TimeInForce;

		[DataMember(Name = "extended_hours")]
		public bool ExtendedHours;

		[DataMember(Name = "price")]
		public double Price;

		[DataMember(Name = "dollar_based_amount")]
		public DollarOrder DollarBasedAmount;
	}

	[DataContract]
	public class DollarOrder
	{
		[DataMember(Name = "currency_code")]
		public string CurrencyCode;

		[DataMember(Name = "amount")]
		public double Amount;
	}
}
