// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the MS-PL license. See LICENSE.txt file in the project root for full license information.

namespace Cythral.CodeGeneration.Roslyn.Tests.Generators
{
    using System;
    using System.Diagnostics;
    using Validation;

    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    [CodeGenerationAttribute(typeof(OnCompleteGenerator))]
    [Conditional("CodeGeneration")]
    public class OnCompleteAttribute : Attribute
    {
    }
}