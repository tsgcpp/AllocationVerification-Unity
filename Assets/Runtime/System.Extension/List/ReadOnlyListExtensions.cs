using System;
using System.Collections.Generic;

namespace System.Extension
{
    public static partial class ReadOnlyListExtensions
    {
        public static bool Contains<T>(this IReadOnlyList<T> items, T item) where T : IEquatable<T>
        {
            if (typeof(T).IsValueType)
            {
                return items.ContainsAsVal(item);
            }
            else
            {
                return items.ContainsAsRef(item);
            }
        }

        private static bool ContainsAsVal<T>(this IReadOnlyList<T> items, T item) where T : IEquatable<T>
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsAsRef<T>(this IReadOnlyList<T> items, T item) where T : IEquatable<T>
        {
            if (item == null)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (items[i] == null)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (item.Equals(items[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool Contains<T>(this IReadOnlyList<T> items, T item, IEqualityComparer<T> comparer)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (comparer.Equals(item, items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsGeneric<T>(this IReadOnlyList<T> items, T item)
        {
            // Reference: https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,316

            if (!typeof(T).IsValueType && item == null)
            {
                for (int i = 0; i < items.Count; i++)
                    if (items[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = 0; i < items.Count; i++)
                {
                    if (c.Equals(items[i], item)) return true;
                }
                return false;
            }
        }
    }
}
