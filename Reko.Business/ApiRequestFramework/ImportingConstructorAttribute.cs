using System;

namespace Reko.Business.ApiRequestFramework
{
    [AttributeUsage( AttributeTargets.Constructor )]
    internal sealed class ImportingConstructorAttribute : Attribute
    { }
}
