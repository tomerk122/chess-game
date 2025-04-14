
using System;

namespace HalfChessServer.Api.Game
{
    public enum PieceType { Empty, King, Rook, Bishop, Knight, Pawn };
    public enum SideType { White, Black };

    public class Piece
    {
        int m_moves;
        SideType m_side;
        PieceType m_type;


        public Piece()
        {
            Type = PieceType.Empty;
        }

        public Piece(PieceType type)
        {
            m_type = type;
        }

        public Piece(PieceType type, SideType side)
        {
            m_type = type;
            m_side = side;
        }

        public bool IsEmpty()
        {
            return m_type == PieceType.Empty;
        }

        public bool IsPawn()
        {
            return m_type == PieceType.Pawn;
        }

        public bool IsKnight()
        {
            return m_type == PieceType.Knight;
        }

        public bool IsBishop()
        {
            return m_type == PieceType.Bishop;
        }

        public bool IsRook()
        {
            return m_type == PieceType.Rook;
        }


        public bool IsKing()
        {
            return m_type == PieceType.King;
        }

        public override string ToString()
        {
            switch (m_type)
            {
                case PieceType.King:
                    return "King";
                case PieceType.Bishop:
                    return "Bishop";
                case PieceType.Rook:
                    return "Rook";
                case PieceType.Knight:
                    return "Knight";
                case PieceType.Pawn:
                    return "Pawn";
                default:
                    return "E";
            }
        }

        #region Class attributes set and get methods
        // Get and set the cell row
        public PieceType Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        // Get and set the piece side
        public SideType Side
        {
            get
            {
                return m_side;
            }
            set
            {
                m_side = value;
            }
        }

        // Get and set the piece moves
        public int Moves
        {
            get
            {
                return m_moves;
            }
            set
            {
                m_moves = value;
            }
        }
        #endregion
    }
}
