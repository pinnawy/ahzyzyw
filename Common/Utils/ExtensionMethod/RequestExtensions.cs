using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Everest.Library.ExtensionMethod
{
    public static class RequestExtensions
    {
        /// <summary>
        /// Gets the raw host.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string GetRawHost(this HttpRequest request)
        {
            return request.Headers["Host"];
        }
        /// <summary>
        /// Gets the raw host without port.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string GetRawHostWithoutPort(this HttpRequest request)
        {
            var host = request.GetRawHost();

            var portIndex = host.IndexOf(":");
            if (portIndex > 0)
            {
                return host.Substring(0, portIndex);
            }
            return host;
        }
    }
}
