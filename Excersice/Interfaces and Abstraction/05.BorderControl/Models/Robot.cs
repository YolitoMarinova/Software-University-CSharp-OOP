﻿using _05.BorderControl.Interfaces;

namespace _05.BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
