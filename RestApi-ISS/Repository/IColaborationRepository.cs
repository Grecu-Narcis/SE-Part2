﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Repository
{
    public interface IColaborationRepository
    {
        public void CreateCollaboration(Collaboration collaboration);
        public List<Collaboration> GetCollaborationsForAdAccount();
        public List<Collaboration> GetCollaborationsForInfluencer();
    }
}
