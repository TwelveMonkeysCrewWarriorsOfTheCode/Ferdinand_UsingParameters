
namespace UsingParametersBLL
{
    public class Time
    {
        #region Constants, fields and properties
        private const int m_COEFFMINUTES = 60;
        private int m_Hour;
        public int Hour
        {
            get { return m_Hour; }
            set { m_Hour = value; }
        }

        private int m_Minute;
        public int Minute
        {
            get { return m_Minute; }
            set { m_Minute = value; }
        } 
        #endregion

        #region Constructors       
        public Time(int pHour, int pMinute)
        {
            m_Hour = pHour;
            m_Minute = pMinute;
        }
        #endregion

        #region Arithmetic operators overloading
        public static Time operator +(Time pTime1, Time pTime2) => GenerateTimeInHourMinute((int)pTime1 + (int)pTime2);

        public static Time operator -(Time pTime1, Time pTime2) => GenerateTimeInHourMinute((int)pTime1 + (int)pTime2);

        public static Time operator *(Time pTime3, int pCoeff) => GenerateTimeInHourMinute((int)pTime3 * pCoeff);

        public static Time operator /(Time pTime3, int pCoeff) => GenerateTimeInHourMinute((int)pTime3 / pCoeff);
        #endregion

        #region Overloading conversion operators

        public static explicit operator Time(int PIntToTime) => new Time(PIntToTime / m_COEFFMINUTES, PIntToTime % m_COEFFMINUTES);

        public static explicit operator int(Time pTime1) => pTime1.Hour * m_COEFFMINUTES + pTime1.Minute;

        public static explicit operator float(Time pTime1) => (float)((int)pTime1 / m_COEFFMINUTES);

        public static explicit operator Time(float pTimeFloat) => new Time((int)(pTimeFloat * m_COEFFMINUTES) / m_COEFFMINUTES,
            (int)(pTimeFloat * m_COEFFMINUTES) % m_COEFFMINUTES);
        #endregion

        #region Overloading relational operators
        public static bool operator <(Time pTime1, Time pTime2) => (int)pTime1 < (int)pTime2;
        public static bool operator >(Time pTime1, Time pTime2) => (int)pTime1 > (int)pTime2;
        public static bool operator <=(Time pTime1, Time pTime2) => (int)pTime1 <= (int)pTime2;
        public static bool operator >=(Time pTime1, Time pTime2) => (int)pTime1 >= (int)pTime2;

        public static bool operator ==(Time pTime1, Time pTime2) => (int)pTime1 == (int)pTime2;
        public static bool operator !=(Time pTime1, Time pTime2) => (int)pTime1 != (int)pTime2;
        #endregion

        #region Methods
        private static Time GenerateTimeInHourMinute(int pTotalMinutes) => new Time(pTotalMinutes / m_COEFFMINUTES, pTotalMinutes % m_COEFFMINUTES);

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
