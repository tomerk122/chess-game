
using System;
using System.Collections;

namespace HalfChessServer.Api.Game
{
    public class Rules
    {
        private Board m_Board;  // store a reference to the game board
        private Game m_Game;    // store a reference to the current game

        public Rules(Board board, Game game)
        {
            m_Board = board;
            m_Game = game;
        }

        public Board ChessBoard
        {
            get
            {
                return m_Board;
            }
        }

        public Game ChessGame
        {
            get
            {
                return m_Game;
            }
        }

        public bool IsCheckMate(SideType PlayerSide)
        {
            if (IsUnderCheck(PlayerSide) && GetCountOfPossibleMoves(PlayerSide) == 0)
                return true;    // player is checkmate
            else
                return false;
        }

        public bool IsStaleMate(SideType PlayerSide)
        {
            if (!IsUnderCheck(PlayerSide) && GetCountOfPossibleMoves(PlayerSide) == 0)
                return true;    // player is checkmate
            else
                return false;
        }

        public int DoMove(Move move)
        {
            ArrayList LegalMoves = GetLegalMoves(m_Board[move.StartCell]);

            if (!LegalMoves.Contains(m_Board[move.EndCell]))
                return -2;

            SetMoveType(move);
            ExecuteMove(move);

            return 0;   // Executed
        }

        public void ExecuteMove(Move move)
        {
            switch (move.Type)
            {
                case Move.MoveType.CaputreMove:
                    DoNormalMove(move);
                    break;

                case Move.MoveType.NormalMove:
                    DoNormalMove(move);
                    break;
            }
        }

        private void SetMoveType(Move move)
        {
            move.Type = Move.MoveType.NormalMove;

            if (move.EndCell.piece != null && move.EndCell.piece.Type != PieceType.Empty)
                move.Type = Move.MoveType.CaputreMove;
        }

        private void DoNormalMove(Move move)
        {
            m_Board[move.StartCell].piece.Moves++;  // incremenet moves
            m_Board[move.EndCell].piece = m_Board[move.StartCell].piece;
            m_Board[move.StartCell].piece = new Piece(PieceType.Empty);
        }

        public void UndoMove(Move move)
        {
            if (move.Type == Move.MoveType.CaputreMove || move.Type == Move.MoveType.NormalMove)
                UndoNormalMove(move);
        }

        private void UndoNormalMove(Move move)
        {
            m_Board[move.EndCell].piece = move.CapturedPiece;
            m_Board[move.StartCell].piece = move.Piece;
            m_Board[move.StartCell].piece.Moves--;
        }

        public bool IsUnderCheck(SideType PlayerSide)
        {
            Cell OwnerKingCell = null;
            ArrayList OwnerCells = m_Board.GetSideCell(PlayerSide);

            foreach (string CellName in OwnerCells)
            {
                if (m_Board[CellName].piece.Type == PieceType.King)
                {
                    OwnerKingCell = m_Board[CellName];
                    break;
                }
            }

            SideType enemyType = PlayerSide == SideType.Black ? SideType.White : SideType.Black;
            ArrayList EnemyCells = m_Board.GetSideCell(enemyType);
            foreach (string CellName in EnemyCells)
            {
                ArrayList moves = GetPossibleMoves(m_Board[CellName]);
                if (moves.Contains(OwnerKingCell))
                    return true;
            }
            return false;
        }

        private int GetCountOfPossibleMoves(SideType PlayerSide)
        {
            int TotalMoves = 0;

            ArrayList PlayerCells = m_Board.GetSideCell(PlayerSide);
            foreach (string CellName in PlayerCells)
            {
                ArrayList moves = GetLegalMoves(m_Board[CellName]);
                TotalMoves += moves.Count;
            }
            return TotalMoves;
        }

        private bool CauseCheck(Move move)
        {
            bool causeCheck = false;
            SideType PlayerSide = move.StartCell.piece.Side;

            ExecuteMove(move);
            causeCheck = IsUnderCheck(PlayerSide);
            UndoMove(move); // undo the move

            return causeCheck;
        }

        public ArrayList GetLegalMoves(Cell source)
        {
            ArrayList LegalMoves;

            LegalMoves = GetPossibleMoves(source);
            ArrayList ToRemove = new ArrayList();

            foreach (Cell target in LegalMoves)
            {
                if (CauseCheck(new Move(source, target)))
                    ToRemove.Add(target);
            }

            if (source.piece.Type == PieceType.King && IsUnderCheck(source.piece.Side))
            {
                foreach (Cell target in LegalMoves)
                {
                    if (Math.Abs(target.col - source.col) > 1)
                        ToRemove.Add(target);
                }
            }

            foreach (Cell cell in ToRemove)
            {
                LegalMoves.Remove(cell);
            }
            return LegalMoves;
        }

        public ArrayList GenerateAllLegalMoves(SideType PlayerSide)
        {
            ArrayList TotalMoves = new ArrayList();
            ArrayList PlayerCells = m_Board.GetSideCell(PlayerSide);
            Move move;

            foreach (string CellName in PlayerCells)
            {
                ArrayList moves = GetLegalMoves(m_Board[CellName]);

                foreach (Cell dest in moves)
                {
                    move = new Move(m_Board[CellName], dest);
                    SetMoveType(move);

                    TotalMoves.Add(move);
                }
            }

            return TotalMoves;
        }

        public ArrayList GetPossibleMoves(Cell source)
        {
            ArrayList LegalMoves = new ArrayList();

            // Check the legal moves for the object
            switch (source.piece.Type)
            {
                case PieceType.Empty:   // cell is empty
                    break;

                case PieceType.Pawn:    // Pawn object
                    GetPawnMoves(source, LegalMoves);
                    break;

                case PieceType.Knight:  // Knight object
                    GetKnightMoves(source, LegalMoves);
                    break;

                case PieceType.Rook:    // Rook piece
                    GetRookMoves(source, LegalMoves);
                    break;

                case PieceType.Bishop:  // Bishop piece
                    GetBishopMoves(source, LegalMoves);
                    break;


                case PieceType.King:    // king piece
                    GetKingMoves(source, LegalMoves);
                    break;
            }

            return LegalMoves;
        }

        private void GetPawnMoves(Cell source, ArrayList moves)
        {
            Cell newcell;

            if (source.piece.Side == SideType.White)
            {
                newcell = m_Board.TopCell(source);
                if (newcell != null && newcell.IsEmpty())
                    moves.Add(newcell);

                // Check the 2nd top element from source
                if (newcell != null && newcell.IsEmpty())
                {
                    newcell = m_Board.TopCell(newcell);
                    if (newcell != null && source.piece.Moves == 0 && newcell.IsEmpty()) // 2nd top cell is available and piece has not yet moved
                        moves.Add(newcell);
                }

                // Check top-left cell for enemy piece
                newcell = m_Board.TopLeftCell(source);
                if (newcell != null && newcell.IsOwnedByEnemy(source)) // Top cell is available for the move
                    moves.Add(newcell);

                // Check top-right cell for enemy piece
                newcell = m_Board.TopRightCell(source);
                if (newcell != null && newcell.IsOwnedByEnemy(source)) // Top cell is available for the move
                    moves.Add(newcell);

                // check left cell 
                newcell = m_Board.LeftCell(source);
                if (newcell != null && newcell.IsEmpty()) // Top cell is available for the move
                    moves.Add(newcell);

                // check right cell
                newcell = m_Board.RightCell(source);
                if (newcell != null && newcell.IsEmpty()) // Top cell is available for the move
                    moves.Add(newcell);
            }
            else
            {
                // Calculate moves for the black piece
                newcell = m_Board.BottomCell(source);
                if (newcell != null && newcell.IsEmpty()) // bottom cell is available for the move
                    moves.Add(newcell);

                // Check the 2nd bottom cell from source
                if (newcell != null && newcell.IsEmpty())
                {
                    newcell = m_Board.BottomCell(newcell);
                    if (newcell != null && source.piece.Moves == 0 && newcell.IsEmpty()) // 2nd bottom cell is available and piece has not yet moved
                        moves.Add(newcell);
                }

                // Check bottom-left cell for enemy piece
                newcell = m_Board.BottomLeftCell(source);
                if (newcell != null && newcell.IsOwnedByEnemy(source)) // Bottom cell is available for the move
                    moves.Add(newcell);

                // Check bottom-right cell for enemy piece
                newcell = m_Board.BottomRightCell(source);
                if (newcell != null && newcell.IsOwnedByEnemy(source)) // Bottom cell is available for the move
                    moves.Add(newcell);

                // check left cell
                newcell = m_Board.LeftCell(source);
                if (newcell != null && newcell.IsEmpty()) // Top cell is available for the move
                    moves.Add(newcell);

                // check right cell
                newcell = m_Board.RightCell(source);
                if (newcell != null && newcell.IsEmpty()) // Top cell is available for the move
                    moves.Add(newcell);
            }
        }

        // calculate the possible moves for the knight piece and insert them into passed array
        private void GetKnightMoves(Cell source, ArrayList moves)
        {
            Cell newcell;

            // First check top two left and right moves for knight
            newcell = m_Board.TopCell(source);
            if (newcell != null)
            {
                newcell = m_Board.TopLeftCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);

                newcell = m_Board.TopCell(source);
                newcell = m_Board.TopRightCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);
            }
            // Now check 2nd bottom left and right cells
            newcell = m_Board.BottomCell(source);
            if (newcell != null)
            {
                newcell = m_Board.BottomLeftCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);

                newcell = m_Board.BottomCell(source);
                newcell = m_Board.BottomRightCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);
            }
            // Now check 2nd Left Top and bottom cells
            newcell = m_Board.LeftCell(source);
            if (newcell != null)
            {
                newcell = m_Board.TopLeftCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);

                newcell = m_Board.LeftCell(source);
                newcell = m_Board.BottomLeftCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);
            }
            // Now check 2nd Right Top and bottom cells
            newcell = m_Board.RightCell(source);
            if (newcell != null)
            {
                newcell = m_Board.TopRightCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);

                newcell = m_Board.RightCell(source);
                newcell = m_Board.BottomRightCell(newcell);
                // target cell is empty or is owned by the enemy piece
                if (newcell != null && !newcell.IsOwned(source))
                    moves.Add(newcell);
            }
        }

        // calculate the possible moves for the Rook piece and insert them into passed array
        private void GetRookMoves(Cell source, ArrayList moves)
        {
            Cell newcell;

            // Check all the move squars available in top direction
            newcell = m_Board.TopCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.TopCell(newcell); // keep moving in the top direction
            }

            // Check all the move squars available in left direction
            newcell = m_Board.LeftCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.LeftCell(newcell); // keep moving in the left direction
            }

            // Check all the move squars available in right direction
            newcell = m_Board.RightCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.RightCell(newcell); // keep moving in the right direction
            }

            // Check all the move squars available in bottom direction
            newcell = m_Board.BottomCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.BottomCell(newcell); // keep moving in the bottom direction
            }
        }

        // calculate the possible moves for the bishop piece and insert them into passed array
        private void GetBishopMoves(Cell source, ArrayList moves)
        {
            Cell newcell;

            // Check all the move squars available in top-left direction
            newcell = m_Board.TopLeftCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.TopLeftCell(newcell); // keep moving in the top-left direction
            }

            // Check all the move squars available in top-right direction
            newcell = m_Board.TopRightCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.TopRightCell(newcell); // keep moving in the top-right direction
            }

            // Check all the move squars available in bottom-left direction
            newcell = m_Board.BottomLeftCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.BottomLeftCell(newcell); // keep moving in the bottom-left direction
            }

            // Check all the move squars available in the bottom-right direction
            newcell = m_Board.BottomRightCell(source);
            while (newcell != null) // move as long as cell is available in this direction
            {
                if (newcell.IsEmpty())  //next cell is available for move
                    moves.Add(newcell);

                if (newcell.IsOwnedByEnemy(source)) //next cell is owned by the enemy object
                {
                    moves.Add(newcell); // Add this to available location
                    break;  // force quite the loop execution
                }

                if (newcell.IsOwned(source))    //next cell contains owner object
                    break;  // force quite the loop execution

                newcell = m_Board.BottomRightCell(newcell); // keep moving in the bottom-right direction
            }
        }

        private void GetKingMoves(Cell source, ArrayList moves)
        {
            Cell newcell;

            // check if king can move to top
            newcell = m_Board.TopCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to left
            newcell = m_Board.LeftCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to right
            newcell = m_Board.RightCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to bottom
            newcell = m_Board.BottomCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to top-left
            newcell = m_Board.TopLeftCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to top-right
            newcell = m_Board.TopRightCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to bottom-left
            newcell = m_Board.BottomLeftCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);
            // check if king can move to bottom-right
            newcell = m_Board.BottomRightCell(source);
            if (newcell != null && !newcell.IsOwned(source)) // target cell is empty or is owned by the enemy piece
                moves.Add(newcell);

            // Check castling or tower moves for the king
            if (m_Board[source].piece.Moves == 0)
            {
                Cell CastlingTarget = null; // The cell where king will be moved in case of castling

                // As king has not yet moved, so castling is possible
                newcell = m_Board.RightCell(source);
                if (newcell != null && newcell.IsEmpty())   // cell is empty
                {
                    if (!CauseCheck(new Move(source, newcell))) // Inbetween cell is not under check
                    {
                        newcell = m_Board.RightCell(newcell);
                        if (newcell != null && newcell.IsEmpty())   // cell is empty
                        {
                            CastlingTarget = newcell;	// This will be the king destination position
                            newcell = m_Board.RightCell(newcell);
                            if (newcell != null && !newcell.IsEmpty() && newcell.piece.Moves == 0)  // check if the rook piece has not yet moved
                                moves.Add(CastlingTarget);  // Add this as possible move
                        }
                    }
                }

                // Check on the left side
                newcell = m_Board.LeftCell(source);
                if (newcell != null && newcell.IsEmpty())   // cell is empty
                {
                    if (!CauseCheck(new Move(source, newcell))) // Inbetween cell is not under check
                    {
                        newcell = m_Board.LeftCell(newcell);
                        if (newcell != null && newcell.IsEmpty())   // cell is empty
                        {
                            CastlingTarget = newcell;	// This will be the king destination position
                            newcell = m_Board.LeftCell(newcell);
                            if (newcell != null && newcell.IsEmpty())   // cell is empty
                            {
                                newcell = m_Board.LeftCell(newcell);
                                if (newcell != null && !newcell.IsEmpty() && newcell.piece.Moves == 0)  // check if the rook piece has not yet moved
                                    moves.Add(CastlingTarget);  // Add this as possible move
                            }
                        }

                    }
                }
            }
        }
    }
}
