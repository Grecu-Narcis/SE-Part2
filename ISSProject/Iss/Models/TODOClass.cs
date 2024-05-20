// <copyright file="TODOClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Models
{
    public class TODOClass
    {
        private string task;
        private int id;

        public TODOClass(string task)
        {
            this.task = task;
        }

        public TODOClass()
        {
            this.task = string.Empty;
        }

        public string Task
        {
            get { return this.task; } set { this.task = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public override string ToString()
        {
            return $"{this.id}. {this.task}";
        }
    }
}
