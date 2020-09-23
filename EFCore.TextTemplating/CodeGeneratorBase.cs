﻿namespace EFCore.TextTemplating
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Base class for transformations. The default one generated by T4 isn't compatible with .NET Standard.
    /// </summary>
    internal abstract class CodeGeneratorBase
    {
        private StringBuilder _generationEnvironment;
        private bool _endsWithNewline;
        private readonly List<int> _indentLengths = new List<int>();

        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual IDictionary<string, object> Session { get; set; }

        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected StringBuilder GenerationEnvironment
        {
            get => _generationEnvironment ??= new StringBuilder();
            set => _generationEnvironment = value;
        }

        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        protected CompilerErrorCollection Errors { get; } = new CompilerErrorCollection();

        /// <summary>
        /// Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Create the template output
        /// </summary>
        public abstract string TransformText();

        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        protected string CurrentIndent { get; private set; } = string.Empty;

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        protected void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
                return;

            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (GenerationEnvironment.Length == 0 || _endsWithNewline)
            {
                GenerationEnvironment.Append(CurrentIndent);
                _endsWithNewline = false;
            }

            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
            {
                _endsWithNewline = true;
            }

            // This is an optimization. If the current indent is string.Empty, then we don't have to do any
            // of the more complex stuff further down.
            if (CurrentIndent.Length == 0)
            {
                GenerationEnvironment.Append(textToAppend);

                return;
            }

            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(Environment.NewLine, Environment.NewLine + CurrentIndent);

            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (_endsWithNewline)
            {
                GenerationEnvironment.Append(textToAppend, 0, textToAppend.Length - CurrentIndent.Length);
            }
            else
            {
                GenerationEnvironment.Append(textToAppend);
            }
        }

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        protected void WriteLine(string textToAppend)
        {
            Write(textToAppend);
            GenerationEnvironment.AppendLine();
            _endsWithNewline = true;
        }

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        protected void Write(string format, params object[] args)
            => Write(string.Format(CultureInfo.CurrentCulture, format, args));

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        protected void WriteLine(string format, params object[] args)
            => WriteLine(string.Format(CultureInfo.CurrentCulture, format, args));

        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
            => throw new Exception(message);

        /// <summary>
        /// Increase the indent
        /// </summary>
        protected void PushIndent(string indent)
        {
            CurrentIndent += indent ?? throw new ArgumentNullException(nameof(indent));
            _indentLengths.Add(indent.Length);
        }

        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        protected string PopIndent()
        {
            var returnValue = string.Empty;

            if (_indentLengths.Count != 0)
            {
                var indentLength = _indentLengths[_indentLengths.Count - 1];
                _indentLengths.RemoveAt(_indentLengths.Count - 1);

                if (indentLength != 0)
                {
                    returnValue = CurrentIndent.Substring(CurrentIndent.Length - indentLength);
                    CurrentIndent = CurrentIndent.Remove(CurrentIndent.Length - indentLength);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Remove any indentation
        /// </summary>
        protected void ClearIndent()
        {
            _indentLengths.Clear();
            CurrentIndent = string.Empty;
        }

        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        protected class ToStringInstanceHelper
        {
            private IFormatProvider _formatProvider = CultureInfo.InvariantCulture;

            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public IFormatProvider FormatProvider
            {
                get => _formatProvider;
                set
                {
                    if (value != null)
                    {
                        _formatProvider = value;
                    }
                }
            }

            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if (objectToConvert == null)
                    throw new ArgumentNullException(nameof(objectToConvert));

                var method = objectToConvert.GetType().GetMethod("ToString", new[] { typeof(IFormatProvider) });
                if (method == null)
                    return objectToConvert.ToString();

                return (string)method.Invoke(objectToConvert, new object[] { _formatProvider });
            }
        }

        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        protected ToStringInstanceHelper ToStringHelper { get; } = new ToStringInstanceHelper();

        protected class CompilerErrorCollection
        {
            public bool HasErrors => false;
        }
    }
}