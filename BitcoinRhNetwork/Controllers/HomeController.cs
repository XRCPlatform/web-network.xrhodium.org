using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BitCoinRhNetwork.App_Start;
using BitCoinRhNetwork.Components;
using BitCoinRhNetwork.Entities.Peers;
using BitCoinRhNetwork.Library;
using BitCoinRhNetwork.Server;
using BitCoinRhNetwork.Server.Business.Peers;
using NBitcoin.RPC;
using Newtonsoft.Json;

namespace BitCoinRhNetwork.Controllers
{
    [CustomRequireHttpsFilter]
    public class HomeController : BaseController
    {
        private PeerComponent Peers;

        public ActionResult Index(HomeViewModel post)
        {
            var viewModel = ViewModel<HomeViewModel>();
            viewModel.PeerInfo = new List<Peer>();
            var timestamp = DateTime.UtcNow;

            viewModel.TimeStamp = timestamp;

            var rpcBridge = new Server.Business.RPC.RPCBridge();
            var rpc = rpcBridge.GetRpcClient();

            var miningInfo = RPCCacheHelper.GetCachedMiningInfo(rpc);

            if (miningInfo != null)
            {
                viewModel.PeerInfo = Peers.GetAllNonPrime();
                viewModel.MiningInfo = miningInfo;
            }

            return View("Index", viewModel);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Peers = new PeerComponent(BitCoinRhNetworkServer.Current.BitCoinRhNetworkDbContextScopeFactory, BitCoinRhNetworkServer.Current.BitCoinRhNetworkDbContextLocator);
        }
    }

    public class HomeViewModel
    {
        public DateTime TimeStamp { get; set; }
        public List<Peer> PeerInfo { get; set; }
        public MiningInfo MiningInfo { get; set; }
    }
}