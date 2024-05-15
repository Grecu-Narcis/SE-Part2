
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    internal class CollaborationService : ICollaborationService
    {

        private IColaborationRepository collaborationRepository;

        public CollaborationService(IColaborationRepository collaborationRepository) {
            this.collaborationRepository= collaborationRepository;
        }
        public CollaborationService() {
            this.collaborationRepository = new CollaborationRepository();
        }
        public void addCollaboration(Collaboration collaboration)
        {
            collaborationRepository.createCollaboration(collaboration);
        }

        public List<Collaboration> getCollaborationForAdAccount()
        {
            return collaborationRepository.GetCollaborationsForAdAccount();
        }

        public List<Collaboration> getCollaborationForInfluencer()
        {
            return collaborationRepository.getCollaborationsForInfluencer();
        }

        public List<Collaboration> getActiveCollaborationForAdAccount()
        {

            return collaborationRepository.GetCollaborationsForAdAccount().Where(c => c.status).ToList();
        }
    }
}