// <copyright file="TODORepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Models;

    public class TODORepository : INterfaceToDoRepository<TODOClass>
    {
        private static int lastId = 0;
        private readonly string xmlFilePath;
        private List<TODOClass> todosList;

        public TODORepository()
        {
            this.todosList = new List<TODOClass>();
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;

            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToToDoXML = $"\\XMLFiles\\TODOitems.xml";
            this.xmlFilePath = pathUntilBin + pathToToDoXML;
            this.LoadFromXml();
        }

        public void AddingTODO(TODOClass newTODO)
        {
            newTODO.ID = lastId++;
            this.todosList.Add(newTODO);
            this.SaveToXml();
        }

        public void RemovingTODO(TODOClass newTODO)
        {
            this.todosList.Remove(newTODO);
            this.SaveToXml();
        }

        public List<TODOClass> GetTODOS()
        {
            return this.todosList;
        }

        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(this.xmlFilePath))
                {
                    XmlSerializer serializer = new (typeof(TODOClass), new XmlRootAttribute("TODOClass"));

                    this.todosList = new List<TODOClass>();

                    using FileStream fileStream = new (this.xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("TODOClass"))
                    {
                        TODOClass todo = (TODOClass)serializer.Deserialize(reader);
                        todo.ID = lastId++;
                        this.todosList.Add(todo);
                    }
                }
                else
                {
                    this.todosList = new List<TODOClass>();
                }
            }
            catch
            {
            }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new (typeof(List<TODOClass>), new XmlRootAttribute("TODOs"));

            using FileStream fileStream = new (this.xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, this.todosList);
        }
    }
}
