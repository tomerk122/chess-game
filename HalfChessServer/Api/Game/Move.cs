using Newtonsoft.Json;
using System;

namespace HalfChessServer.Api.Game
{
    public class Move
    {
        public enum MoveType { NormalMove, CaputreMove };

        private Cell m_StartCell;
        private Cell m_EndCell;
        private Piece m_Piece;
        private Piece m_CapturedPiece;
        private MoveType m_Type;
        private bool m_CauseCheck;

        internal Move()
        {
        }

        public Move(Cell begin, Cell end)
        {
            m_StartCell = begin;
            m_EndCell = end;
            m_Piece = begin.piece;
            m_CapturedPiece = end.piece;
        }

        public Cell StartCell
        {
            get
            {
                return m_StartCell;
            }
            set
            {
                m_StartCell = value;
            }
        }

        public Cell EndCell
        {
            get
            {
                return m_EndCell;
            }
            set
            {
                m_EndCell = value;
            }
        }

        public Piece Piece
        {
            get
            {
                return m_Piece;
            }
            set
            {
                m_Piece = value;
            }
        }

        public Piece CapturedPiece
        {
            get
            {
                return m_CapturedPiece;
            }
            set
            {
                m_CapturedPiece = value;
            }
        }

        public MoveType Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        public bool CauseCheck
        {
            get
            {
                return m_CauseCheck;
            }
            set
            {
                m_CauseCheck = value;
            }
        }

        public bool IsCaptureMove()
        {
            return m_Type == MoveType.CaputreMove;
        }

        //public string JsonSerialize()
        //{
        //    string output = JsonConvert.SerializeObject(this);
        //    return output;
        //}
    }

}
