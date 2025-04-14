using Chess;
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
    public partial class LoadGameWindow : Form
    {
        private List<Game> allGames;
        public bool Success { get; set; }
        public int GameID { get; set; }
        public string PlayerPlayed { get; set; }
        public string Result { get; set; }
        public int PlayerID { get; set; }
        private ToolTip toolTip = new ToolTip();
        public LoadGameWindow()
        {
           
            InitializeComponent();
            comboBoxWinnerFilter.Visible= false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
           
            List<int> gameIDs = HttpClientHelper.Instance.GetGameIdsAsync().GetAwaiter().GetResult();
            bool success = DbHelper.Instance.DeleteGamesNotInList(gameIDs);
            allGames = DbHelper.Instance.GetAllGames();
            comboBoxSortCriteria.DropDownStyle = ComboBoxStyle.DropDownList;
            toolTip.SetToolTip(button_load, "Please note, you will not be able to play other players' games, only watch them.");
        
        comboBoxSortCriteria.Items.AddRange(new string[]
  {
        "Winner",
        "Finished",
        "StartTime",
        "ThinkTime",
        "GameID",
        "PlayerName",
        "Reason"
  });
            //foreach (Game game in allGames)
            //{
            //    string playerId = "" + game.player_id;
            //    string gameID = "" + game.game_id;
            //    string playerName = game.player_name;
            //    string startTime = game.start_time.ToString();
            //    string thinkTime = "" + game.think_time;
            //    string finished = "";
            //    string winner = "";
            //    string reason = "";
            //    if (game.finshed == true)
            //    {
            //        finished = "Yes";
            //        if (game.win == true)
            //        {
            //            winner = "Player";
            //        }
            //        else
            //        {
            //            winner = "Server";
            //        }
            //        if (game.finish_reason == (int)FinishReason.REASON_CHECK)
            //            reason = "Checkmate";
            //        else if (game.finish_reason == (int)FinishReason.REASON_STALEMATE)
            //            reason = "Stalemate";
            //        else if (game.finish_reason == (int)FinishReason.REASON_ONLYKINGS)
            //            reason = "OnlyKings";
            //        else
            //            reason = "Timeover";

            //    }
            //    else
            //    {
            //        finished = "No";
            //    }


            //    comboBoxSortCriteria.SelectedIndex = 0;
            //    ListViewItem item = new ListViewItem(new string[] { gameID, playerName, startTime, thinkTime, finished, winner, reason, playerId });
            //    listView_games.Items.Add(item);
            //}
            PopulateListView(allGames);
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if (listView_games.SelectedItems.Count != 0)
            {
                string gameID = listView_games.SelectedItems[0].SubItems[0].Text;
                string playerName = listView_games.SelectedItems[0].SubItems[1].Text;
                string result = listView_games.SelectedItems[0].SubItems[6].Text;
                int id = Int32.Parse(listView_games.SelectedItems[0].SubItems[7].Text);

                PlayerID = id;
                GameID = Int32.Parse(gameID);
                PlayerPlayed = playerName;
                Result = result;
                Success = true;
            }
            else
            {
                Success = false;
            }
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Success = false;
            this.Close();
        }

        private void LoadGameWindow_Load(object sender, EventArgs e)
        {

        }

        private void listView_games_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int lastSortedColumn = -1;
        private bool sortAscending = true;


        private void PopulateListView(List<Game> games)
        {
            // Clear the ListView before adding new items
            listView_games.Items.Clear();

            foreach (Game game in games) // Use the sorted games, not allGames
            {
                string playerId = "" + game.player_id;
                string gameID = "" + game.game_id;
                string playerName = game.player_name;
                string startTime = game.start_time.ToString();
                string thinkTime = "" + game.think_time;
                string finished = "";
                
                string winner = "";
                string reason = "";
                if (game.finshed == true)
                {
                    finished = "Yes";
                    if (game.win == true)
                    {
                        winner = "Player";
                    }
                    else
                    {
                        winner = "Server";
                    }
                    if(game.finshed==false)
                    {
                        winner = "Not Finish";
                    }
                    if (game.finish_reason == (int)FinishReason.REASON_CHECK)
                        reason = "Checkmate";
                    else if (game.finish_reason == (int)FinishReason.REASON_STALEMATE)
                        reason = "Stalemate";
                    else if (game.finish_reason == (int)FinishReason.REASON_ONLYKINGS)
                    {
                        winner = "Draw";
                        reason = "OnlyKings";
                    }
                    else
                        reason = "Timeover";
                }
                else
                {
                    finished = "No";
                    winner = "Not selected yet";
                }
              
                ListViewItem item = new ListViewItem(new string[] { gameID, playerName, startTime, thinkTime, finished, winner, reason, playerId });
                listView_games.Items.Add(item);
            }
            listView_games.Columns[6].Width = 100;
        }


        //private void comboBoxSortCriteria_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Get the selected sort criterion
        //    string selectedSort = comboBoxSortCriteria.SelectedItem.ToString();

        //    // Sort the games based on the selected criterion
        //    List<Game> sortedGames = new List<Game>();
        //    sortedGames = allGames;
        //    switch (selectedSort)
        //    {
        //        case "Winner":
        //            sortedGames = allGames.OrderBy(g => g.win).ToList();
        //            break;
        //        case "Finished":
        //            // Show only the games that are finished (finshed = true)
        //            sortedGames = allGames.Where(g => g.finshed == true).OrderBy(g => g.finshed).ToList();
        //            break;
        //        case "Start Time":
        //            sortedGames = allGames.OrderBy(g => g.start_time).ToList();
        //            break;
        //        case "ThinkTime":
        //            sortedGames = allGames.OrderBy(g => g.think_time).ToList();
        //            break;
        //        case "GameID":
        //            sortedGames = allGames.OrderBy(g => g.game_id).ToList();
        //            break;
        //        case "PlayerName":
        //            sortedGames = allGames.OrderBy(g => g.player_name).ToList();
        //            break;
        //        case "Reason":
        //            sortedGames = allGames.OrderBy(g => g.finish_reason).ToList();
        //            break;
        //        default:
        //            sortedGames = allGames;
        //            break;

        //    }

        //    // Re-populate ListView with sorted data (clearing the list first)
        //    PopulateListView(sortedGames);
        //}
        private void comboBoxSortCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected sort criterion
            string selectedSort = comboBoxSortCriteria.SelectedItem.ToString();


            // Show or hide the second ComboBox based on selection
            if (selectedSort == "Winner")
            {
                // Enable the comboBoxWinnerFilter to allow selection of "Server" or "Player"
                comboBoxWinnerFilter.Enabled = true;
                comboBoxWinnerFilter.Items.Clear();
                comboBoxWinnerFilter.Items.Add("Server");
                comboBoxWinnerFilter.Items.Add("Player");
                comboBoxWinnerFilter.Items.Add("Draw");
                comboBoxWinnerFilter.Items.Add("All");
                comboBoxWinnerFilter.Visible = true;

                // Optionally select "Server" as the default filter
                comboBoxWinnerFilter.SelectedIndex = 0;
            }
            else
            {
                // Disable the comboBoxWinnerFilter when not selecting "Winner"
                comboBoxWinnerFilter.Enabled = false;
                comboBoxWinnerFilter.Items.Clear();
                comboBoxWinnerFilter.Visible = false;
            }

            // Sort the games based on the selected criterion
            List<Game> sortedGames = new List<Game>();
            sortedGames = allGames;

            switch (selectedSort)
            {
                case "Winner":
                    // If a winner filter is selected, apply the filter based on "Server" or "Player"
                    if (comboBoxWinnerFilter.Enabled && comboBoxWinnerFilter.SelectedItem != null)
                    {
                        string winnerFilter = comboBoxWinnerFilter.SelectedItem.ToString();
                        if (winnerFilter == "Player")
                        {
                            sortedGames = allGames.Where(g => g.win == true).ToList(); // Player won
                        }
                        else if (winnerFilter == "Server")
                        {
                            sortedGames = allGames.Where(g => g.win == false).ToList(); // Server won
                        }
                    }
                    else
                    {
                        // Default sorting if no "Server" or "Player" is selected
                        sortedGames = allGames.OrderBy(g => g.win).ToList(); // Sorting by winner (true/false)
                    }
                    break;

                case "Finished":
                    sortedGames = allGames.Where(g => g.finshed == true).OrderBy(g => g.finshed).ToList();
                    break;
                case "Start Time":
                    sortedGames = allGames.OrderBy(g => g.start_time).ToList();
                    break;
                case "ThinkTime":
                    sortedGames = allGames.OrderBy(g => g.think_time).ToList();
                    break;
                case "GameID":
                    sortedGames = allGames.OrderBy(g => g.game_id).ToList();
                    break;
                case "PlayerName":
                    sortedGames = allGames.OrderBy(g => g.player_name).ToList();
                    break;
                case "Reason":
                    sortedGames = allGames.OrderBy(g => g.finish_reason).ToList();
                    break;
                default:
                    sortedGames = allGames;
                    break;
            }

            // Re-populate ListView with sorted data (clearing the list first)
            PopulateListView(sortedGames);
        }

        private void comboBoxWinnerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the comboBoxWinnerFilter is enabled and has a valid selection
            if (comboBoxWinnerFilter.Enabled && comboBoxWinnerFilter.SelectedItem != null)
            {
                // Get the selected value from comboBoxWinnerFilter (either "Server" or "Player")
                string winnerFilter = comboBoxWinnerFilter.SelectedItem.ToString();
                List<Game> filteredGames = new List<Game>();

                // Filter games based on whether the winner was a Player (win = true) or Server (win = false)
                if (winnerFilter == "Player")
                {
                    // Filter games where the player won (win = true) and the finish reason is REASON_ONLYKINGS
                    filteredGames = allGames.Where(g => g.win == true && g.finish_reason == 1).ToList();
                }
                else if (winnerFilter == "Server")
                {
                    // Filter games where the server won (win = false) and the finish reason is REASON_ONLYKINGS
                    filteredGames = allGames.Where(g => g.win == false && g.finish_reason == 1).ToList();
                }
                else if (winnerFilter == "Draw")
                {
                    // Filter games where the server won (win = false) and the finish reason is REASON_ONLYKINGS
                    filteredGames = allGames.Where(g =>  g.finish_reason == 4).ToList();
                }
                else if (winnerFilter == "All")
                {
                    // Filter games where the server won (win = false) and the finish reason is REASON_ONLYKINGS
                    filteredGames = allGames.ToList();
                }


                // Re-populate ListView with filtered data (clearing the list first)
                PopulateListView(filteredGames);
            }
        }

    }

}