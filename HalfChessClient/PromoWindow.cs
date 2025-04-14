using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfChessClient
{
    public partial class PromoWindow : Form
    {
        public PieceType PromoPieceType;
        private SideType m_SideType;

        public PromoWindow(MainWindow parent, SideType sideType)
        {
            InitializeComponent();
            pictureBox_rook.Image = parent.ChessImages.GetImageForPiece(new Piece(PieceType.Rook, sideType));
            pictureBox_knight.Image = parent.ChessImages.GetImageForPiece(new Piece(PieceType.Knight, sideType));
            pictureBox_bishop.Image = parent.ChessImages.GetImageForPiece(new Piece(PieceType.Bishop, sideType));
            m_SideType = sideType;
            PromoPieceType = PieceType.Rook;
        }

        private void pictureBox_rook_Click(object sender, EventArgs e)
        {
            PromoPieceType = PieceType.Rook;
            this.Close();
        }

        private void pictureBox_knight_Click(object sender, EventArgs e)
        {
            PromoPieceType = PieceType.Knight;
            this.Close();
        }

        private void pictureBox_bishop_Click(object sender, EventArgs e)
        {
            PromoPieceType = PieceType.Bishop;
            this.Close();
        }
    }
}
