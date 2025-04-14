
using System;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;

namespace HalfChessServer.Api.Game
{
    public class Board
    {
        private Cells m_cells;

        public Board()
        {
            m_cells = new Cells();
        }

        public void Init()
        {
            m_cells.Clear();

            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 4; col++)
                {
                    m_cells.Add(new Cell(row, col));
                }
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                return m_cells[row, col];
            }
        }

        public Cell this[string strloc]
        {
            get
            {
                return m_cells[strloc];
            }
        }

        public Cell this[Cell cell]
        {
            get
            {
                return m_cells[cell.ToString()];
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
                    if (this[row, col].piece != null
                        && !this[row, col].IsEmpty()
                        && this[row, col].piece.Side == PlayerSide)
                        CellNames.Add(this[row, col].ToString());
                }
            }
            return CellNames;
        }

        public Cell TopCell(Cell cell)
        {
            return this[cell.row - 1, cell.col];
        }

        public Cell LeftCell(Cell cell)
        {
            return this[cell.row, cell.col - 1];
        }

        public Cell RightCell(Cell cell)
        {
            return this[cell.row, cell.col + 1];
        }

        public Cell BottomCell(Cell cell)
        {
            return this[cell.row + 1, cell.col];
        }

        public Cell TopLeftCell(Cell cell)
        {
            return this[cell.row - 1, cell.col - 1];
        }

        public Cell TopRightCell(Cell cell)
        {
            return this[cell.row - 1, cell.col + 1];
        }

        public Cell BottomLeftCell(Cell cell)
        {
            return this[cell.row + 1, cell.col - 1];
        }

        public Cell BottomRightCell(Cell cell)
        {
            return this[cell.row + 1, cell.col + 1];
        }
        public string JsonSerialize()
        {
            string output = m_cells.JsonSerialize();
            return output;
        }

        public void JsonDeserialize(string json)
        {
            m_cells.JsonDeserialize(json);
        }
    }
}
