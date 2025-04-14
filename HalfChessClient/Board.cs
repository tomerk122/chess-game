
using System;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;

namespace HalfChessClient
{
	public class Board
	{
		private Cells cells;	

		public Board()
		{
			cells = new Cells();
		}

		public void Init()
		{
			cells.Clear();   

			for (int row = 1; row <= 8; row++)
			{
				for (int col = 1; col <= 4; col++)
				{
                    Cell newCell = new Cell(row, col);
                    newCell.Piece = new Piece(PieceType.Empty, SideType.White);
                    cells.Add(newCell);
                    
				}
			}

            cells["a1"].Piece = new Piece(PieceType.King, SideType.Black);
            cells["b1"].Piece = new Piece(PieceType.Knight, SideType.Black);
            cells["c1"].Piece = new Piece(PieceType.Bishop, SideType.Black);
            cells["d1"].Piece = new Piece(PieceType.Rook, SideType.Black);
            for (int col = 1; col <= 4; col++)
                cells[2, col].Piece = new Piece(PieceType.Pawn, SideType.Black);

            cells["a8"].Piece = new Piece(PieceType.King, SideType.White);
            cells["b8"].Piece = new Piece(PieceType.Knight, SideType.White);
            cells["c8"].Piece = new Piece(PieceType.Bishop, SideType.White);
            cells["d8"].Piece = new Piece(PieceType.Rook, SideType.White);
            for (int col = 1; col <= 4; col++)
                cells[7, col].Piece = new Piece(PieceType.Pawn, SideType.White);
        }

		public Cell this[int row, int col]
		{
			get
			{
				return cells[row, col];
			}
		}

		public Cell this[string strloc]
		{
			get
			{
				return cells[strloc];	
			}
		}

		public Cell this[Cell cell]
		{
			get
			{
				return cells[cell.ToString()];	
			}
		}

        public ArrayList GetAllCells()
        {
            ArrayList CellNames = new ArrayList();

            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 4; col++)
                {
                    CellNames.Add(this[row, col].ToString());
                }
            }

            return CellNames;
        }

        public ArrayList GetSideCell(SideType PlayerSide)
        {
            ArrayList CellNames = new ArrayList();

            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 4; col++)
                {
                    if (this[row, col].Piece != null
                        && !this[row, col].IsEmpty()
                        && this[row, col].Piece.Side == PlayerSide)
                        CellNames.Add(this[row, col].ToString());
                }
            }
            return CellNames;
        }

        public string GetKingPosName(SideType PlayerSide)
        {
            string kingPosName = "";
            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 4; col++)
                {
                    if (this[row, col].Piece != null
                        && !this[row, col].IsEmpty()
                        && this[row, col].Piece.Side == PlayerSide
                        && this[row, col].Piece.IsKing())
                        kingPosName = this[row, col].ToString();
                }
            }
            return kingPosName;
        }

        public Cell TopCell(Cell cell)
        {
            return this[cell.Row - 1, cell.Col];
        }

        public Cell LeftCell(Cell cell)
        {
            return this[cell.Row, cell.Col - 1];
        }

        public Cell RightCell(Cell cell)
        {
            return this[cell.Row, cell.Col + 1];
        }

        public Cell BottomCell(Cell cell)
        {
            return this[cell.Row + 1, cell.Col];
        }

        public Cell TopLeftCell(Cell cell)
        {
            return this[cell.Row - 1, cell.Col - 1];
        }

        public Cell TopRightCell(Cell cell)
        {
            return this[cell.Row - 1, cell.Col + 1];
        }

        public Cell BottomLeftCell(Cell cell)
        {
            return this[cell.Row + 1, cell.Col - 1];
        }

        public Cell BottomRightCell(Cell cell)
        {
            return this[cell.Row + 1, cell.Col + 1];
        }
        public string JsonSerialize()
        {
            string output =cells.JsonSerialize();
            return output;
        }

		public void JsonDeserialize(string json)
		{
			cells.JsonDeserialize(json);
		}
	}
}
