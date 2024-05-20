// <copyright file="TODOServices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class TODOServices : IServicesTODO
    {
        private static readonly TODOServices TheInstance = new ();
        private readonly TODORepository todoRepository;

        private TODOServices()
        {
            this.todoRepository = new TODORepository();
        }

        public static TODOServices Instance
        {
            get { return TheInstance; }
        }

        public List<TODOClass> GetTODOS()
        {
            return this.todoRepository.GetTODOS();
        }

        public void AddTODO(TODOClass todoObject)
        {
            this.todoRepository.AddingTODO(todoObject);
        }

        public void RemoveTODO(int id)
        {
            TODOClass? todoToRemove = this.GetTODOS().FirstOrDefault(todo => todo.ID == id);

            if (todoToRemove != null)
            {
                this.todoRepository.RemovingTODO(todoToRemove);
            }
        }
    }
}
