﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HD;

namespace CryptoExchanges.Exchanges
{
  public abstract class RestExchange : Exchange
  {
    readonly IRestClient restClient;

    public RestExchange(
      ExchangeMonitor exchangeMonitor,
      ExchangeName exchangeName,
      int maxRequestsPerMinute,
      string baseUrl)
      : base(exchangeMonitor, exchangeName, maxRequestsPerMinute)
    {
      restClient = new RestClient(baseUrl);
    }


    protected async Task<T> Get<T>(
      string resource)
      where T : new()
    {
      await throttle.WaitTillReady();

      // TODO should be an async call
      return restClient.Get<T>(resource);
    }
  }
}
