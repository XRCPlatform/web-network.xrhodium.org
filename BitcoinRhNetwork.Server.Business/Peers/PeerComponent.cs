using BitCoinRhNetwork.EF.Interfaces;
using BitCoinRhNetwork.Entities.Peers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinRhNetwork.Server.Business.Peers
{
    public class PeerComponent : BaseDbComponent<Peer>
    {
        public PeerComponent(IDbContextScopeFactory dbContextScopeFactory, IAmbientDbContextLocator ambientDbContextLocator) :
            base(dbContextScopeFactory, ambientDbContextLocator)
        {
        }

        public List<Peer> GetAllNonPrime(bool includeDeleted = false)
        {
            using (_dbContextScopeFactory.CreateReadOnly())
            {
                return _repository.GetAll(includeDeleted)
                    .Where(a => a.IsPrime == false)
                    .ToList();
            }

        }
    }
}