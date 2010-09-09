using System;
namespace nVentive.Umbrella.Reflection
{
    public interface IValueMemberDescriptor : IMemberDescriptor
    {
        object GetValue(object instance);
        void SetValue(object instance, object value);

        /// <summary>
        /// Creates a compiled method that will allow a the assignation of the current member.
        /// </summary>
        /// <returns>A delegate taking an instance as the first parameter, and the value as the second parameter.</returns>
        Action<object, object> ToCompiledSetValue();

        /// <summary>
        /// Creates a compiled method that will allow a the assignation of the current member.
        /// </summary>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate taking an instance as the first parameter, and the value as the second parameter.</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. Invalid parameters could result in unexpected behavior.
        /// </remarks>
        Action<object, object> ToCompiledSetValue(bool strict);

        /// <summary>
        /// Creates a compiled method that will get the value of  of the current member. 
        /// </summary>
        /// <param name="fieldInfo">The field to get the value from.</param>
        /// <returns></returns>
        Func<object, object> ToCompiledGetValue();

        /// <summary>
        /// Creates a compiled method that will get the value of  of the current member.
        /// </summary>
        /// <param name="fieldInfo">The field to get the value from.</param>
        /// <param name="strict">Removes some type checking to enhance performance if set to false.</param>
        /// <returns>A delegate taking an instance as the first parameter, and returns the value of the field.</returns>
        /// <remarks>
        /// The use of the strict parameter is required if the caller of the generated method does not validate 
        /// parameter types before the call. An invalid parameter could result in unexpected behavior.
        /// </remarks>
        Func<object, object> ToCompiledGetValue(bool strict);
    }
}