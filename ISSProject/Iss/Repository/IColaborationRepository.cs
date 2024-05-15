using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IColaborationRepository
    {
        public void createCollaboration(Collaboration collaboration);
        public List<Collaboration> GetCollaborationsForAdAccount();
        public List<Collaboration> getCollaborationsForInfluencer();
    }
}
