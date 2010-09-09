using System;
namespace nVentive.Umbrella.Reflection
{
    public interface IMethodDescriptor : IMemberDescriptor
    {
        object Invoke(object instance, params object[] args);

#if !SILVERLIGHT
        /// <summary>
        /// Build a compiled method that will call the specified method.
        /// </summary>
        /// <param name="MethodInfo">The method to invoke</param>
        /// <returns>A delegate that will call the requested method</returns>
        Func<object, object[], object> ToCompiledMethodInvoke();

        /// <summary>
        /// Build a compiled method that will call the specified method.
        /// </summary>
        /// <param name="MethodInfo">The method to invoke</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate that will call the requested method</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        Func<object, object[], object> ToCompiledMethodInvoke(bool strict);
#endif
    }
}