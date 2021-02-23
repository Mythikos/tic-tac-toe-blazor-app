using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TicTacToe.Library.Models
{
    public class GameData
    {
        public enum GameStates
        {
            PlayerOneMove,
            PlayerTwoMove,
            GameOver_PlayerOneWins,
            GameOver_PlayerTwoWins,
            GameOver_Draw,
            None
        }

        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public string PlayerOneCharacterId { get; set; }
        public string PlayerTwoCharacterId { get; set; }
        public bool PlayerOneIsAI { get; set; }
        public bool PlayerTwoIsAI { get; set; }

        public GameStates GameState { get; set; }
        public int GamesPlayed { get; set; }
        public TicTacToe.Board GameBoard { get; set; }
        

        public List<string> AISmackTalkPhrases;
        public List<string> AILostPhrases;
        public List<string> AIWonPhrases;
        public List<string> AIDrawPhrases;
    }
}
