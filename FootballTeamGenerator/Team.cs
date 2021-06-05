using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {

        private string name;

        private readonly List<Player> players;

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

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
            

        }


        public void Add(Player player)
        {

            this.players.Add(player);


        }

        public void Remove(string name)
        {

            Player playerToRemove = this.players.FirstOrDefault(x => x.Name == name);

            if(playerToRemove == null)
            {

                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(playerToRemove);

        }

        public int CalculateRating()
        {

            if (this.players.Count == 0)
            {

                return 0;
            }

            double totalSkillLevels = this.players.Sum(x => x.Stats.Average());

            int rating = (int)Math.Round(totalSkillLevels / this.players.Count);

            return rating;
        }


    }
}
