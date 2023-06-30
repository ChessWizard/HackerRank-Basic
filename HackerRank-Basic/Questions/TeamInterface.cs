using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Questions.TeamInterface
{
    public class TeamInterface
    {
        public string teamName;
        public int noOfPlayers;
        public TeamInterface(string teamName, int noOfPlayers)
        {
            this.teamName = teamName;
            this.noOfPlayers = noOfPlayers;
        }

        public void AddPlayer(int count)
        {
            noOfPlayers += count;
        }
        public bool RemovePlayer(int count)
        {
            var solution = noOfPlayers - count;

            if(solution < 0) return false;

            noOfPlayers -= count;
            return true;
        }
    }

    public class Subteam : TeamInterface
    {
        public Subteam(string teamName, int noOfPlayers) : base(teamName, noOfPlayers){ }
        public void ChangeTeamName(string name)
        {
            base.teamName = name;
        }
    }
}