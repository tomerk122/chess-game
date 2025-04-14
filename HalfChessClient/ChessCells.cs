
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HalfChessClient
{
    public class Cells
    {
        private Dictionary<string, Cell> m_Cells;

        public Cells()
        {
            m_Cells = new Dictionary<string, Cell>();
        }

        private string GetKey(Cell cell)
        {
            return "" + cell.Row + cell.Col;
        }

        private string GetKey(int row, int col)
        {
            return "" + row + col;
        }

        public void Add(Cell cell)
        {
            string key = GetKey(cell);
            if (!m_Cells.ContainsKey(key))
            {
                m_Cells.Add(key, cell);
            }
        }

        public void Remove(int row, int col)
        {
            string key = GetKey(row, col);
            m_Cells.Remove(key);
        }

        public void Clear()
        {
            m_Cells.Clear();
        }

        public string JsonSerialize()
        {
            bool first = true;
            string output = "[";
            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 4; col++)
                {
                    Cell cell = this[row, col];

                    if (cell != null)
                    {
                        if (!first)
                        {
                            output += ",";
                        }
                        output += JsonConvert.SerializeObject(cell);
                        first = false;
                    }
                }
            }
            output += "]";

            return output;
        }

        public void JsonDeserialize(string json)
        {
            var cellList = JsonConvert.DeserializeObject<List<Cell>>(json);
            foreach (Cell cell in cellList)
            {
                m_Cells[GetKey(cell)] = cell;
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                m_Cells.TryGetValue(GetKey(row, col), out Cell cell);
                return cell;
            }
        }

        public Cell this[string strLoc]
        {
            get
            {
                int col = char.ToUpper(strLoc[0]) - 'A' + 1;
                int row = int.Parse(strLoc.Substring(1, 1));
                m_Cells.TryGetValue(GetKey(row, col), out Cell cell);
                return cell;
            }
        }
    }
}
