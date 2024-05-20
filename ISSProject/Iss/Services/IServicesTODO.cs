// <copyright file="IServicesTODO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services
{
    public interface IServicesTODO
    {
        List<TODOClass> GetTODOS();

        void AddTODO(TODOClass todoObject);

        void RemoveTODO(int id);
    }
}
