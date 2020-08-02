using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class Instrument
	{
		[DataMember(Name = "id")]
		public string Id;

		[DataMember(Name = "url")]
		public string Url;

		[DataMember(Name = "name")]
		public string Name;

		[DataMember(Name = "quote")]
		public string QuoteUrl;

		[DataMember(Name = "fundamentals")]
		public string FundamentalsUrl;

		[DataMember(Name = "simple_name")]
		public string SimpleName;

		[DataMember(Name = "splits")]
		public string SplitsUrl;

		[DataMember(Name = "symbol")]
		public string Symbol;

		[DataMember(Name = "tradable_chain_id")]
		public string TradableChainId;

		[DataMember(Name = "tradeable")]
		public bool Tradeable;

		[DataMember(Name = "fractional_tradability")]
		public string FractionalTradability;
	}

	[DataContract]
	public class InstrumentsResponse
	{
		[DataMember(Name = "results")]
		public Instrument[] Results;
	}
}
