// <copyright file="IFAQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;

    internal interface IFAQService
    {
        List<FAQ> GetAllFAQs();

        void AddSubmittedQuestion(FAQ newQuestion);

        List<FAQ> GetSubmittedQuestions();

        List<FAQ> FilterFAQs(List<FAQ> faqList, string searchText);
    }
}
