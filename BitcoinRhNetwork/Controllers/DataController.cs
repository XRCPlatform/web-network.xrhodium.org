using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Hosting;
using BitCoinRhNetwork.Components;
using BitCoinRhNetwork.Server.Business.Peers;
using BitCoinRhNetwork.Server;
using NBitcoin;
using BitCoinRhNetwork.Entities.Peers;

namespace BitCoinRhNetwork.Controllers
{
    public class DataController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DataController));

        [HttpGet]
        public HttpResponseMessage CheckPeers()
        {
            var Peers = new PeerComponent(BitCoinRhNetworkServer.Current.BitCoinRhNetworkDbContextScopeFactory, BitCoinRhNetworkServer.Current.BitCoinRhNetworkDbContextLocator);

            var rpcBridge = new Server.Business.RPC.RPCBridge();
            var rpc = rpcBridge.GetRpcClient();

            var peerInfo = RPCCacheHelper.GetCachedPeerInfo(rpc);

            if ((peerInfo != null) && (peerInfo.Length > 0))
            {
                var peersInDb = Peers.GetAll();

                foreach (var itemPeerInfo in peerInfo)
                {
                    var endPoint = Utils.ParseIpEndpoint(itemPeerInfo.Address, 37270);
                    if (endPoint != null)
                    {
                        var ip = endPoint.Address.MapToIPv4().ToString();

                        var peerInDb = peersInDb.FirstOrDefault(a => a.Ip == ip);
                        if (peerInDb == null)
                        {
                            var newPeer = Peers.Create();
                            newPeer.Ip = ip;

                            string info = new WebClient().DownloadString("http://api.ipstack.com/" + ip + "?access_key=" + ConfigurationManager.AppSettings["IPStack_AccessKey"] + "");

                            if (!string.IsNullOrEmpty(info))
                            {
                                var ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

                                //ignore changsha & xiangtan servers
                                if ((ipInfo.City.ToLower() != "changsha") && (ipInfo.City.ToLower() != "xiangtan"))
                                {
                                    newPeer.City = ipInfo.City;
                                    newPeer.ContinentName = ipInfo.ContinentName;
                                    newPeer.CountryName = ipInfo.CountryName;
                                    newPeer.Ip = ipInfo.Ip;
                                    newPeer.Latitude = ipInfo.Latitude;
                                    newPeer.Longitude = ipInfo.Longitude;
                                    newPeer.Zip = ipInfo.Zip;
                                    newPeer.State = Peer.PeerState.Online;
                                    newPeer.IsDetected = true;

                                    Peers.Add(newPeer);
                                }
                            }
                        }
                    }
                }
            }

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            return new HttpResponseMessage()
            {
                Content = new JsonHttpContent(JsonConvert.SerializeObject(true, Formatting.None, serializerSettings))
            };
        }

        [HttpGet]
        public HttpResponseMessage GetNetworkInfo()
        {
            var rpcBridge = new Server.Business.RPC.RPCBridge();
            var rpc = rpcBridge.GetRpcClient();

            var miningInfo = RPCCacheHelper.GetCachedMiningInfo(rpc);

            var info = new NetworkInfo();
            info.Difficulty = miningInfo.Difficulty;
            info.Blocks = miningInfo.Blocks;
            info.NetworkHashps = miningInfo.NetworkHashps;

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.None };
            return new HttpResponseMessage()
            {
                Content = new JsonHttpContent(JsonConvert.SerializeObject(info, Formatting.None, serializerSettings))
            };
        }

        [HttpGet]
        public HttpResponseMessage GetNetworkInfoNoCache()
        {
            var rpcBridge = new Server.Business.RPC.RPCBridge();
            var rpc = rpcBridge.GetRpcClient();

            var miningInfo = RPCCacheHelper.GetNoCachedMiningInfo(rpc);

            var info = new NetworkInfo();
            info.Difficulty = miningInfo.Difficulty;
            info.Blocks = miningInfo.Blocks;
            info.NetworkHashps = miningInfo.NetworkHashps;

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.None };
            return new HttpResponseMessage()
            {
                Content = new JsonHttpContent(JsonConvert.SerializeObject(info, Formatting.None, serializerSettings))
            };
        }
    }

    public class NetworkInfo
    {
        /// <summary>The current block.</summary>
        [JsonProperty(PropertyName = "blocks")]
        public long Blocks { get; set; }

        /// <summary>Target difficulty that the next block must meet.</summary>
        [JsonProperty(PropertyName = "difficulty")]
        public double Difficulty { get; set; }

        /// <summary>The network hashes per second.</summary>
        [JsonProperty(PropertyName = "networkhashps")]
        public double NetworkHashps { get; set; }
    }

    public class JsonHttpContent : HttpContent
    {
        private readonly JToken _value;

        public JsonHttpContent(JToken value)
        {
            _value = value;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        protected override Task SerializeToStreamAsync(Stream stream,
        TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            _value.WriteTo(jw);
            jw.Flush();
            return Task.FromResult<object>(null);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
