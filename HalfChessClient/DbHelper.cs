using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using HalfChessClient;
using System.Data.Entity.Migrations;

namespace Chess
{
    public sealed class DbHelper
    {
        private static DbHelper _instance;
        private static readonly object _lock = new object();
        private chessEntities db;

        private DbHelper() 
        {
            string dbdir = Environment.CurrentDirectory;

            dbdir = Directory.GetParent(dbdir).Parent.FullName;

            AppDomain.CurrentDomain.SetData("DataDirectory", dbdir);

            db = new chessEntities();
        }

        public static DbHelper Instance
        {
            
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DbHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<Game> GetAllGames()
        {
            List<Game> list = db.Games.ToList();
            return list;
        }

        public List<Game> GetSavedGames()
        {
            List<Game> list = db.Games.Where(c=> c.finshed == false).ToList();
            return list;
            
        }
        public bool DeleteGamesNotInList(List<int> gameIds)
        {
            try
            {
                // Find all games that are NOT in the provided list of game IDs
                var gamesToDelete = db.Games
                    .Where(c => !gameIds.Contains(c.game_id.Value))  // Using "!" for NOT IN
                    .ToList();

                if (gamesToDelete.Count == 0)
                {
                    // No games to delete
                    return false;
                }

               
                // Get a list of game IDs to delete from the gamesToDelete collection
                var gameIdsToDelete = gamesToDelete
                    .Where(g => g.game_id.HasValue) // Ensure that game_id is not null
                    .Select(g => g.game_id.Value)  // Select only the game_id values
                    .ToList();

             foreach(var gameid in gameIdsToDelete)
                {
                    // Find and delete related move histories for this game
                    var gameHistories = db.MoveHistories
                        .Where(c => c.game_id == gameid)
                        .ToList();
                    db.MoveHistories.RemoveRange(gameHistories);
                }
               
                // Remove all games
                db.Games.RemoveRange(gamesToDelete);

                // Commit the transaction to save changes
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting games and histories: " + ex.Message);
                return false;
            }
        }





        public Game GetGame(int gameid) {
            var game = db.Games.Where(c => c.game_id == gameid).First<Game>();
            return game;
        }
        public void UpdateNames(int playerId, string newPlayerName)
        {
            // חיפוש כל הרשומות עם אותו מזהה שחקן (player_id)
            var gamesToUpdate = db.Games
                .Where(g => g.player_id == playerId)
                .ToList();

            // בדיקה אם צריך לעדכן את שם השחקן
            if (gamesToUpdate.Any(g => g.player_name != newPlayerName))
            {
                // עדכון שם השחקן החדש בכל הרשומות שנמצאו
                foreach (var game in gamesToUpdate)
                {
                    game.player_name = newPlayerName;
                }

                // שמירת השינויים במסד הנתונים
                db.SaveChanges();
            }
        }
      

        public void AddNewGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
        }

        // save the currect game After Creating. 
        public void UpdateGameState(Game game)
        {
            db.Games.AddOrUpdate(game);
            db.SaveChanges();
           
            
            

        }

        public void AddMoveHistory(int gameid, Move move, int moveIndex)
        {
            MoveHistory history = new MoveHistory();
            history.game_id = gameid;
            history.move_index = moveIndex;
            history.move = move.JsonSerialize();
            db.MoveHistories.Add(history);
            db.SaveChanges();
        }

        public List<Move> GetMoveHistory(int gameid)
        {
            var history = db.MoveHistories.Where(c=>c.game_id==gameid).OrderBy(c=>c.move_index).ToList();
            List<Move> list = new List<Move>();
            foreach (var move in history)
            {
                list.Add(Move.JsonDeserialize(move.move));
            }
            return list;
        }

        public void UpdateHistory(int gameid, Move move, int moveIndex)
        {
            var data = db.MoveHistories.Where(c=>c.game_id == gameid && c.move_index == moveIndex).FirstOrDefault();
            db.MoveHistories.Remove(data);
            MoveHistory history = new MoveHistory();
            history.game_id = gameid;
            history.move_index = moveIndex;
            history.move = move.JsonSerialize();
            db.MoveHistories.Add(history);
            db.SaveChanges();
        }
    }
}
