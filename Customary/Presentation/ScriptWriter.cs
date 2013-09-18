using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public class ScriptWriter : IEnumerable<string>, IDisposable
    {
        public static implicit operator string[](ScriptWriter writer)
        {
            return writer.Lines.ToArray();
        }

        private const int BUFFER_SIZE = 256;
        private const char SPACE = ' ';
        private const int TABSIZE = 4;

        private List<string> _lines;
        private char[] _buffer;
        private int _index;
        private int _indent;

        public ScriptWriter()
        {
            _buffer = new char[BUFFER_SIZE];
            _index = 0;
            _lines = new List<string>(10);
        }

        public int? CurrentLineLenth
        {
            get
            {
                switch (_lines.Count)
                {
                    case 0:
                        return _index > 0 ? (int?)_index : null;

                    default:
                        var lastIndex = _lines.Count - 1;
                        var lastLine = _lines[lastIndex];
                        return string.IsNullOrEmpty(lastLine) ? _index : lastLine.Length + _index;
                }
            }
        }

        public int Count
        {
            get
            {
                Flush();
                return _lines.Count;
            }
        }

        public IFormatProvider FormatProvider
        {
            get;
            set;
        }

        public int Indent
        {
            get { return _indent; }
            set { _indent = value; }
        }

        public bool IsEmpty
        {
            get { return null != CurrentLineLenth; }
        }

        public int Length
        {
            get { return _lines.Where(o => !string.IsNullOrEmpty(o)).Sum(o => o.Length) + _index; }
        }

        public string[] Lines
        {
            get
            {
                Flush();

                var value = _lines.ToArray();

                return value;
            }
        }

        public void Append(char c)
        {
            if (_index == _buffer.Length)
                Flush();

            _buffer[_index] = c;
            _index++;
        }

        public ScriptWriter Append(string s)
        {
            Flush();

            switch (_lines.Count)
            {
                case 0:
                    _lines.Add(s);
                    break;

                default:
                    var lastIndex = _lines.Count - 1;
                    var lastLine = _lines[lastIndex];
                    _lines[lastIndex] = string.IsNullOrEmpty(lastLine) ? s : lastLine + s;
                    break;
            }

            return this;
        }

        public ScriptWriter Append(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                return this;

            Flush();

            switch (_lines.Count)
            {
                case 0:
                    _lines.AddRange(lines);
                    break;

                default:
                    var lastIndex = _lines.Count - 1;
                    var lastLine = _lines[lastIndex];
                    _lines[lastIndex] = string.IsNullOrEmpty(lastLine) ? lines[0] : lastLine + lines[0];
                    _lines.AddRange(lines.Skip(1));
                    break;
            }

            return this;
        }

        public void Append(char c, int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (_index == _buffer.Length)
                    Flush();

                _buffer[_index] = c;
                _index++;
            }
        }

        private void Flush()
        {
            if (_index.Equals(0))
                return;

            var buffer = new string(_buffer, 0, _index);

            _index = 0;

            Append(buffer);
        }

        public ScriptWriter Format(string format, object arg0)
        {
            Write(string.Format(FormatProvider, format, new object[] { arg0 }));
            WriteLine();

            return this;
        }

        public ScriptWriter Format(string format, params object[] arg)
        {
            Write(string.Format(FormatProvider, format, arg));
            WriteLine();

            return this;
        }

        public ScriptWriter Format(string format, object arg0, object arg1)
        {
            Write(string.Format(FormatProvider, format, new object[] { arg0, arg1 }));
            WriteLine();

            return this;
        }

        public ScriptWriter Format(string format, object arg0, object arg1, object arg2)
        {
            Write(string.Format(FormatProvider, format, new object[] { arg0, arg1, arg2 }));
            WriteLine();

            return this;
        }

        public ScriptWriter FormatLine(string format, object arg0)
        {
            Format(format, arg0);
            WriteLine();

            return this;
        }

        public ScriptWriter FormatLine(string format, params object[] arg)
        {
            Format(format, arg);
            WriteLine();

            return this;
        }

        public ScriptWriter FormatLine(string format, object arg0, object arg1)
        {
            Format(format, arg0, arg1);
            WriteLine();

            return this;
        }

        public ScriptWriter FormatLine(string format, object arg0, object arg1, object arg2)
        {
            Format(format, arg0, arg1, arg2);
            WriteLine();

            return this;
        }

        public ScriptWriter Merge(ScriptWriter other)
        {
            other.Flush();
            var e = other.Lines.AsEnumerable<string>().GetEnumerator();
            if (e.MoveNext())
            {
                Append(e.Current);
                while (e.MoveNext())
                {
                    var padding = new string(SPACE, _indent * TABSIZE);
                    _lines.Add(padding + e.Current);
                }
            }

            return this;
        }

        public ScriptWriter Merge(string[] lines)
        {
            var e = lines.AsEnumerable<string>().GetEnumerator();
            if (e.MoveNext())
            {
                Append(e.Current);
                while (e.MoveNext())
                {
                    var padding = new string(SPACE, _indent * TABSIZE);
                    _lines.Add(padding + e.Current);
                }
            }

            return this;
        }

        public ScriptWriter Reset()
        {
            _index = 0;
            _lines.Clear();

            return this;
        }

        public ScriptWriter Value(char value)
        {
            Append('"');
            Append(value); // encode?
            Append('"');

            return this;
        }

        public ScriptWriter Value(bool value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(decimal value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(double value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(int value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(long value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(DateTime value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(TimeSpan value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(float value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(string value)
        {
            Append('"');
            Append(value);// encode?
            Append('"');

            return this;
        }

        public ScriptWriter Value(uint value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Value(ulong value)
        {
            Append(value.ToString());

            return this;
        }

        public ScriptWriter Write(char value)
        {
            switch (value)
            {
                case '}':
                    _indent--;
                    break;

                case ']':
                    _indent--;
                    break;
            }

            var lineLength = CurrentLineLenth;

            if (lineLength.HasValue && lineLength.Value == 0)
                Append(SPACE, _indent * TABSIZE);

            Append(value);

            switch (value)
            {
                case '{':
                    _indent++;
                    break;

                case '[':
                    _indent++;
                    break;
            }

            return this;
        }

        public ScriptWriter Write(string value)
        {
            if (value != null)
            {
                Write(value.ToCharArray());
            }

            return this;
        }

        public ScriptWriter Write(string[] lines)
        {
            if (lines != null)
                Write(lines, 0, lines.Length);
            return this;
        }

        public ScriptWriter Write(string[] lines, int index, int count)
        {
            if (lines == null)
            {
                throw new ArgumentNullException("buffer", "ArgumentNull_Buffer");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if ((lines.Length - index) < count)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                    WriteLine();

                Write(lines[index + i]);
            }

            return this;
        }

        public ScriptWriter Write(char[] buffer)
        {
            if (buffer != null)
            {
                Write(buffer, 0, buffer.Length);
            }

            return this;
        }

        public ScriptWriter Write(char[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", "ArgumentNull_Buffer");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NeedNonNegNum");
            }
            if ((buffer.Length - index) < count)
            {
                throw new ArgumentException("Argument_InvalidOffLen");
            }
            for (int i = 0; i < count; i++)
            {
                Write(buffer[index + i]);
            }

            return this;
        }

        public ScriptWriter WriteLine()
        {
            Flush();
            _lines.Add(null);

            return this;
        }

        public ScriptWriter WriteLine(char c)
        {
            Write(c);
            WriteLine();

            return this;
        }

        public ScriptWriter WriteLine(string s)
        {
            Write(s);
            WriteLine();

            return this;
        }

        public ScriptWriter WriteTo(TextWriter writer)
        {
            Flush();

            foreach (var line in _lines)
                writer.WriteLine(line);

            return this;
        }

        void IDisposable.Dispose()
        {
            _lines = null;
            //GC.SuppressFinalize(this);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return Lines.AsEnumerable<string>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Lines.AsEnumerable<string>().GetEnumerator();
        }
    }
}