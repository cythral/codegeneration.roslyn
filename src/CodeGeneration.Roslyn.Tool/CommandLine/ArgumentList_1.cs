// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Cythral.CodeGeneration.Roslyn.Tool.CommandLine
{
    public sealed class ArgumentList<T> : Argument
    {
        internal ArgumentList(ArgumentCommand command, IEnumerable<string> names, IReadOnlyList<T> defaultValue, bool isRequired)
            : base(command, names, true, isRequired)
        {
            Value = defaultValue;
            DefaultValue = defaultValue;
        }

        internal ArgumentList(ArgumentCommand command, string name, IReadOnlyList<T> defaultValue)
            : base(command, new[] { name }, false, true)
        {
            Value = defaultValue;
            DefaultValue = defaultValue;
        }

        public override bool IsList
        {
            get { return true; }
        }

        public new IReadOnlyList<T> Value { get; private set; }

        public new IReadOnlyList<T> DefaultValue { get; private set; }

        public override bool IsFlag
        {
            get { return typeof(T) == typeof(bool); }
        }

        internal override object GetValue()
        {
            return Value;
        }

        internal override object GetDefaultValue()
        {
            return DefaultValue;
        }

        internal void SetValue(IReadOnlyList<T> value)
        {
            Value = value;
            MarkSpecified();
        }

        public override string GetDisplayValue()
        {
            return string.Join(@", ", Value);
        }
    }
}