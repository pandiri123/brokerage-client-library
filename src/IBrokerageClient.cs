
using Net.Pandiri.Trading.Models;

namespace Net.Pandiri.Trading
{
    interface IBrokerageClient
    {
		Account GetAccount();

		Instrument GetInstrument(string symbol);

		Quote GetQuote(string symbol);

		OrderResponse SendOrder(OrderRequest orderRequest);
	}
}
