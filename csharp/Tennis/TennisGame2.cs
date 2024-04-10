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
            var score = "";
            if (p1point == p2point && p1point < 3)
            {
                if (p1point == 0)
                {
                    score = Love;
                }

                if (p1point == 1)
                    score = Fifteen;
                if (p1point == 2)
                    score = Thirty;
                score += "-All";
            }
            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            Forty = "Forty";
            if (p1point > 0 && p2point == 0)
            {
                if (p1point == 1)
                    p1res = Fifteen;
                if (p1point == 2)
                    p1res = Thirty;
                if (p1point == 3)
                    p1res = Forty;

                p2res = Love;
                score = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                if (p2point == 1)
                    p2res = Fifteen;
                if (p2point == 2)
                    p2res = Thirty;
                if (p2point == 3)
                    p2res = Forty;

                p1res = Love;
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                if (p1point == 2)
                    p1res = Thirty;
                if (p1point == 3)
                    p1res = Forty;
                if (p2point == 1)
                    p2res = Fifteen;
                if (p2point == 2)
                    p2res = Thirty;
                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                if (p2point == 2)
                    p2res = Thirty;
                if (p2point == 3)
                    p2res = Forty;
                if (p1point == 1)
                    p1res = Fifteen;
                if (p1point == 2)
                    p1res = Thirty;
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

