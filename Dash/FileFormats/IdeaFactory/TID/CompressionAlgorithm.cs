﻿// 
// This file is licensed under the terms of the Simple Non Code License (SNCL) 2.1.0.
// The full license text can be found in the file named License.txt.
// Written originally by Alexandre Quoniou in 2016.
//

using ManagedSquish;

namespace Dash.FileFormats.IdeaFactory.TID
{
    public enum CompressionAlgorithm
    {
        None = 0,
        Dxt1 = 827611204,
        Dxt5 = 894720068
    }

    public static class CompressionAlgorithmExtensions
    {
        public static SquishFlags ToSquishFlags(this CompressionAlgorithm compression)
        {
            switch (compression)
            {
                case CompressionAlgorithm.Dxt1:
                    return SquishFlags.Dxt1;
                case CompressionAlgorithm.Dxt5:
                    return SquishFlags.Dxt5;
                default:
                    return 0;
            }
        }
    }
}