using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Team> teams = new List<Team>();

            string command = Console.ReadLine();

            while (command != "END")
            {

                string[] commandArray = command.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArray.Length >= 2)
                {
                    try
                    {
                        string action = commandArray[0];
                        string teamName = commandArray[1];

                        if (action == "Team")
                        {
                            Team teamToAdd = new Team(teamName);
                            teams.Add(teamToAdd);

                        }
                        else
                        {
                            var team = teams.FirstOrDefault(x => x.Name == teamName);

                            if (team == null)
                            {

                                Console.WriteLine($"Team {teamName} does not exist.");
                                command = Console.ReadLine();
                                continue;
                            }

                            if (action == "Add")
                            {
                                string playerName = commandArray[2];
                                int[] skills = commandArray.Skip(3).Select(int.Parse).ToArray();
                                var playerToAdd = new Player(playerName, skills);
                                team.Add(playerToAdd);

                            }
                            else if (action == "Remove")
                            {
                                string playerToRemove = commandArray[2];
                                team.Remove(playerToRemove);


                            }
                            else if (action == "Rating")
                            {
                                Console.WriteLine($"{team.Name} - {team.CalculateRating()}");

                            }

                        }

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                command = Console.ReadLine();
            }

        }
    }
}
