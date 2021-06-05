using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {

        private string name;

        private int[] stats;

        private readonly string[] skills = new string[] { "Endurance", "Sprint", "Dribble", "Passing", "Shooting" };

        public string Name
        {
            get { return this.name; }

            private set
            {

                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException("A name should not be empty.");

                }

                this.name = value;
            }

        }

        public int[] Stats
        {
            get { return this.stats; }

            private set
            {

                this.stats = new int[5];

                for (int i = 0; i < 5; i++)
                {

                    if (value[i] < 0 ||
                        value[i] > 100)
                    {

                        string skill = skills[i];
                        throw new ArgumentException($"{skill} should be between 0 and 100.");

                    }

                    this.stats[i] = value[i];

                }

            }
        }

        public Player(string name, int[] stats)
        {
            this.Name = name;
            this.Stats = stats;

        }


    }
}
