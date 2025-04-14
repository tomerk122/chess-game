
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using Chess;

namespace HalfChessClient
{
	public enum FinishReason
	{
		REASON_NONE,
		REASON_CHECK,
		REASON_STALEMATE,
		REASON_TIMEOVER,
		REASON_ONLYKINGS
	};

	public class GameEngine
	{
		public Board Board;		         
        public SideType GameTurn;        // current turn

		private Stack m_MovesHistory; 
		private Rules m_Rules;			    
		private Player m_WhitePlayer;	    // Player
		private Player m_BlackPlayer;       // Server
        private int m_maxThinkTime;
		private Game m_GameState;
		private int m_GameId;
		private bool m_Loading;
        
        public GameEngine(int gameId, SideType gameTurn, int maxThinkTime, Game gameState, bool isLoading)
		{

			Board = new Board();
            Board.Init();   // Initialize the board object
            m_maxThinkTime = maxThinkTime;
            m_Rules = new Rules(Board, this);	
			m_MovesHistory = new Stack();
            m_WhitePlayer = new Player(SideType.White, Player.Type.Player, m_Rules, m_maxThinkTime);	
            m_BlackPlayer = new Player(SideType.Black, Player.Type.Server, m_Rules, m_maxThinkTime);
			m_GameState = gameState;
			GameTurn = gameTurn;
			m_GameId = gameId;
			m_Loading = isLoading;

            m_WhitePlayer.ResetTime();
            m_BlackPlayer.ResetTime();

			if(GameTurn == SideType.White)
				m_WhitePlayer.TimeStart();  // Player time starts
			else
				m_BlackPlayer.TimeStart();
        }

		public Cell this[int row, int col]
		{
			get
			{
				return Board[row, col];
			}
		}

		// get the new item by string location
		public Cell this[string strloc]
		{
			get
			{
				return Board[strloc];	
			}
		}

		public void LoadBoard(string strBoard)
		{
			Board.JsonDeserialize(strBoard);
		}

        public Move GetRandomMove(SideType side)
        {
            ArrayList TotalMoves = m_Rules.GenerateAllLegalMoves(side); // Get all the legal moves for the current side
            Random random = new Random();
            int index = random.Next(TotalMoves.Count);
            return (Move)TotalMoves[index];
        }

        // Return back the white player reference
        public Player WhitePlayer
		{
			get
			{
				return m_WhitePlayer;
			}
		}

		// Return back the black player reference
		public Player BlackPlayer
		{
			get
			{
				return m_BlackPlayer;
			}
		}

		public void SetLoadingFlag(bool flag)
		{
			m_Loading = flag;
		}

		public Game GetGameState()
		{
			return m_GameState;
		}

		// Return back the given side type
        public Player GetPlayerBySide(SideType type)
		{
            if (type == SideType.Black)
				return m_BlackPlayer;
			else
				return m_WhitePlayer;
		}

		// Re-calculate the total thinking time of the player
		public void UpdateTime()
		{
			if (BlackTurn())	// Black player turn
				m_BlackPlayer.UpdateTime();
			else
				m_WhitePlayer.UpdateTime();
		}

		// Return true if it's black turn to move
		public bool BlackTurn()
		{
            return (GameTurn == SideType.Black);
		}

		// Return true if it's white turn to move
		public bool WhiteTurn()
		{
            return (GameTurn == SideType.White);
		}

		public void SetWinner(SideType side, FinishReason reason)
		{
			m_GameState.finshed = true;
			if (reason == FinishReason.REASON_ONLYKINGS)
				m_GameState.win = null;
			else if (side == SideType.Black)
				m_GameState.win = false;
			else
				m_GameState.win = true;
			m_GameState.finish_reason = (int)reason;


			string result;
			if (m_GameState.win == true)
			{
				result = "Win";  // Player wins
			}
			else if (m_GameState.finish_reason == (int)FinishReason.REASON_ONLYKINGS)
            {
                result = "Draw";  // Draw condition
            }
            else
            {
                result = "Lose";  // Player loses
            }
            if (!m_Loading)
                SaveGame();
            HttpClientHelper.Instance.EndAsync((int)m_GameState.game_id, result).GetAwaiter().GetResult();

          


        }

        // Set game turn for the next player
        public void NextPlayerTurn()
		{
            if (GameTurn == SideType.White)
			{
				m_WhitePlayer.TimeEnd();		
				m_BlackPlayer.TimeStart();		// Start player timer
                GameTurn = SideType.Black;      // Set black's turn
            }
            else
			{
				m_BlackPlayer.TimeEnd();
				m_WhitePlayer.TimeStart();		// Start player timer
                GameTurn = SideType.White;		// Set white's turn
			}
			
			if(!m_Loading)
				SaveGame();
        }

		public void SaveGame()
		{
			
			DbHelper.Instance.UpdateGameState(m_GameState);
			Move lastMove = GetLastMove();
			if(lastMove != null)
				DbHelper.Instance.AddMoveHistory((int)m_GameState.game_id, lastMove, m_MovesHistory.Count);
        }

        // Returns all the legal moves for the given cell
        public ArrayList GetLegalMoves(Cell source)
		{
			return m_Rules.GetLegalMoves(source);
		}




        /*Here is the connection between the Rectangle graphic class and the game board.
        First , we do a calculation to find the position of the square, 
		and then we make a link between the name and the Board*/
        // Create the move object and execute it
        public int DoMove(string source, string dest)
		{
			int MoveResult;
			
			// check if it's user turn to play
            if (this.Board[source].Piece != null && this.Board[source].Piece.Type != PieceType.Empty && this.Board[source].Piece.Side == GameTurn)
			{
				Move UserMove = new Move(this.Board[source], this.Board[dest]);	// create the move object,
																				// The connection is here!
				MoveResult = m_Rules.DoMove(UserMove);

				// If the move was successfully executed
				if (MoveResult == 0)
				{
					m_MovesHistory.Push(UserMove);
				}
			}
			else
				MoveResult=-1;
			return MoveResult;	// Executed
		}

		// Return true if the given side is checkmate
        public bool IsCheckMate(SideType PlayerSide)
		{
			return m_Rules.IsCheckMate(PlayerSide);
		}

		// Return true if the given side is stalemate
        public bool IsStaleMate(SideType PlayerSide)
		{
			return m_Rules.IsStaleMate(PlayerSide);
		}


		public bool IsOnlyKings()
		{
			return m_Rules.IsOnlyKings();
		}

		// Return true if the current player is under check
		public bool IsUnderCheck()
		{

			return m_Rules.IsUnderCheck(GameTurn);

		}
		 

		// Return the last executed move
		public Move GetLastMove()
		{
			// Check if there are Undo Moves available
			if (m_MovesHistory.Count>0)
			{
				return (Move)m_MovesHistory.Peek();	// Ge the user move from his moves history stack
			}
			return null;
		}
		
		public int GetMoveHistoryCount()
		{
			return m_MovesHistory.Count;
		}

		public void SetPromo(string loc, PieceType pieceType, SideType sideType)
		{
			Board[loc].Piece = new Piece(pieceType, sideType);
		}
	}
}
