
using System;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace HalfChessClient
{

    /*
	 The Player class manages the player's characteristics and their interaction with the game,
	including managing their side (white or black) and handling their thinking time during moves.
	 */

    public class PlayerInfo
    {
        public string Name { get; set; }
        public int ID { get; set; }
      //  public string Country { get; set; }
   
    }
    public class Player
	{
		private Type m_Type;		
		private SideType m_Side;
		private string m_Name;	
		private Rules m_Rules;	
		private int MaxThinkTime;	

		private TimeSpan m_TotalThinkTime;
		private DateTime m_StartTime;     
		private int m_RemainThinkTime; 

		public enum Type { Player, Server };

        internal Player()
        {
            m_Side = PlayerSide;
            m_Type = PlayerType;
            MaxThinkTime = 20;	
            m_TotalThinkTime = (DateTime.Now - DateTime.Now);	
            m_RemainThinkTime = MaxThinkTime;	
        }

        public Player(SideType PlayerSide, Type PlayerType, int maxThinkTime)
		{
			m_Side=PlayerSide;
			m_Type=PlayerType;
            MaxThinkTime = maxThinkTime;	
			m_TotalThinkTime = (DateTime.Now - DateTime.Now);	
            m_RemainThinkTime = MaxThinkTime;  
        }

        public Player(SideType PlayerSide, Type PlayerType, Rules rules, int maxThinkTime) : this(PlayerSide,PlayerType, maxThinkTime)
		{
			m_Rules = rules;	
		}

		public void TimeStart()
		{
			m_StartTime = DateTime.Now;
		}

		public void TimeEnd()
		{
			m_TotalThinkTime += (DateTime.Now - m_StartTime);
		}

		public void UpdateTime()
		{
			m_RemainThinkTime = MaxThinkTime - (int)(DateTime.Now - m_StartTime).TotalSeconds;
		}

		public bool IsServer()
		{
			return (m_Type == Type.Server);
		}

		public void ResetTime()
		{
			m_TotalThinkTime = (DateTime.Now - DateTime.Now);   // Reset time
			m_RemainThinkTime = MaxThinkTime;

        }

		public int GetRemainThinkTime()
		{
			return m_RemainThinkTime;
		}

        internal Rules GameRules
        {
            set { m_Rules = value; }
        }

		public Move GetRandomMove()
		{
			ArrayList TotalMoves = m_Rules.GenerateAllLegalMoves(m_Side); // Get all the legal moves for the current side
			Random random = new Random();
			int index = random.Next(TotalMoves.Count);
			return (Move)TotalMoves[index];
		}


		
		public Type PlayerType
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type=value;
			}
		}
		public SideType PlayerSide
		{
			get
			{
				return m_Side;
			}
			set
			{
				m_Side=value;
			}
		}
		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name=value;
			}
		}

		public TimeSpan ThinkSpanTime
		{
			get
			{
				return m_TotalThinkTime;	// returns back total think time of the user
			}
            set
            {
                m_TotalThinkTime = value;
            }
		}

        public long ThinkSpanTimeInSeconds
        {
            get
            {
                return (long)m_TotalThinkTime.TotalSeconds;	// returns back total think time of the user
            }
            set
            {
                m_TotalThinkTime = new TimeSpan(0,0, (int)value);
            }
        }

		public string ThinkTime
		{
			get
			{
				string strThinkTime;

                if (m_StartTime.Year == 1)
                    m_StartTime = DateTime.Now;

				TimeSpan timespan = m_TotalThinkTime+(DateTime.Now - m_StartTime);
				strThinkTime =  timespan.Hours.ToString("00")+":"+timespan.Minutes.ToString("00")+":"+timespan.Seconds.ToString("00");
				return strThinkTime;	
			}
		}
	
	}
}
