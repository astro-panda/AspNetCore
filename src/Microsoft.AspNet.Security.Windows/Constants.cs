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
// <copyright file="Constants.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.AspNet.Security.Windows
{
    internal static class Constants
    {
        internal const string VersionKey = "owin.Version";
        internal const string OwinVersion = "1.0";
        internal const string CallCancelledKey = "owin.CallCancelled";

        internal const string RequestBodyKey = "owin.RequestBody";
        internal const string RequestHeadersKey = "owin.RequestHeaders";
        internal const string RequestSchemeKey = "owin.RequestScheme";
        internal const string RequestMethodKey = "owin.RequestMethod";
        internal const string RequestPathBaseKey = "owin.RequestPathBase";
        internal const string RequestPathKey = "owin.RequestPath";
        internal const string RequestQueryStringKey = "owin.RequestQueryString";
        internal const string HttpRequestProtocolKey = "owin.RequestProtocol";

        internal const string HttpResponseProtocolKey = "owin.ResponseProtocol";
        internal const string ResponseStatusCodeKey = "owin.ResponseStatusCode";
        internal const string ResponseReasonPhraseKey = "owin.ResponseReasonPhrase";
        internal const string ResponseHeadersKey = "owin.ResponseHeaders";
        internal const string ResponseBodyKey = "owin.ResponseBody";

        internal const string ClientCertifiateKey = "ssl.ClientCertificate";
        internal const string SslSpnKey = "ssl.Spn";
        internal const string SslChannelBindingKey = "ssl.ChannelBinding";

        internal const string RemoteIpAddressKey = "server.RemoteIpAddress";
        internal const string RemotePortKey = "server.RemotePort";
        internal const string LocalIpAddressKey = "server.LocalIpAddress";
        internal const string LocalPortKey = "server.LocalPort";
        internal const string IsLocalKey = "server.IsLocal";
        internal const string ServerOnSendingHeadersKey = "server.OnSendingHeaders";
        internal const string ServerUserKey = "server.User";
        internal const string ServerConnectionIdKey = "server.ConnectionId";
        internal const string ServerConnectionDisconnectKey = "server.ConnectionDisconnect";
    }
}
