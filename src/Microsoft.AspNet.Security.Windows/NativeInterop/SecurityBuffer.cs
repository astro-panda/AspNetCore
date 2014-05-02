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
// <copyright file="SecurityBuffer.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;

namespace Microsoft.AspNet.Security.Windows
{
    internal class SecurityBuffer
    {
        public int size;
        public BufferType type;
        public byte[] token;
        public SafeHandle unmanagedToken;
        public int offset;

        public SecurityBuffer(byte[] data, int offset, int size, BufferType tokentype)
        {
            GlobalLog.Assert(offset >= 0 && offset <= (data == null ? 0 : data.Length), "SecurityBuffer::.ctor", "'offset' out of range.  [" + offset + "]");
            GlobalLog.Assert(size >= 0 && size <= (data == null ? 0 : data.Length - offset), "SecurityBuffer::.ctor", "'size' out of range.  [" + size + "]");

            this.offset = data == null || offset < 0 ? 0 : Math.Min(offset, data.Length);
            this.size = data == null || size < 0 ? 0 : Math.Min(size, data.Length - this.offset);
            this.type = tokentype;
            this.token = size == 0 ? null : data;
        }

        public SecurityBuffer(byte[] data, BufferType tokentype)
        {
            this.size = data == null ? 0 : data.Length;
            this.type = tokentype;
            this.token = size == 0 ? null : data;
        }

        public SecurityBuffer(int size, BufferType tokentype)
        {
            GlobalLog.Assert(size >= 0, "SecurityBuffer::.ctor", "'size' out of range.  [" + size.ToString(NumberFormatInfo.InvariantInfo) + "]");

            this.size = size;
            this.type = tokentype;
            this.token = size == 0 ? null : new byte[size];
        }

        public SecurityBuffer(ChannelBinding binding)
        {
            this.size = (binding == null ? 0 : binding.Size);
            this.type = BufferType.ChannelBindings;
            this.unmanagedToken = binding;
        }
    }
}
