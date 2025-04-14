using Chess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HalfChessClient
{
    public partial class MainWindow : Form
    {
       


        private int LENGTH = 55;
        private int BOARD_MIN_X = 33;
        private int BOARD_MIN_Y = 33;
        private int BOARD_MAX_X = 33 + 55 * 4;
        private int BOARD_MAX_Y = 33 + 55 * 8;

        private bool m_painting;
        private Point m_MousePos;

        private ArrayList rectangles;
        public Images ChessImages;
        private string ResourceFolder;

        public GameEngine m_chessGame;

        public string selected_rect_name;

        public bool IsRunning;
        public bool IsOver;

        private bool IsWatchingMode = false;


        public PlayerInfo playerInfo;

        private string kingUnderCheck;
        private int animation_count;
        private bool IsLoading;
        private List<Move> m_LoadedMoves;
        private int m_LoadedMoveIndex;
        private int time_count;
        public MainWindow()
        {
            InitializeComponent();
            comboBox_time.SelectedIndex = 1;
            m_painting = false;
          
             ChessImages = new Images();

            //            //  in case on debuing
            //#if DEBUG
            //            ResourceFolder = "..\\..\\Resources\\";
            //#else
            //                ResourceFolder = "Resources\\";
            //#endif

             ResourceFolder = "Resources\\";
           // ResourceFolder = "..\\..\\Resources\\";
            ChessImages.LoadImages(ResourceFolder);
            kingUnderCheck = "";
            BuildBoard();
            IsLoading = false;
            time_count = 2;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }



        //Creates a chess board by initializing an ArrayList of Rectangle objects,
        //representing each square on the 4x8 half-chess board.
        public void BuildBoard()
        {
            rectangles = new ArrayList();

            for (int row = 1; row <= 8; row++)
                for (int col = 1; col <= 4; col++)
                {
                    Rectangle ChessSquar = new Rectangle(row, col, this);
                    ChessSquar.RestoreBackground();
                    rectangles.Add(ChessSquar);
                }
        }

        private Rectangle GetBoardRectangle(string strCellName)
        {
            foreach (Rectangle ChessSquar in rectangles)
            {
                if (ChessSquar.Name == strCellName)
                    return ChessSquar;
            }
            return null;
        }

        public void RedrawBoard()
        {
            foreach (Rectangle rect in rectangles)
            {
              
                rect.RestoreBackground();

                if (rect.Name == selected_rect_name) // selected check box
                {
                    if (m_chessGame.Board[selected_rect_name].IsEmpty())
                    {
                        rect.FillBackground(System.Drawing.Color.LightGreen, 150);
                    }
                    else
                    {
                        rect.FillBackground(System.Drawing.Color.Green, 150);
                    }
                }
                if (!m_chessGame.Board[rect.Name].IsEmpty())   // Valid board squar
                    rect.DrawPiece(ChessImages.GetImageForPiece(m_chessGame.Board[rect.Name].Piece)); // draw the chess piece image
            }

            // Check if need to show the possible legal moves for the current selected piece
            if (selected_rect_name != null && selected_rect_name != ""
                && m_chessGame.Board[selected_rect_name].Piece != null
                && !m_chessGame.Board[selected_rect_name].Piece.IsEmpty()
                && m_chessGame.Board[selected_rect_name].Piece.Side == m_chessGame.GameTurn)
            {
                ArrayList moves = m_chessGame.GetLegalMoves(m_chessGame.Board[selected_rect_name]);

                // Hightlight all the possible moves for the current player
                foreach (Cell cell in moves)
                {
                    Rectangle rect = GetBoardRectangle(cell.ToString());
                    
                    rect.FillBackground(System.Drawing.Color.LightGreen, 150);
                }
            }

            // show last moves
            Move lastmove = m_chessGame.GetLastMove();  // get the last move 
            if (lastmove != null)
            {
                Rectangle rect = GetBoardRectangle(lastmove.StartCell.ToString());
                rect.DrawCircle(System.Drawing.Color.SkyBlue);
                rect = GetBoardRectangle(lastmove.EndCell.ToString());
                rect.DrawCircle(System.Drawing.Color.DeepSkyBlue);
            }

            foreach (Rectangle rect in rectangles)
            {
                if (!m_chessGame.Board[rect.Name].IsEmpty())
                    rect.DrawPiece(ChessImages.GetImageForPiece(m_chessGame.Board[rect.Name].Piece));
            }
        }

        public void UpdatePlayerTurn() // check if time is over, and end game;
        {
            if (IsWatchingMode) return;
            m_chessGame.UpdateTime();   // Update the chess thinking times

            if (m_chessGame.BlackTurn())
            {
                BlackPlayerTime.Text = m_chessGame.BlackPlayer.ThinkTime;
                BlackPlayerRemainTime.Text = "" + m_chessGame.BlackPlayer.GetRemainThinkTime();
                if (m_chessGame.BlackPlayer.GetRemainThinkTime() == 0) // if server timer is over
                {
                    IsOver = true;
                    m_chessGame.SetWinner(SideType.White, FinishReason.REASON_TIMEOVER);
                    MessageBox.Show("Server is time over.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.No;
                    m_painting = false;


                }
            }
            else
            {
                WhitePlayerTime.Text = m_chessGame.WhitePlayer.ThinkTime;
                WhitePlayerRemainTime.Text = "" + m_chessGame.WhitePlayer.GetRemainThinkTime();
                if (m_chessGame.WhitePlayer.GetRemainThinkTime() == 0) // if the timer is over.
                {
                    IsOver = true;
                    m_chessGame.SetWinner(SideType.Black, FinishReason.REASON_TIMEOVER);
                    MessageBox.Show(m_chessGame.GetGameState().player_name + " Your Time Is over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.No;
                    m_painting = false;
                }
            }
        }

        public void ShowAnimation()
        {
            if (animation_count == 0)
                return;
            if (kingUnderCheck == "")
                return;
            Rectangle rect = GetBoardRectangle(kingUnderCheck);
            if (rect == null)
                return;
            // original back color
            animation_count--;
            if (animation_count % 2 == 1)
            {
                rect.FillBackground(Color.Red, 255);

                this.label5.Text = "Chess Alert!!";
                this.label5.Visible = true;
               
            }
            else
            {
                rect.RestoreBackground();
                this.label5.Visible=false;
            }
            rect.DrawPiece(ChessImages.GetImageForPiece(m_chessGame.Board[rect.Name].Piece));
        }

        // Initialize the Chess player objects
        private void ShowPlayerInfo()
        {
        //    WhitePlayerName.Text = playerInfo.Name;
            BlackPlayerName.Text = "Server";

            // Set the time 
            BlackPlayerTime.Text = "00:00:00";
            WhitePlayerTime.Text = "00:00:00";

            BlackPlayerRemainTime.Text = comboBox_time.Text;
            WhitePlayerRemainTime.Text = comboBox_time.Text;

            label_player_name.Text = playerInfo.Name;
            label_player_id.Text = "" + playerInfo.ID;
        }

        // A move is made by the player

        /*
        Here is the connection between the Rectangle graphic class and the game board.
        First we do a calculation to find the position of the square, 
        and then we make a link between the name and the Board
        */
        public bool UserMove(string source, string dest)
        {
            int MoveResult = m_chessGame.DoMove(source, dest);
            
            PieceType promoPieceType = PieceType.Empty;
            if (MoveResult == 0) // means we can do the move.
            {
                if (m_chessGame.GetLastMove().IsPromoMove()) // in case of promotion
                {
                    if (IsLoading)
                    {
                        Move lastMove = m_chessGame.GetLastMove();
                        int index = m_chessGame.GetMoveHistoryCount();
                        if (m_chessGame.BlackTurn())
                            m_chessGame.SetPromo(m_chessGame.GetLastMove().EndCell.ToString(), m_LoadedMoves[index - 1].EndCell.Piece.Type, SideType.Black);
                        else
                            m_chessGame.SetPromo(m_chessGame.GetLastMove().EndCell.ToString(), m_LoadedMoves[index - 1].EndCell.Piece.Type, SideType.White);
                    }
                    else
                    {
                        IsRunning = false;
                        if (m_chessGame.BlackTurn())
                        {

                            int ServerRandom=HttpClientHelper.Instance.PromotePawnAsync().GetAwaiter().GetResult();
                          
                            promoPieceType = (PieceType)(ServerRandom);

                            string pieceName = "";
                            if (promoPieceType == PieceType.Rook) pieceName = "Rook";
                            if (promoPieceType == PieceType.Knight) pieceName = "Knight";
                            if (promoPieceType == PieceType.Bishop) pieceName = "Bishop";
                            MessageBox.Show("Server's pawn is promoted into " + pieceName, "Prmotion");
                            m_chessGame.SetPromo(m_chessGame.GetLastMove().EndCell.ToString(), promoPieceType, SideType.Black);
                        }
                        else
                        {
                            PromoWindow wnd = new PromoWindow(this, SideType.White);
                            wnd.ShowDialog();
                            m_chessGame.SetPromo(m_chessGame.GetLastMove().EndCell.ToString(), wnd.PromoPieceType, SideType.White);
                        }
                        IsRunning = true;
                    }
                }
                m_chessGame.NextPlayerTurn();
                if (promoPieceType != PieceType.Empty) // update promo piece type for re-playing
                {
                    Move lastMove = m_chessGame.GetLastMove();
                   
                    Piece promoPiece = new Piece(promoPieceType, m_chessGame.GetLastMove().Piece.Side);
                    lastMove.EndCell.Piece = promoPiece;
                    DbHelper.Instance.UpdateHistory((int)m_chessGame.GetGameState().game_id, lastMove, m_chessGame.GetMoveHistoryCount());
                }

                if (m_chessGame.IsUnderCheck())
                {
                    kingUnderCheck = m_chessGame.Board.GetKingPosName(m_chessGame.GameTurn);
                    // this.ChessAlert.Visible = true;
                  
                  
                    animation_count = 2; // show the Red Rectangle 
                }
               

                RedrawBoard();  // Refresh the board, redraw the board and now will show the changes.

                // check for the check mate situation
                if (m_chessGame.IsCheckMate(m_chessGame.GameTurn))
                {
                    IsOver = true;
                    if (m_chessGame.GameTurn == SideType.White)
                        m_chessGame.SetWinner(SideType.Black, FinishReason.REASON_CHECK);
                    else
                        m_chessGame.SetWinner(SideType.White, FinishReason.REASON_CHECK);
                    string name = (m_chessGame.GameTurn == SideType.Black) ? "Server" : m_chessGame.GetGameState().player_name;
                    MessageBox.Show(name + " is checkmate.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // check for the statemate situation
                if (m_chessGame.IsStaleMate(m_chessGame.GameTurn))
                {
                    IsOver = true;
                    if (m_chessGame.GameTurn == SideType.White)
                        m_chessGame.SetWinner(SideType.Black, FinishReason.REASON_CHECK);
                    else
                        m_chessGame.SetWinner(SideType.White, FinishReason.REASON_CHECK);
                    string name = (m_chessGame.GameTurn == SideType.Black) ? "Server" : m_chessGame.GetGameState().player_name;
                    MessageBox.Show(name + " is stalmate.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // check if there are only kings
                if (m_chessGame.IsOnlyKings())
                {
                    IsOver = true;
                    m_chessGame.SetWinner(SideType.Draw, FinishReason.REASON_ONLYKINGS);
                    string name = m_chessGame.GetGameState().player_name;
                    MessageBox.Show("There are only kings in the game.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        //After saving all the moves in the "m_LoadedMoves" execute.
        private void AutoMove()
        {
            if (m_LoadedMoveIndex >= m_LoadedMoves.Count)
            {
                IsLoading = false;
                m_chessGame.SetLoadingFlag(false);
                Game gameState = m_chessGame.GetGameState();
                if (gameState.finshed == true)
                {
                    IsOver = true;
                    IsRunning = false;
                    if (gameState.finish_reason == (int)FinishReason.REASON_TIMEOVER)
                    {
                        string name = (gameState.win == true) ? "Server" : gameState.player_name;
                        MessageBox.Show(name + " is TimeOver.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                return;
            }
            string srcName = m_LoadedMoves[m_LoadedMoveIndex].StartCell.ToString();
            string destName = m_LoadedMoves[m_LoadedMoveIndex].EndCell.ToString();
            UserMove(srcName, destName);
            m_LoadedMoveIndex++;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            IsLoading = false;
            IsOver = true;

            // request new game ID
            int newGameID = HttpClientHelper.Instance.StartAsync(playerInfo.ID).GetAwaiter().GetResult();
            if (newGameID <= 0)
            {
                MessageBox.Show("Cannot create new game.", "New Game");
                Application.Exit();
            }

            // update game title
            this.Text = "Welcome " + playerInfo.Name + " To HalfChess ";
            this.WhitePlayerName.Text=playerInfo.Name;

            Game gameState = new Game();
            gameState.game_id = newGameID;
            gameState.think_time = Int32.Parse(comboBox_time.Text);
            gameState.win = false;
            gameState.finshed = false;
            gameState.player_id = playerInfo.ID;
            gameState.player_name = playerInfo.Name;
            gameState.start_time = DateTime.Now;

        

            m_chessGame = new GameEngine((int)gameState.game_id, SideType.White, (int)gameState.think_time, gameState, false);
            IsWatchingMode = false;
            CantPlay = false;
            IsRunning = true;
            IsOver = false;

            m_chessGame.WhitePlayer.Name = playerInfo.Name;
            m_chessGame.BlackPlayer.Name = "Server";

            m_chessGame.BlackPlayer.PlayerType = Player.Type.Server;
            m_chessGame.WhitePlayer.PlayerType = Player.Type.Player;


            ShowPlayerInfo();
            RedrawBoard();      // Make the chess board visible on screen
            this.Cursor = Cursors.Default;
            m_chessGame.SaveGame();
        }
        private bool CantPlay=false;
        private string PlayerName { get; set; }
        private void LoadGame_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            IsLoading = false;
            IsOver = true;

            LoadGameWindow wnd = new LoadGameWindow();
            wnd.ShowDialog();
            if (wnd.Success != true)
                return;
            if (wnd.PlayerID != playerInfo.ID)
            {
                MessageBox.Show("You can Only watch the game, Not play", "Load Game");
                WhitePlayerName.Text = wnd.PlayerPlayed;
                CantPlay = true;
                IsWatchingMode = true;
                

            }
            else
            {
                IsWatchingMode = false;
                CantPlay = false;
            }
            // update game title
            this.Text = "Game Played By:" + wnd.PlayerPlayed + "|Result: " + wnd.Result;


            Game gameState = DbHelper.Instance.GetGame(wnd.GameID);
            comboBox_time.SelectedIndex = comboBox_time.Items.IndexOf("" + gameState.think_time);
            m_chessGame = new GameEngine((int)gameState.game_id, SideType.White, (int)gameState.think_time, gameState, true);
            IsRunning = true;
          
            ShowPlayerInfo();
            RedrawBoard();

            // Load History
            // Every Move history is saving in a Json format of "Move" Class, so we retrive it
            m_LoadedMoves = DbHelper.Instance.GetMoveHistory(wnd.GameID);
         
             
            IsLoading = true;
            IsOver = false;
            m_LoadedMoveIndex = 0;
            if (IsWatchingMode)
            {
                // Set initial times without starting the countdown
                WhitePlayerTime.Visible = false;
                BlackPlayerTime.Visible = false;
                WhitePlayerRemainTime.Visible = false;
                BlackPlayerRemainTime.Visible = false ;
            }
            else
            {
                WhitePlayerTime.Visible = true;
                BlackPlayerTime.Visible = true;
                WhitePlayerRemainTime.Visible = true;
                BlackPlayerRemainTime.Visible = true;
            }

        }

     
      
        private void ClearDrawing_Click(object sender, EventArgs e)
        {
            this.button_clear_drawing.Enabled = false;
            RedrawBoard();
        }

        private void TurnTicker_Tick(object sender, EventArgs e)
        {
            if (IsRunning && !IsOver && !IsWatchingMode)  // Only update timer if not in watching mode
            {
                UpdatePlayerTurn();
                ShowAnimation();
            }
            if (time_count > 0)
                time_count--;
            if (IsLoading && time_count == 0)
            {
                AutoMove();
                time_count = 2; // the delay between turns in load games;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bool loginSuccessful = false;
            LoginWindow loginWnd = new LoginWindow();

            while (!loginSuccessful)
            {
                loginWnd.ShowDialog();

                // Check if user clicked Cancel or closed the window
                if (!loginWnd.Success)
                {
                    Application.Exit();
                    return;
                }

                // Try to login to server
                string result = HttpClientHelper.Instance.LoginAsync(loginWnd.PlayerName, loginWnd.PlayerId).GetAwaiter().GetResult();

                if (result == "Login successful")
                {
                    loginSuccessful = true;
                }
                else
                {
                    System.Diagnostics.Process.Start("http://localhost:5284/Players/Create");
                    MessageBox.Show("Login Failed. Please Create a User or Check your details", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // The loop will continue and show the login window again
                }
            }

            // After successful login, proceed with initialization
            playerInfo = new PlayerInfo
            {
                Name = loginWnd.PlayerName,
                ID = loginWnd.PlayerId,
            };

            ShowPlayerInfo();
            DbHelper.Instance.UpdateNames(playerInfo.ID,playerInfo.Name);
            DbHelper.Instance.GetSavedGames();
            TurnTicker.Start();
        }

        // get player location to move.
        private async void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (CantPlay) return;
            if (IsLoading) return;

            if (!InBoardRect(e.Location))
                return;

            if (e.Button == MouseButtons.Right)
            {
                if ((!IsOver)&&(IsRunning))
                {
                    m_painting = true;
                    this.button_clear_drawing.Enabled = true;
                    m_MousePos = e.Location;
                }
                else if(!IsRunning)
                {
                    MessageBox.Show("You cannot draw until you create a game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You Cannot Paint while the game is Over.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                m_painting = false;
            if (e.Button == MouseButtons.Left)
            {
                // get the rectnagle from user with a calculation

                int rectIndex = (e.Location.Y - BOARD_MIN_Y) / LENGTH * 4 + (e.Location.X - BOARD_MIN_X) / LENGTH;
                if (rectIndex < 0 || rectIndex > 31)
                    return;
                Rectangle rect = (Rectangle)rectangles[rectIndex];
                //bool moved = false;
                if (IsRunning && m_chessGame.GameTurn != SideType.Black)
                {
                    if (string.IsNullOrEmpty(selected_rect_name))
                    {
                        // select rect
                        selected_rect_name = rect.Name;
                    }
                    else // already selected
                    {
                        if (rect.Name != selected_rect_name)
                        {
                            if (UserMove(selected_rect_name, rect.Name))
                            {
                                //moved = true;
                                selected_rect_name = "";
                            }
                            else
                            {

                                selected_rect_name = rect.Name;
                            }
                        }
                        else
                        {
                            selected_rect_name = rect.Name;
                        }
                    }
                    RedrawBoard();
                    // Here we get Servers' moves, and also the server may be delay 
                    if (IsOver != true && m_chessGame.GameTurn == SideType.Black)
                    {
                        selected_rect_name = "";
                        Move randomMove = await HttpClientHelper.Instance.MoveAsync(m_chessGame.Board.JsonSerialize());
                        if (randomMove != null)
                        {
                            UserMove(randomMove.StartCell.ToString(), randomMove.EndCell.ToString());
                          
                        }
                    }

                }
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_painting) return;
            if (!InBoardRect(e.Location))
                return;
            Graphics graphics = CreateGraphics();
            graphics.DrawLine(new Pen(Color.Red, 3), m_MousePos, e.Location);
            m_MousePos = e.Location;
           graphics.Dispose();
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            m_painting = false;
        }

        private bool InBoardRect(Point point)
        {
            if (point.X < BOARD_MIN_X || point.X > BOARD_MAX_X)
                return false;
            if (point.Y < BOARD_MIN_Y || point.Y > BOARD_MAX_Y)
                return false;
            return true;
        }

        private void button_new_game_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button_new_game_MouseLeave(object sender, EventArgs e)
        {
            if (IsOver) // If the game is over, set it back to No
            {
                this.Cursor = Cursors.No; // Set cursor to No when mouse leaves
            }
        }

     

        private void BlackPlayerName_Click(object sender, EventArgs e)
        {

        }

        private void webSiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:5284/Players/Create");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BlackPlayerRemainTime_Click(object sender, EventArgs e)
        {

        }

        private void WhitePlayerName_Click(object sender, EventArgs e)
        {

        }
    }
}
