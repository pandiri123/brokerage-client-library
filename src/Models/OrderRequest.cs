using System.Runtime.Serialization;

namespace Net.Pandiri.Trading.Models
{
	[DataContract]
	public class OrderResponse
	{
		[DataMember(Name = "id")]
		public string Id;

		[DataMember(Name = "ref_id")]
		public string RefId;

		[DataMember(Name = "url")]
		public string Url;

		[DataMember(Name = "account")]
		public string AccountUrl;

		[DataMember(Name = "instrument")]
		public string InstrumentUrl;

		[DataMember(Name = "position")]
		public string PositionUrl;

		[DataMember(Name = "cancel")]
		public string CancelUrl;

		[DataMember(Name = "fees")]
		public double Fees;

		[DataMember(Name = "side")]
		public string Side;

		[DataMember(Name = "type")]
		public string Type;

		[DataMember(Name = "trigger")]
		public string Trigger;

		[DataMember(Name = "time_in_force")]
		public string TimeInForce;

		[DataMember(Name = "price")]
		public double Price;

		[DataMember(Name = "quantity")]
		public double Quantity;

		[DataMember(Name = "state")]
		public string State;

		[DataMember(Name = "created_at")]
		public string CreatedAt;

		[DataMember(Name = "updated_at")]
		public string UpdatedAt;

		[DataMember(Name = "LastTransactionAt")]
		public string LastTransactionAt;
	}
}
