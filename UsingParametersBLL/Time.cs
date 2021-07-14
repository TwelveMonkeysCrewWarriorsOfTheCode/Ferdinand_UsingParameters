
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
        private Time(Time pTime)
        {
            if (pTime != null)
            {
                m_Hour = pTime.Hour;
                m_Minute = pTime.Minute;
            }
        }
        public Time(int pIntTime) : this(GenerateTimeInHourMinute(pIntTime))
        {
        }
        public Time(float pFloatTime) : this((int)(pFloatTime * m_COEFFMINUTES) / m_COEFFMINUTES, (int)(pFloatTime * m_COEFFMINUTES) % m_COEFFMINUTES)
        {
        }
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

        public static explicit operator Time(int PIntToTime) => GenerateTimeInHourMinute(PIntToTime);

        public static explicit operator int(Time pTimeToInt)
        {
            Time myTimeToInt = new(pTimeToInt);
            return TimeToMinute(myTimeToInt);
        }
        public static explicit operator float(Time pTimeToFloat)
        {
            Time myTimeToFloat = new(pTimeToFloat);
            return (float)TimeToMinute(myTimeToFloat) / m_COEFFMINUTES;
        }
        public static explicit operator Time(float pTimeFloat)
        {
            Time myFloatTime = new(pTimeFloat);
            return new Time(myFloatTime.m_Hour, myFloatTime.m_Minute);
        }
        #endregion

        #region Overloading relational operators
        public static bool operator <(Time pTime1, Time pTime2) => (int)pTime1 < (int)pTime2;
        public static bool operator >(Time pTime1, Time pTime2) => (int)pTime1 > (int)pTime2;
        public static bool operator <=(Time pTime1, Time pTime2) => (int)pTime1 <= (int)pTime2;
        public static bool operator >=(Time pTime1, Time pTime2) => (int)pTime1 >= (int)pTime2;
        #endregion

        #region Methods
        private static int TimeToMinute(Time pTime) => pTime.m_Hour * m_COEFFMINUTES + pTime.m_Minute;
        private static Time GenerateTimeInHourMinute(int pTotalMinutes) => new Time(pTotalMinutes / m_COEFFMINUTES, pTotalMinutes % m_COEFFMINUTES);

        public override string ToString() => $"{Hour:##00}:{Minute:00} min";

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object PTime)
        {
            if (PTime == null) return false;
            Time myTime = (Time)PTime;
            if (myTime == null) return false;
            return myTime.Hour == this.Hour && myTime.Minute == this.Minute;
        }
        #endregion
    }
}
