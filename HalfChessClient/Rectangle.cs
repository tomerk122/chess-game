
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace HalfChessClient 
{
    /*
	 * The Rectangle class is responsible for drawing the chessboard cells and the tools within
	 * them in the graphical user interface (GUI).
	 * Each Rectangle represents a cell on the board.
	 * we are connecting between GUI to the Board in Board, UserMove.
	 */
    public class Rectangle
	{
		private MainWindow m_ParentWnd;
		private Point m_Location;
        private Size m_Size;

        public string Name { get; set; }
		public Rectangle(int row, int col, MainWindow parentgame)
		{
			m_ParentWnd = parentgame;

			m_Location = new System.Drawing.Point((col - 1)*55+33, (row-1)*55+33);	// move the piece place holder to it's proper location
			Name = ""+(char)(col+64)+row;	// Generate unique name for the place holder
			m_Size = new System.Drawing.Size(55, 55);
		}

		// Set the chess piece image
		public void DrawPiece(System.Drawing.Image pieceImage)
		{
			if(pieceImage == null) return;

            Graphics graphics = m_ParentWnd.CreateGraphics();
			// the location of the images
			graphics.DrawImage(pieceImage, m_Location.X + 2, m_Location.Y + 2);
			graphics.Dispose();
		}

		// Restore background
		public void RestoreBackground()
		{
			int col=char.Parse(Name.Substring(0,1).ToUpper())-64; // Get row from first ascii char i.e. a=1, b=2 and so on
			int row=int.Parse(Name.Substring(1,1));               // Get column value directly, as it's already numeric
            Graphics graphics = m_ParentWnd.CreateGraphics();

			//override the past pieces
			if (((row + col) % 2 == 0))
				graphics.FillRectangle(new SolidBrush(Color.Black), m_Location.X, m_Location.Y, m_Size.Width, m_Size.Height);
			else
				graphics.FillRectangle(new SolidBrush(Color.White), m_Location.X, m_Location.Y, m_Size.Width, m_Size.Height);
			
			graphics.Dispose();
        }

		// color the next turns
		public void FillBackground(Color color, int alpha)
		{
            Graphics graphics = m_ParentWnd.CreateGraphics();
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(alpha, color.R, color.G, color.B)), m_Location.X, m_Location.Y, m_Size.Width, m_Size.Height);
			graphics.Dispose();
        }

		public void DrawCircle(Color color)
		{

            //Graphics graphics = m_ParentWnd.CreateGraphics();
            //graphics.FillEllipse(new SolidBrush(color), m_Location.X, m_Location.Y, m_Size.Width, m_Size.Height);
            //graphics.Dispose();
            Graphics graphics = m_ParentWnd.CreateGraphics();

           
            Color highlightColor = Color.FromArgb(154, 255, 255, 0);

         
            graphics.FillRectangle(new SolidBrush(highlightColor), m_Location.X, m_Location.Y, m_Size.Width, m_Size.Height);
            graphics.Dispose();


        }
	}
}
