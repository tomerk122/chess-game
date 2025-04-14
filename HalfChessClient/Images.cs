
using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace HalfChessClient
{
	public class Images
	{
		private ArrayList ImageList;		// store list of image list

		public Images()
		{
            ImageList = new ArrayList();
		}

		public void LoadImages(string SourceDir)
		{

            // Read and store the image black and white image paths
          
            ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "White.jpg"));
            ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "Black.jpg"));
            // Read and store the white pieces images
            ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "king.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "bishop.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "knight.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "rook.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "pawn.gif"));
			// Read and store the black pieces images
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "king_2.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "bishop_2.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "knight_2.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "rook_2.gif"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "pawn_2.gif"));
			// Read and store the image black and white image paths
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "Black_2.jpg"));
			ImageList.Add(System.Drawing.Image.FromFile(SourceDir + "White_2.jpg"));
		}

		// Get Image by name i.e. White or Black
		public Image this[string strName]
		{
			get 
			{
				switch (strName)	// check string type
				{
					case "White":
						return (Image)ImageList[0];
					case "Black":
						return (Image)ImageList[1];
					case "White2":
						return (Image)ImageList[12];
					case "Black2":
						return (Image)ImageList[13];
					default:
						return null;

				}
				
			}
		}

		// Return image for the given piece type
		public Image GetImageForPiece(Piece Piece)
		{
			// Not a valid chess piece
			if (Piece == null || Piece.Type == PieceType.Empty )
				return null;

			// check and return the white piece image
			if (Piece.Side == SideType.White)
				switch(Piece.Type)
				{
					case PieceType.King:
						return (Image)ImageList[2];
					case PieceType.Bishop:
						return (Image)ImageList[3];
					case PieceType.Knight:
						return (Image)ImageList[4];
					case PieceType.Rook:
						return (Image)ImageList[5];
					case PieceType.Pawn:
						return (Image)ImageList[6];
					default:
						return null;
				}
			else
				switch(Piece.Type)
				{
					case PieceType.King:
						return (Image)ImageList[7];
					case PieceType.Bishop:
						return (Image)ImageList[8];
					case PieceType.Knight:
						return (Image)ImageList[9];
					case PieceType.Rook:
						return (Image)ImageList[10];
					case PieceType.Pawn:
						return (Image)ImageList[11];
					default:
						return null;
				}
		}
	}
}
