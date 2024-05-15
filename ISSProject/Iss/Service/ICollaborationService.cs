using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface ICollaborationService
    {
        public void addCollaboration(Collaboration collaboration);
        public List<Collaboration> getCollaborationForAdAccount();
        public List<Collaboration> getCollaborationForInfluencer();
        public List<Collaboration> getActiveCollaborationForAdAccount();
    }
}
