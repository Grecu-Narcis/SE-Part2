// <copyright file="IFAQ.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Models;

    internal interface IFAQ
    {
        List<Backend.Models.FAQ> GetFAQList();

        void AddFAQ(Backend.Models.FAQ newQ);

        void DeleteFAQ(Backend.Models.FAQ q);
    }
}
