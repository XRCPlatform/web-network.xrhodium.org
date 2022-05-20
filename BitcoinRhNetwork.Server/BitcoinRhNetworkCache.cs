using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinRhNetwork.Server
{
    public class BitCoinRhNetworkCache
    {
        public ICacheManager<string> CommonCache { get; private set; }
        public ICacheManager<string> ShortCache { get; private set; }

        public BitCoinRhNetworkCache()
        {
            CommonCache = CacheFactory.FromConfiguration<string>("CommonCache");
            ShortCache = CacheFactory.FromConfiguration<string>("ShortCache");
        }
    }
}
