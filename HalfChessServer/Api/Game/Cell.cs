
using System;

namespace HalfChessServer.Api.Game
{

    public class Cell
    {
        Piece m_piece;
        int m_row;
        int m_col;

        public Cell()
        {
            m_row = 0;
            m_col = 0;
        }

        public Cell(int row, int col)
        {
            m_row = row;
            m_col = col;
        }

        public Cell(string strLoc)
        {
            if (strLoc.Length == 2)
            {
                m_col = char.Parse(strLoc.Substring(0, 1).ToUpper()) - 64; // get column from ascii char
                m_row = int.Parse(strLoc.Substring(1, 1));
            }
        }

        public bool IsEmpty()
        {
            return m_piece == null || m_piece.Type == PieceType.Empty;
        }

        public bool IsOwnedByEnemy(Cell other)
        {
            if (IsEmpty())
                return false;
            else
                return m_piece.Side != other.piece.Side;
        }

        public bool IsOwned(Cell other)
        {
            if (IsEmpty())
                return false;
            else
                return m_piece.Side == other.piece.Side;
        }

        public override string ToString()
        {
            string strLoc = "";
            strLoc = Convert.ToString(Convert.ToChar(col + 64));    // convert column to ascii char
            strLoc += row.ToString();
            return strLoc;
        }

        public override bool Equals(object obj)
        {
            if (obj is Cell)
            {
                Cell cellObj = (Cell)obj;

                return cellObj.row == row && cellObj.col == col;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region Attributes
        public int row
        {
            get
            {
                return m_row;
            }
            set
            {
                m_row = value;
            }
        }

        public int col
        {
            get
            {
                return m_col;
            }
            set
            {
                m_col = value;
            }
        }

        public Piece piece
        {
            get
            {
                return m_piece;
            }
            set
            {
                m_piece = value;
            }
        }
        #endregion
    }
}
