﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCrypto.DataBase.Entity
{
    public class CoinMarker
    {
        public string? exchangeId { get; set; }
        public string? baseId { get; set; }
        public string? quoteId { get; set; }
        public string? baseSymbol { get; set; }
        public string? quoteSymbol { get; set; }
        public string? volumeUsd24Hr { get; set; }
        public string? priceUsd { get; set; }
        public string? volumePercent { get; set; }
    }
    public class CoinMarkerRoot
    {
        public List<CoinMarker>? data { get; set; }
        public long timestamp { get; set; }
    }
}
