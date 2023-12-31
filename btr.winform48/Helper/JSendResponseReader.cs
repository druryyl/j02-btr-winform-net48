﻿using System.Text.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.Helper
{
    public static class JSendResponse
    {
        public static T Read<T>(RestResponse<JSend<T>> response)
        {
            if (response.Data is null)
                ReadAndThrowError(response);
            return response.Data.Data;
        }
        private static void ReadAndThrowError(RestResponseBase response)
        {
            if (response.Content is null)
                throw new InvalidOperationException($"Error Remote: ({(int)response.StatusCode}) {response.ErrorException.Message}");

            var resultFailed = JsonSerializer.Deserialize<JSend<string>>(response.Content);
            if (resultFailed != null)
                throw new ArgumentException(resultFailed.Data);
            else
                throw new InvalidOperationException($"Error Remote: ({(int)response.StatusCode}) {response.ErrorException.Message}");
        }
    }
}
