
using System;

namespace HalfChessClient
{

	public class Cell
	{
		public Cell()
		{
			Row = 0;
			Col = 0;
		}

		public Cell(int row, int col)
		{
			Row = row;
			Col = col;
		}

		public Cell(string strLoc)
		{
			if(strLoc.Length == 2)
			{
				Col = char.Parse(strLoc.Substring(0, 1).ToUpper()) - 64; // get column from ascii char
				Row = int.Parse(strLoc.Substring(1, 1));	
			}
		}

        public bool IsEmpty()
        {
            return Piece == null || Piece.Type == PieceType.Empty;
        }

        public bool IsOwnedByEnemy(Cell other)
        {
            if (IsEmpty())
                return false;
            else
                return Piece.Side != other.Piece.Side;
        }

        public bool IsOwned(Cell other)
        {
            if (IsEmpty())
                return false;
            else
                return Piece.Side == other.Piece.Side;
        }
        
		public override string ToString()
		{
			string strLoc = "";
			strLoc = Convert.ToString(Convert.ToChar(Col + 64));	// convert column to ascii char
			strLoc += Row.ToString();
			return strLoc;	
		}

		public override bool Equals(object obj)
		{
			if (obj is Cell)
			{
				Cell cellObj = (Cell)obj;
				
				return (cellObj.Row == Row && cellObj.Col == Col);			   
			}
			return false;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region Attributes
		public int Row { get; set; }
		public int Col { get; set; }
		public Piece Piece {  get; set; }
		#endregion
	}
}
