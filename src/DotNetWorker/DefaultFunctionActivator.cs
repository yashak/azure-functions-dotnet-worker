﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Azure.Functions.Worker
{
    public class DefaultFunctionActivator : IFunctionActivator
    {
        public T CreateInstance<T>(IServiceProvider services)
        {
            return ActivatorUtilities.CreateInstance<T>(services, Array.Empty<object>());
        }
    }


}