using System;

namespace Custom
{
    [Data.Metadata.Enum("1a33840d-1727-4bc9-9024-eebac3a5692b")]
    public sealed class Time : Measurement<Time>
    {
        static Time _default = Second;
        static readonly Time[] _members = GetMembers();

        public static Time Default
        {
            get { return _default ?? (_default = Second); }
            set { _default = value ?? Second; }
        }

        public static implicit operator decimal(Time time)
        {
            return time._seconds;
        }

        public static implicit operator TimeSpan(Time time)
        {
            return TimeSpan.FromSeconds((double)time._seconds);
        }

        public static implicit operator Time(TimeSpan span)
        {
            return new Time { _seconds = (decimal)span.TotalSeconds };
        }

        public static implicit operator Time(DateTime date)
        {
            return new Time { _seconds = (decimal)date.TimeOfDay.TotalSeconds };
        }

        [Data.Metadata.Unit]
        public static readonly Time Millisecond = new Time("Millisecond", 0.001M);

        [Data.Metadata.Unit]
        public static readonly Time Second = new Time("Second", 1M);

        [Data.Metadata.Unit]
        public static readonly Time Minute = new Time("Minute", 60 * Second);

        [Data.Metadata.Unit]
        public static readonly Time Hour = new Time("Hour", 60 * Minute);

        [Data.Metadata.Unit]
        public static readonly Time Day = new Time("Day", 24 * Hour);

        [Data.Metadata.Unit]
        public static readonly Time Week = new Time("Week", 7 * Day);

        private decimal _seconds;

        private Time()
            : base(null)
        {
            _seconds = 0;
        }

        private Time(string name, decimal seconds)
            : base(name)
        {
            _seconds = seconds;
        }

        protected override Time[] Members
        {
            get { return _members; }
        }

        public decimal TotalDays
        {
            get { return _seconds / Day; }
            set { _seconds = value * Day; }
        }

        public decimal TotalHours
        {
            get { return _seconds / Hour; }
            set { _seconds = value * Hour; }
        }

        public decimal TotalMilliseconds
        {
            get { return _seconds / Millisecond; }
            set { _seconds = value * Millisecond; }
        }

        public decimal TotalMinutes
        {
            get { return _seconds / Minute; }
            set { _seconds = value * Minute; }
        }

        public decimal TotalSeconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }

        public decimal TotalWeeks
        {
            get { return _seconds / Week; }
            set { _seconds = value * Week; }
        }
    }
}
