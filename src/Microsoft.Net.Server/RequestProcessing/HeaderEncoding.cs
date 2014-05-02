// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING
// WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF
// TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR
// NON-INFRINGEMENT.
// See the Apache 2 License for the specific language governing
// permissions and limitations under the License.

// -----------------------------------------------------------------------
// <copyright file="HeaderEncoding.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Net.Server
{
    // we use this static class as a helper class to encode/decode HTTP headers.
    // what we need is a 1-1 correspondence between a char in the range U+0000-U+00FF
    // and a byte in the range 0x00-0xFF (which is the range that can hit the network).
    // The Latin-1 encoding (ISO-88591-1) (GetEncoding(28591)) works for byte[] to string, but is a little slow.
    // It doesn't work for string -> byte[] because of best-fit-mapping problems.
    internal static class HeaderEncoding
    {
        internal static unsafe string GetString(byte[] bytes, int byteIndex, int byteCount)
        {
            fixed (byte* pBytes = bytes)
                return GetString(pBytes + byteIndex, byteCount);
        }

        internal static unsafe string GetString(sbyte* pBytes, int byteCount)
        {
            return GetString((byte*)pBytes, byteCount);
        }

        internal static unsafe string GetString(byte* pBytes, int byteCount)
        {
            if (byteCount < 1)
                {
                    return string.Empty;
                }

            string s = new String('\0', byteCount);

            fixed (char* pStr = s)
            {
                char* pString = pStr;
                while (byteCount >= 8)
                {
                    pString[0] = (char)pBytes[0];
                    pString[1] = (char)pBytes[1];
                    pString[2] = (char)pBytes[2];
                    pString[3] = (char)pBytes[3];
                    pString[4] = (char)pBytes[4];
                    pString[5] = (char)pBytes[5];
                    pString[6] = (char)pBytes[6];
                    pString[7] = (char)pBytes[7];
                    pString += 8;
                    pBytes += 8;
                    byteCount -= 8;
                }
                for (int i = 0; i < byteCount; i++)
                {
                    pString[i] = (char)pBytes[i];
                }
            }

            return s;
        }

        internal static int GetByteCount(string myString)
        {
            return myString.Length;
        }
        internal static unsafe void GetBytes(string myString, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            if (myString.Length == 0)
            {
                return;
            }
            fixed (byte* bufferPointer = bytes)
            {
                byte* newBufferPointer = bufferPointer + byteIndex;
                int finalIndex = charIndex + charCount;
                while (charIndex < finalIndex)
                {
                    *newBufferPointer++ = (byte)myString[charIndex++];
                }
            }
        }
        internal static unsafe byte[] GetBytes(string myString)
        {
            byte[] bytes = new byte[myString.Length];
            if (myString.Length != 0)
            {
                GetBytes(myString, 0, myString.Length, bytes, 0);
            }
            return bytes;
        }
    }
}
