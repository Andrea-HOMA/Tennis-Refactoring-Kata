using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;
        private static string Love = "Love";
        private static string Fifteen = "Fifteen";
        private static string Thirty = "Thirty";
        private static string Forty = "Forty";
        private List<string> ScoreNames = new() { Love, Fifteen, Thirty, Forty };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (TryGetEndgameScore(out var endGameScore))
            {
                return endGameScore;
            }

            if (ScoreEqualScore(out var scoreName))
            {
                return scoreName;
            }

            if (p1point < 4 && p2point < 4)
            {
                return GetScoreBeforeAdvantage();    
            }


            return GetAdvantageScore();
        }

        private string GetAdvantageScore()
        {
            if (p1point > p2point)
            {
                return "Advantage player1";
            }

            return "Advantage player2";
        }

        private string GetScoreBeforeAdvantage()
        {
            return ScoreNames[p1point] + "-" + ScoreNames[p2point];
        }

        private bool ScoreEqualScore(out string scoreName)
        {
            if (p1point != p2point)
            {
                scoreName = null;
                return false;
            }

            if (p1point < 3)
            {
                scoreName = ScoreNames[p1point] + "-All";
                return true;
            }
            
            scoreName = "Deuce";
            return true;
        }

        private bool TryGetEndgameScore(out string endGameScore)
        {
            if (p1point >= 4 && (p1point - p2point) >= 2)
            {
                endGameScore = "Win for player1";
                return true;
            }

            if (p2point >= 4 && (p2point - p1point) >= 2)
            {
                endGameScore = "Win for player2";
                return true;
            }
            
            endGameScore = null;
            return false;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else
                p2point++;
        }

    }
}

