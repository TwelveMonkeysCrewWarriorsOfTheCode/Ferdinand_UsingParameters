
namespace UsingParametersBLL
{
    public class Time
    {
        #region Constants, fields and properties
        private const int m_COEFFMINUTES = 60;
        private static int m_TotalMinutes;
        private int m_Hour;
        private int Hour
        {
            get { return m_Hour; }
            set { m_Hour = value; }
        }

        private int m_Minute;
        private int Minute
        {
            get { return m_Minute; }
            set { m_Minute = value; }
        } 
        #endregion

        #region Constructors
        public Time(int PIntTime)
        {
            m_TotalMinutes = PIntTime;
        }
        public Time(int pHour, int pMinute)
        {
            m_Hour = pHour;
            m_Minute = pMinute;
        } 
        #endregion

        #region Operators overloading
        public static Time operator +(Time pTime1, Time pTime2)
        {
            m_TotalMinutes = (pTime1.Hour + pTime2.Hour) * m_COEFFMINUTES + pTime1.Minute + pTime2.Minute;
            return CalculateHourAndMinute();
        }

        public static Time operator -(Time pTime1, Time pTime2)
        {
            m_TotalMinutes = pTime1.Hour * m_COEFFMINUTES + pTime1.Minute - (pTime2.Hour * m_COEFFMINUTES + pTime2.Minute);
            return CalculateHourAndMinute();
        }

        public static Time operator *(Time pTime3, int pCoeff)
        {
            m_TotalMinutes = (pTime3.Hour * m_COEFFMINUTES + pTime3.Minute) * pCoeff;
            return CalculateHourAndMinute();
        }

        public static Time operator /(Time pTime3, int pCoeff)
        {
            m_TotalMinutes = (pTime3.Hour * m_COEFFMINUTES + pTime3.Minute) / pCoeff;
            return CalculateHourAndMinute();
        } 
        #endregion

        #region Overloading conversion operators

        public static explicit operator Time(int PIntToTime) => new Time(PIntToTime / m_COEFFMINUTES, PIntToTime % m_COEFFMINUTES);

        public static explicit operator int(Time pTime1) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute;

        public static explicit operator float(Time pTime1) => (float)(pTime1.Hour * m_COEFFMINUTES + pTime1.Minute) / m_COEFFMINUTES;

        public static explicit operator Time(float pTimeFloat) => new Time((int)(pTimeFloat * m_COEFFMINUTES) / m_COEFFMINUTES,
            (int)(pTimeFloat * m_COEFFMINUTES) % m_COEFFMINUTES);
        #endregion

        #region Overloading relational operators
        public static bool operator <(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute < pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;
        public static bool operator >(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute > pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;
        public static bool operator <=(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute <= pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;
        public static bool operator >=(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute >= pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;

        public static bool operator ==(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute == pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;
        public static bool operator !=(Time pTime1, Time pTime2) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute != pTime2.Hour * m_COEFFMINUTES + pTime2.Minute;
        #endregion

        #region Methods
        private static Time CalculateHourAndMinute() => new Time(m_TotalMinutes / m_COEFFMINUTES, m_TotalMinutes % m_COEFFMINUTES);

        public override string ToString() => $"{Hour:##00}:{Minute:00} min";

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object PTime)
        {
            var myTime = (Time)PTime;
            if (myTime.Hour == this.Hour && myTime.Minute == this.Minute)
                return true;
            else
                return false;
        }
        #endregion
    }
}
