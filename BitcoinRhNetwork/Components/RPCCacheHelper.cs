using BitCoinRhNetwork.Library;
using BitCoinRhNetwork.Server;
using NBitcoin;
using NBitcoin.RPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static NBitcoin.RPC.RPCClient;

namespace BitCoinRhNetwork.Components
{
    public static class RPCCacheHelper
    {
        private const string KEY_CACHE_NETWORKINFO = "KEY_CACHE_NETWORKINFO";
        private const string KEY_CACHE_NODEINFO = "KEY_NODE_INFO";
        private const string KEY_CACHE_PEERINFO = "KEY_PEERINFO";
        private const string KEY_CACHE_MININGINFO = "KEY_CACHE_MININGINFO";

        public static NetworkInfo GetCachedNetworkInfo(RPCClient rpc)
        {
            var cached = BitCoinRhNetworkServer.Current.Cache.CommonCache.Get(KEY_CACHE_NETWORKINFO);
            NetworkInfo networkInfo = null;

            if (cached == null)
            {
                try
                {
                    networkInfo = rpc.GetNetworkInfo();
                    BitCoinRhNetworkServer.Current.Cache.CommonCache.Add(KEY_CACHE_NETWORKINFO, JsonConvert.SerializeObject(networkInfo));
                }
                catch (Exception e)
                {
                    if (!HttpContext.Current.Request.IsLocal)
                        MailProcessing.Send(e.Message + e.InnerException.ToString(), ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail_Subject"], ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail"]);
                    //server is down
                }
            }
            else
            {
                networkInfo = JsonConvert.DeserializeObject<NetworkInfo>(cached);
            }

            return networkInfo;
        }

        internal static MiningInfo GetCachedMiningInfo(RPCClient rpc)
        {
            var cached = BitCoinRhNetworkServer.Current.Cache.CommonCache.Get(KEY_CACHE_MININGINFO);
            MiningInfo miningInfo = null;

            if (cached == null)
            {
                try
                {
                    miningInfo = rpc.GetMiningInfo();
                    BitCoinRhNetworkServer.Current.Cache.CommonCache.Add(KEY_CACHE_MININGINFO, JsonConvert.SerializeObject(miningInfo));
                }
                catch (Exception e)
                {
                    if (!HttpContext.Current.Request.IsLocal)
                        MailProcessing.Send(e.Message + e.InnerException.ToString(), ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail_Subject"], ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail"]);
                    //server is down
                }
            }
            else
            {
                miningInfo = JsonConvert.DeserializeObject<MiningInfo>(cached);
            }

            return miningInfo;
        }

        internal static MiningInfo GetNoCachedMiningInfo(RPCClient rpc)
        {
            var cached = BitCoinRhNetworkServer.Current.Cache.ShortCache.Get(KEY_CACHE_MININGINFO);
            MiningInfo miningInfo = null;

            if (cached == null)
            {
                try
                {
                    miningInfo = rpc.GetMiningInfo();
                    BitCoinRhNetworkServer.Current.Cache.ShortCache.Add(KEY_CACHE_MININGINFO, JsonConvert.SerializeObject(miningInfo));
                }
                catch (Exception e)
                {
                    if (!HttpContext.Current.Request.IsLocal)
                        MailProcessing.Send(e.Message + e.InnerException.ToString(), ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail_Subject"], ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail"]);
                    //server is down
                }
            }
            else
            {
                miningInfo = JsonConvert.DeserializeObject<MiningInfo>(cached);
            }

            return miningInfo;
        }

        public static NodeInfo GetCachedNodeInfo(RPCClient rpc)
        {
            var cached = BitCoinRhNetworkServer.Current.Cache.CommonCache.Get(KEY_CACHE_NODEINFO);
            NodeInfo nodeInfo = null;

            if (cached == null)
            {
                try
                {
                    nodeInfo = rpc.GetNodeInfo();
                    BitCoinRhNetworkServer.Current.Cache.CommonCache.Add(KEY_CACHE_NODEINFO, JsonConvert.SerializeObject(nodeInfo));
                }
                catch (Exception e)
                {
                    if (!HttpContext.Current.Request.IsLocal)
                        MailProcessing.Send(e.Message + e.InnerException.ToString(), ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail_Subject"], ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail"]);
                    //server is down
                }
            }
            else
            {
                nodeInfo = JsonConvert.DeserializeObject<NodeInfo>(cached);
            }

            return nodeInfo;
        }

        public static PeerInfo[] GetCachedPeerInfo(RPCClient rpc)
        {
            var cached = BitCoinRhNetworkServer.Current.Cache.CommonCache.Get(KEY_CACHE_PEERINFO);
            PeerInfo[] peerInfo = null;

            if (cached == null)
            {
                try
                {
                    peerInfo = rpc.GetPeersInfo();
                    BitCoinRhNetworkServer.Current.Cache.CommonCache.Add(KEY_CACHE_PEERINFO, JsonConvert.SerializeObject(peerInfo));
                }
                catch (Exception e)
                {
                    if (!HttpContext.Current.Request.IsLocal)
                        MailProcessing.Send(e.Message + e.InnerException.ToString(), ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail_Subject"], ConfigurationManager.AppSettings["RPC_BTRNodeReportEmail"]);
                    //server is down
                }
            }
            else
            {
                peerInfo = JsonConvert.DeserializeObject<PeerInfo[]>(cached);
            }

            return peerInfo;
        }
    }
}