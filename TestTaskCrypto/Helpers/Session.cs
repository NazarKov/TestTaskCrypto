﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.DataBase.Entity;

namespace TestTaskCrypto.Helpers
{
    public static class Session
    {
        public static Coin Coin { get; set; }
        public static List<Coin> CoinList { get; set; }
    }
}
