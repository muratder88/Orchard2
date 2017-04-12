﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Orchard.Scripting;
using Microsoft.Extensions.Primitives;

namespace Orchard.Recipes
{
    public class ParametersMethodProvider : IGlobalMethodProvider
    {
        private readonly GlobalMethod _globalMethod;

        public ParametersMethodProvider(object environment)
        {
            var environmentObject = JObject.FromObject(environment);

            _globalMethod = new GlobalMethod
            {
                Name = "parameters",
                Method = serviceprovider => (Func<string, object>) (name =>
                {
                    return environmentObject[name].Value<StringValues>();
                })
            };
        }

        public IEnumerable<GlobalMethod> GetMethods()
        {
            yield return _globalMethod;
        }
    }
}
