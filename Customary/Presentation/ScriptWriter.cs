using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public class ScriptWriter : System.IO.TextWriter
    {
        private int? _length;
        private int _indent;
        private char? _lastChar;
        private readonly System.IO.TextWriter _textWriter;

        public ScriptWriter(System.IO.TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public override System.Text.Encoding Encoding
        {
            get { return _textWriter.Encoding; }
        }

        public int Decrease()
        {
            _indent--;
            return _indent;
        }

        public int Increase()
        {
            _indent++;
            return _indent;
        }

        public override void Write(char value)
        {
            switch (value)
            {
                case '}':
                    Decrease();
                    break;

                case ']':
                    Decrease();
                    break;
            }

            string padding = string.Empty;

            if (_length.HasValue && _length.Value == 0)
            {
                padding = new string(' ', _indent * 2);
            }
            
            _textWriter.Write(padding + value);

            switch (value)
            {
                case '{':
                    Increase();
                    break;

                case '[':
                    Increase();
                    break;
            }

            _length++;
            _lastChar = value;
        }

        public override void WriteLine()
        {
            if (_lastChar.HasValue)
            {
                switch (_lastChar.Value)
                {
                    case '{':
                        break;
                }
            }

            _length = 0;
            _textWriter.WriteLine();
        }
    }
}