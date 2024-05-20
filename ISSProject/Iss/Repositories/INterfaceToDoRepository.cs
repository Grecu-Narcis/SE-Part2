// <copyright file="TODORepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Backend.Models;

namespace Backend.Repositories
{
    internal interface INterfaceToDoRepository<T>
    {
        public void AddingTODO(TODOClass newTODO);

        public void RemovingTODO(TODOClass newTODO);

        public List<TODOClass> GetTODOS();
    }
}
