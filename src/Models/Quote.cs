using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class QuotesResponse
	{
		[DataMember(Name = "results")]
		public Quote[] Results;
	}

	[DataContract]
	public class Quote
	{
		[DataMember(Name = "symbol")]
		public string Symbol;

		[DataMember(Name = "instrument")]
		public string InstrumentUrl;

		[DataMember(Name = "last_trade_price")]
		public double LastTradePrice;
	}
}
