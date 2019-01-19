// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class MySqlConditionTraitDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            return !((traitAttribute as IReflectionAttributeInfo)?.Attribute is MySqlConditionAttribute mySqlCondition)
                ? Enumerable.Empty<KeyValuePair<string, string>>()
                : Enum.GetValues(typeof(MySqlCondition)).Cast<MySqlCondition>()
                .Where(c => mySqlCondition.Conditions.HasFlag(c))
                .Select(c => new KeyValuePair<string, string>(nameof(MySqlCondition), c.ToString()));
        }
    }
}
