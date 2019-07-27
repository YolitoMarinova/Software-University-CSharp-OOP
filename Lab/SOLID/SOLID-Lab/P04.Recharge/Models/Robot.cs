﻿using P04.Recharge.Contracts;

namespace P04.Recharge.Models
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity)
            : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity => this.capacity;

        public int CurrentPower
        {
            get => this.currentPower; 
            set => this.currentPower = value;
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }
    }
}