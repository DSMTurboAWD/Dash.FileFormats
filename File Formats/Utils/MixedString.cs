﻿// 
// This file is licensed under the terms of the Simple Non Code License (SNCL) 2.0.2.
// The full license text can be found in the file named License.txt.
// Written originally by Alexandre Quoniou in 2016.
//

using System.Linq;
using System.Text;

namespace MysteryDash.FileFormats.Utils
{
    public struct MixedString
    {
        private byte[] _dataBytes;
        private string _dataString;
        private readonly Encoding _encoding;

        public MixedString(byte[] value) : this(value, Encoding.UTF8)
        {
        }

        public MixedString(string value) : this(value, Encoding.UTF8)
        {
        }

        public MixedString(byte[] value, Encoding encoding)
        {
            _dataBytes = value;
            _dataString = null;
            _encoding = encoding;
        }

        public MixedString(string value, Encoding encoding)
        {
            _dataBytes = null;
            _dataString = value;
            _encoding = encoding;
        }

        public byte[] GetCustomLength(int length)
        {
            byte[] output = new byte[length];
            byte[] value = this;
            for (int i = 0; i < value.Length && i < length; i++)
            {
                output[i] = value[i];
            }
            return output;
        }

        public string ZeroTerminatedString => new string(((string)this).TakeWhile(c => c != '\0').ToArray());

        public static implicit operator MixedString(string value) => new MixedString(value);

        public static implicit operator MixedString(byte[] value) => new MixedString(value);

        public static implicit operator string(MixedString value) => value._dataString ?? (value._dataString = value._encoding.GetString(value._dataBytes));

        public static implicit operator byte[] (MixedString value) => value._dataBytes ?? (value._dataBytes = value._encoding.GetBytes(value._dataString));

        public int Length => ((byte[])this).Length;
    }
}
