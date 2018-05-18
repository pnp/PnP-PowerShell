using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    public static class LinqExtensions
    {
        public static T FirstOrDefaultFromMany<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector, Predicate<T> condition)
        {
            // return default if no items
            if (source == null || !source.Any()) return default(T);

            // return result if found and stop traversing hierarchy
            var attempt = source.FirstOrDefault(t => condition(t));
            if (!Equals(attempt, default(T))) return attempt;

            // recursively call this function on lower levels of the
            // hierarchy until a match is found or the hierarchy is exhausted
            return source.SelectMany(childrenSelector)
                .FirstOrDefaultFromMany(childrenSelector, condition);
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            if (e == null)
            {
                return new List<T>();
            }
            return e.SelectMany(c => f(c).Flatten(f)).Concat(e);
        }
    }
}
