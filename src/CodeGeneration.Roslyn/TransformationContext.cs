﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the MS-PL license. See LICENSE.txt file in the project root for full license information.

namespace Cythral.CodeGeneration.Roslyn
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Provides all the inputs and context necessary to perform the code generation.
    /// </summary>
    public class TransformationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationContext" /> class.
        /// </summary>
        /// <param name="processingNode">The syntax node the generator attribute is found on.</param>
        /// <param name="semanticModel">The semantic model.</param>
        /// <param name="compilation">The overall compilation being generated for.</param>
        /// <param name="projectDirectory">The absolute path of the directory where the project file is located.</param>
        /// <param name="compilationUnitUsings">The using directives already queued to be generated.</param>
        /// <param name="compilationUnitExterns">The extern aliases already queued to be generated.</param>
        /// <param name="buildProperties">MSBuild properties requested by plugins using PluginRequestedProperty/CodeGenerationRoslynRequestedProperty items.</param>
        public TransformationContext(
            CSharpSyntaxNode processingNode,
            SemanticModel semanticModel,
            CSharpCompilation compilation,
            string projectDirectory,
            IEnumerable<UsingDirectiveSyntax> compilationUnitUsings,
            IEnumerable<ExternAliasDirectiveSyntax> compilationUnitExterns,
            IReadOnlyDictionary<string, string> buildProperties)
        {
            ProcessingNode = processingNode;
            SemanticModel = semanticModel;
            Compilation = compilation;
            ProjectDirectory = projectDirectory;
            CompilationUnitUsings = compilationUnitUsings;
            CompilationUnitExterns = compilationUnitExterns;
            BuildProperties = buildProperties;
        }

        /// <summary>Gets the syntax node the generator attribute is found on.</summary>
        public CSharpSyntaxNode ProcessingNode { get; }

        /// <summary>Gets the semantic model for the <see cref="Compilation" />.</summary>
        public SemanticModel SemanticModel { get; }

        /// <summary>Gets the overall compilation being generated for.</summary>
        public CSharpCompilation Compilation { get; }

        /// <summary>Gets the absolute path of the directory where the project file is located.</summary>
        public string ProjectDirectory { get; }

        /// <summary>Gets a collection of using directives already queued to be generated.</summary>
        public IEnumerable<UsingDirectiveSyntax> CompilationUnitUsings { get; }

        /// <summary>Gets a collection of extern aliases already queued to be generated.</summary>
        public IEnumerable<ExternAliasDirectiveSyntax> CompilationUnitExterns { get; }

        /// <summary>Gets a dictionary of MSBuild properties requested by plugins using PluginRequestedProperty/CodeGenerationRoslynRequestedProperty items.</summary>
        public IReadOnlyDictionary<string, string> BuildProperties { get; }
    }
}
