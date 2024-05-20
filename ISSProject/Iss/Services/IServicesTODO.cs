// <copyright file="IServicesTODO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Models;

    public interface IServicesTODO
    {
        List<TODOClass> GetTODOS();

        void AddTODO(TODOClass todoObject);

        void RemoveTODO(int id);
    }
}
