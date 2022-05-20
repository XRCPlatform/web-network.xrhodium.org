using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinRhNetwork.Entities.Peers
{
    public class Peer : RichEntity
    {
        public enum PeerState
        {
            Offline = 0,
            Online = 1
        }

        public string Ip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Type { get; set; }
        public string ContinentName { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public bool IsPrime { get; set; }
        public bool IsDetected { get; set; }
        public PeerState State { get; set; }
    }
}
