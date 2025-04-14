
using Newtonsoft.Json;
using System;

namespace HalfChessClient
{
	public class Move
	{
		public enum MoveType {NormalMove, CaputreMove};	 // it doesnt matter, but if we want to know

		public Cell StartCell { get; set; }
        public Cell EndCell { get; set; }
        public Piece Piece {get; set;}
        public Piece CapturedPiece { get; set;}
        public MoveType Type { get; set; }

        public bool CauseCheck { get; set; }

        internal Move()
        {
        }

        public Move(Cell begin, Cell end)
        {
            StartCell = begin;
            EndCell = end;
            Piece = (begin.Piece != null) ? begin.Piece : null;
            CapturedPiece = (end.Piece != null) ? end.Piece : null;
        }


        public Move(Cell begin, Cell end, Piece piece, Piece capturedPiece, MoveType moveType)
        {
            StartCell = begin;
            EndCell = end;
            Piece = piece;
            CapturedPiece = capturedPiece;
            Type = moveType;
        }

        public bool IsCaptureMove()
		{
			return Type == MoveType.CaputreMove;
		}

        public bool IsPromoMove()
        {
            if(Piece.Type != PieceType.Pawn) return false;
            if (StartCell.Row == EndCell.Row) return false;
            if (EndCell.Row == 1 || EndCell.Row == 8)
                return true;
            return false;
        }

        public string JsonSerialize()
        {
            string output = JsonConvert.SerializeObject(this);

            return output;
        }


        public static Move JsonDeserialize(string json)
        {
            // deserialize
            Move move = JsonConvert.DeserializeObject<Move>(json);
			return move;
        }
    }

}
