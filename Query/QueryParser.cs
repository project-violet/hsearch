// This source code is a part of project violet-server.
// Copyright (C) 2021. violet-team. Licensed under the MIT Licence.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using hsearch.Log;
using Newtonsoft.Json;

namespace hsearch.Search
{
    public class QueryTag
    {
        [JsonProperty(PropertyName = "t")]
        public string TagName;
        [JsonProperty(PropertyName = "c")]
        public string Content;
    }

    public class Query
    {
        [JsonProperty(PropertyName = "i")]
        public List<QueryTag> Includes;
        [JsonProperty(PropertyName = "e")]
        public List<QueryTag> Excludes;
        [JsonProperty(PropertyName = "a")]
        public List<QueryTag> AnyIncludes;
    }

    public class QueryParser
    {
        public static Query Parse(String raw)
        {
            try
            {
                return JsonConvert.DeserializeObject<Query>(raw);
            }
            catch
            {
                Logs.Instance.PushError("[QueryParser] Parse Error!\n" + raw);
            }

            return null;
        }
    }
}