// This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to
// this project. Project-level suppressions either have no target or are given a specific target and
// scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "CodeDocumentor",
    "CD1605:The method must have a documentation header.",
    Justification = "No documentation headers needed for test classes and methods",
    Scope = "namespaceanddescendants",
    Target = "~N:TestWdbReader"
)]
[assembly: SuppressMessage(
    "CodeDocumentor",
    "CD1600:The class must have a documentation header.",
    Justification = "No documentation headers needed for test classes and methods",
    Scope = "namespaceanddescendants",
    Target = "~N:TestWdbReader"
)]
