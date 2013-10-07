using System;

namespace Custom
{
    [Metadata.Value("8a8b8778-544e-4f72-b265-b4f43fb73ac1")]
    public class Date
    {
        public static implicit operator DateTime(Date date)
        {
            return new DateTime(date._year, date._month, date._day);
        }

        public static implicit operator Date(DateTime time)
        {
            return new Date { _year = time.Year, _month = time.Month, _day = time.Day };
        }

        private int _day;
        private int _month;
        private int _year;

        public Date()
        {
            var now = DateTime.Now;

            _year = now.Year;
            _month = now.Month;
            _day = now.Day;
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
    }
}
