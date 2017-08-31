﻿// 
// This file is licensed under the terms of the Simple Non Code License (SNCL) 2.1.0.
// The full license text can be found in the file named License.txt.
// Written originally by Alexandre Quoniou in 2016.
//

using System;
using System.Collections.Generic;
using Dash.Helpers;

namespace Dash.FileFormats.IdeaFactory.CL3
{
    public class Section<T> : Section where T : IEntry
    {
        private List<T> _entries;

        public List<T> Entries
        {
            get => _entries;
            set => _entries = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Section(MixedString name, List<T> entries)
        {
            Name = name;
            Entries = entries;
        }
    }
}
