﻿using Newtonsoft.Json;

namespace ServiceBusMessageTransceiver;

public class DealFactory
{
    private Random _random;

    public DealFactory()
    {
        _random = new Random(DateTime.Now.Millisecond);
    }

    public Deal CreateDeal(int order)
    {
        return new Deal()
        {
            Id = Guid.NewGuid(),
            Order = order,
            Name = $"Name-{_random.Next(1, 50000)}-Dat",
            NumberOfYearsToKeepOnRecord = _random.Next(1, 45),
            CreatedOnDate = DateTime.Now.AddDays(-1 * _random.Next(4, 100)),
            IsGoodDeal = _random.Next(1, 100) > 50
        };
    }

    public string CreateSerializedDeal(int order)
    {
        var someDeal = CreateDeal(order);
        return JsonConvert.SerializeObject(someDeal);
    }
}