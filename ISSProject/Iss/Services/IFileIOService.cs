using System;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services
{
    internal interface IFileIOService
    {
        List<FAQ> LoadFromXml(string filePath);
        void SaveToXml(List<FAQ> faqList, string filePath);
    }
}
