using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Umbrella.Extensions
{
    /// <summary>
    /// Provide extentions for the System.Text.RegularExpressions.Match class
    /// </summary>
    public static class MatchExtensions
    {
        /// <summary>
        /// Converts a Regular Expression Match instance to an enumerable of Regular Expression Match instances
        /// </summary>
        /// <param name="match">A Regular Expression Match instance</param>
        /// <returns>An enumerable of matches</returns>
        public static IEnumerable<Match> AsEnumerable(this Match match)
        {
            while (match.Success)
            {
                yield return match;

                match = match.NextMatch();
            }
        }
    }
}
