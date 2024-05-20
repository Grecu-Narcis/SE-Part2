// <copyright file="IFAQRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;

    public interface IFAQRepository
    {
        List<FAQ> GetFAQList();

        void AddFAQ(FAQ newQ);

        void DeleteFAQ(FAQ q);
    }
}
