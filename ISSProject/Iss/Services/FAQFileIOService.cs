using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Backend.Models;

namespace Backend.Services
{
    internal class FAQFileIOService : IFileIOService
    {
        public List<FAQ> LoadFromXml(string filePath)
        {
            List<FAQ> faqList = new List<FAQ>();

            try
            {
                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<FAQ>), new XmlRootAttribute("FAQs"));

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        faqList = (List<FAQ>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred while loading FAQs from XML: {ex.Message}");
            }

            return faqList;
        }

        public void SaveToXml(List<FAQ> faqList, string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<FAQ>), new XmlRootAttribute("FAQs"));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fileStream, faqList);
                }
            }
            catch (Exception exception)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred while saving FAQs to XML: {exception.Message}");
            }
        }
    }
}
