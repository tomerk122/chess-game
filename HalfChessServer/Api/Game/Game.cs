
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace HalfChessServer.Api.Game
{
    public class Game
    {
        public Board Board;
        private Rules m_Rules;


        public Game()
        {
            Board = new Board();
            m_Rules = new Rules(Board, this);
            Board.Init();
        }

        public Move GetRandomMove(SideType side)
        {
            ArrayList TotalMoves = m_Rules.GenerateAllLegalMoves(side); // Get all the legal moves for the current side
            Random random = new Random();
            int index = random.Next(TotalMoves.Count);
            return (Move)TotalMoves[index];
        }

        public void LoadBoard(string strBoard)
        {
            Board.JsonDeserialize(strBoard);
        }
    }
}
