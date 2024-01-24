using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility.Comparer;
using log4net.Util.TypeConverters;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class CollectionExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> enumerable,
            int chunkSize)
        {
            if (chunkSize < 1) throw new ArgumentException("chunkSize must be positive");

            using (var enumerator = enumerable.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return enumerator.GetChunk(chunkSize);
        }

        private static IEnumerable<T> GetChunk<T>(this IEnumerator<T> enumerator,
            int chunkSize)
        {
            do yield return enumerator.Current; while (--chunkSize > 0 && enumerator.MoveNext());
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<T> ItemsNotIn<T>(this IEnumerable<T> items, IEnumerable<T> otherItems) where T : class
        {
            var hashSet = new HashSet<T>(items);
            hashSet.ExceptWith(otherItems);
            return new List<T>(hashSet);
        }

        public static List<TBaseType> ConvertListToBaseType<TBaseType, TSubType>(this List<TSubType> items)
            where TSubType : TBaseType
        {
            return items.ConvertAll(i => (TBaseType) i);
        }

        public static List<TSubType> ConvertListToKnownSubType<TSubType, TBaseType>(this List<TBaseType> items)
            where TSubType : TBaseType
        {
            var allItemsConvertable = items.TrueForAll(item => item is TSubType);
            if (!allItemsConvertable)
            {
                throw new ConversionNotSupportedException(
                    string.Format("Item of type {0} is not convertable to type {1}", typeof (TBaseType).Name,
                        typeof (TSubType).Name));
            }
            return items.ConvertAll(i => (TSubType) i);
        }

        public static bool IsEmpty(this ICollection test)
        {
            if (test != null)
            {
                return test.Count == 0;
            }
            return true;
        }

        public static bool Exists<T>(this IEnumerable<T> aList, Predicate<T> predicate)
        {
            foreach (var item in aList)
            {
                if (predicate.Invoke(item))
                    return true;
            }
            return false;
        }

        public static bool DoesNotHave<T>(this IEnumerable<T> aList, Predicate<T> predicate)
        {
            return !aList.Exists(predicate);
        }

        public static bool IsOneOf<T>(this T item, params T[] list)
        {
            return list.Exists(listItem => Equals(listItem, item));
        }

        public static bool IsOneOf<T>(this T item, ICollection<T> items)
        {
            return items.Contains(item);
        }

        public static bool DoesNotContain<T>(this ICollection<T> aList, T item)
        {
            return !aList.Contains(item);
        }

        public static List<TNew> ConvertAll<TNew, TOld>(this ICollection aList, Converter<TOld, TNew> converter)
        {
            var result = new List<TNew>(aList.Count);

            foreach (TOld item in aList)
            {
                result.Add(converter.Invoke(item));
            }

            return result;
        }

        public static List<TNew> ConvertAll<TNew, TOld>(this ICollection<TOld> aList, Converter<TOld, TNew> converter)
        {
            var result = new List<TNew>(aList.Count);

            foreach (var item in aList)
            {
                result.Add(converter.Invoke(item));
            }

            return result;
        }

        public static bool EqualsById<T>(this IList<T> leftHandSide, IList<T> rightHandSide) where T : DomainObject
        {
            if (ReferenceEquals(leftHandSide, rightHandSide))
                return true;

            if (leftHandSide == null || rightHandSide == null)
                return false;

            if (leftHandSide.Count != rightHandSide.Count)
                return false;

            for (var i = 0; i < leftHandSide.Count; i++)
            {
                if (leftHandSide[i].Id != rightHandSide[i].Id)
                    return false;
            }
            return true;
        }

        /// <summary>
        ///     Checks if the lists have the same items by only comparing ids.  Doesn't care about the order of items in the lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static bool AreSameById<T>(this List<T> leftSide, List<T> rightSide) where T : DomainObject
        {
            if (ReferenceEquals(leftSide, rightSide))
                return true;

            if (leftSide == null || rightSide == null)
                return false;

            if (leftSide.Count != rightSide.Count)
                return false;

            leftSide.Sort();
            rightSide.Sort();

            for (var i = 0; i < leftSide.Count; i++)
            {
                if (leftSide[i].Id != rightSide[i].Id)
                    return false;
            }
            return true;
        }

        public static void Classify<T>(this List<T> list, List<T> trueList, List<T> falseList,
            Predicate<T> match)
        {
            list.ForEach(item => (match(item) ? trueList : falseList).Add(item));
        }

        public static T LastElement<T>(this IList<T> elements)
        {
            return elements[elements.Count - 1];
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                list.Add(item);
            }
        }

        public static void AddIfNotExist<T>(this ICollection<T> collection, T itemToAdd)
        {
            if (!collection.Contains(itemToAdd))
            {
                collection.Add(itemToAdd);
            }
        }

        public static void AddIfNotNull<T>(this IList<T> list, T itemToAdd) where T : class
        {
            if (itemToAdd != null)
            {
                list.Add(itemToAdd);
            }
        }

        public static void AddNonDuplicatesById<T>(this IList<T> list, IEnumerable<T> itemsToAdd) where T : DomainObject
        {
            var hashSetOfItemsToAdd = new HashSet<T>(itemsToAdd, new DomainObjectIdEqualityComparer<T>());
            hashSetOfItemsToAdd.ExceptWith(list);
            list.AddRange(hashSetOfItemsToAdd);
        }

        public static void RemoveRange<T>(this List<T> list, List<T> itemsToRemove) where T : DomainObject
        {
            itemsToRemove.ForEach(list.RemoveById);
        }

        public static List<T> SubListFromIndexToEnd<T>(this List<T> list, int index)
        {
            return list.GetRange(index, list.Count - index);
        }

        public static T Find<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if (predicate.Invoke(item))
                    return item;
            }
            return default(T);
        }

        public static T Find<T>(this ICollection items, Predicate<T> predicate)
        {
            foreach (T item in items)
            {
                if (predicate.Invoke(item))
                    return item;
            }
            return default(T);
        }

        public static T FindById<T>(this IEnumerable<T> items, T itemToFind) where T : DomainObject
        {
            return items.FindById(itemToFind.Id);
        }

        public static T FindById<T>(this List<T> items, long? id) where T : DomainObject
        {
            return items.Find(item => item.IdValue == id);
        }

        public static T FindById<T>(this IEnumerable<T> items, long? id) where T : DomainObject
        {
            return items.Find(item => item.Id == id);
        }

        public static IThreadableDTO FindById(this List<IThreadableDTO> items, long? id)
        {
            return items.Find(item => item.Id == id);
        }

        public static List<T> FindAll<T>(this ICollection collection, Predicate<T> predicate)
        {
            var list = new List<T>();

            foreach (T item in collection)
            {
                var matches = predicate.Invoke(item);
                if (matches)
                    list.Add(item);
            }

            return list;
        }

        public static List<T> FindAll<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            var list = new List<T>();

            foreach (var item in collection)
            {
                var matches = predicate.Invoke(item);
                if (matches)
                    list.Add(item);
            }

            return list;
        }

        public static bool DoesNotContainById<T>(this IList<T> items, T itemToFind) where T : DomainObject
        {
            return !items.ExistsById(itemToFind);
        }

        public static bool ExistsById<T>(this IEnumerable<T> aList, T itemToFind) where T : DomainObject
        {
            return
                aList.Exists(
                    listItem => listItem.Id.HasValue && itemToFind.Id.HasValue && listItem.IdValue == itemToFind.IdValue);
        }

        public static bool IdIsInList<T>(this List<long> idList, T itemToFind) where T : DomainObject
        {
            return idList.Exists(id => id == itemToFind.Id);
        }

        public static void RemoveById<T>(this List<T> list, T item) where T : DomainObject
        {
            var index = list.FindIndex(i => i.IdValue == item.IdValue);
            if (index != -1)
            {
                list.RemoveAt(index);
            }
        }

        public static void ForEach<T>(this ICollection items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static void ForEachSlice<T>(this IList<T> items, int batchSize, Action<List<T>> action)
        {
            if (items.Count == 0 || batchSize < 1) return;

            var currentItemNumber = 0;
            var currentBatch = new List<T>();

            foreach (var item in items)
            {
                currentItemNumber++;
                currentBatch.Add(item);

                if (currentItemNumber%batchSize == 0 || currentItemNumber == items.Count)
                {
                    action(new List<T>(currentBatch));
                    currentBatch.Clear();
                }
            }
        }

        public static List<T> Flatten<T>(this List<List<T>> lists)
        {
            var flattenedList = new List<T>();

            foreach (var list in lists)
            {
                flattenedList.AddRange(list);
            }

            return flattenedList;
        }

        // TODO: Replace this with Linq GroupBy.
        public static Dictionary<TResult, List<T>> GroupUsing<TResult, T>(this IEnumerable<T> items,
            Func<T, TResult> func)
        {
            var dictionary = new Dictionary<TResult, List<T>>();

            foreach (var item in items)
            {
                var key = func(item);
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, new List<T> {item});
                }
                else
                {
                    var list = dictionary[key];
                    list.Add(item);
                }
            }

            return dictionary;
        }

        public static List<KeyValuePair<TKey, TValue>> ConvertEachKeyValue<TKey, TValue>(
            this Dictionary<TKey, List<TValue>> dictionary)
        {
            var flattenedListOfKeyValues = new List<KeyValuePair<TKey, TValue>>();
            foreach (var key in dictionary.Keys)
            {
                var values = dictionary[key];
                flattenedListOfKeyValues.AddRange(values.ConvertAll(v => new KeyValuePair<TKey, TValue>(key, v)));
            }
            return flattenedListOfKeyValues;
        }

        public static List<T> Unique<T>(this IEnumerable<T> items)
        {
            return items.Unique(x => x);
        }

        public static List<T> Unique<T, TResult>(this IEnumerable<T> items, Func<T, TResult> uniquenessCriterion)
        {
            var uniqueList = new List<T>();

            foreach (var item in items)
            {
                if (!uniqueList.Exists(i => uniquenessCriterion(i).Equals(uniquenessCriterion(item))))
                {
                    uniqueList.Add(item);
                }
            }

            return uniqueList;
        }

        public static bool HasIndex<T>(this IList<T> items, int index)
        {
            return items.Count > index;
        }

        public static bool TrueForAll<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static List<long> AsIdList<T>(this List<T> items) where T : DomainObject
        {
            return items.ConvertAll(item => item.IdValue);
        }

        /// <summary>
        ///     Return a string of comma seperated values using a converter for each object of type T.
        /// </summary>
        public static string AsString<T>(this IList<T> items, Converter<T, string> converter)
        {
            if (items != null)
            {
                return items.AsString(", ", converter);
            }
            else
            {
               return string.Empty;
            }
        }

        /// <summary>
        ///     Return a string of 'seperator' seperated values using a converter for each object of type T.
        /// </summary>
        public static string AsString<T>(this IList<T> items, string seperator, Converter<T, string> converter)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(seperator);
                }
                var item = items[i];
                stringBuilder.Append(converter(item));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Returns the last element in this collection.
        ///     If there are no items in the collection, it will return default(T)
        /// </summary>
        public static T Last<T>(this List<T> items)
        {
            var count = items.Count;
            return count == 0 ? default(T) : items[count - 1];
        }

        /// <summary>
        ///     Returns the last 'n' elements of this collection.
        /// </summary>
        public static List<T> Last<T>(this List<T> items, int num)
        {
            if (items.Count < num)
            {
                throw new NotSupportedException("Cannot get last:<" + num +
                                                "> elements when collection only has:<" + items.Count + ">");
            }

            return new List<T>(items.GetRange(items.Count - num, num));
        }

        public static string ToNewLineDelimitedString<T>(this IList<T> items)
        {
            return items == null || items.Count == 0
                ? string.Empty
                : string.Join(Environment.NewLine, items.ConvertAll(i => i.ToString()).ToArray());
        }


        public static List<T> First<T>(this List<T> items, int maxCount)
        {
            return items.Count < maxCount ? new List<T>(items) : new List<T>(items.GetRange(0, maxCount));
        }

        /// <summary>
        ///     Checks if there is one item that is common in both collections.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool Overlap<T>(this ICollection<T> list1, ICollection<T> list2)
        {
            if (list1 == null || list2 == null)
            {
                return false;
            }

            var countList1 = list1.Count;
            var countList2 = list2.Count;

            // want to make the smaller list the list passed to Overlaps since it's iterated over.
            return countList1 > countList2
                ? new HashSet<T>(list1).Overlaps(list2)
                : new HashSet<T>(list2).Overlaps(list1);
        }

        public static bool Exists(this NameValueCollection collection, string key)
        {
            return collection.AllKeys.Exists(k => k.Equals(key));
        }

        /// <summary>
        ///     Adds a string to a collection if it doesn't already exist, and sorts the collection.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static void AddAndSort(this List<string> list, string item)
        {
            if (!string.IsNullOrEmpty(item) && list.DoesNotContain(item))
            {
                list.Add(item);
                list.Sort();
            }
        }

        public static bool EqualsByElement<T>(this ICollection<T> keys1, ICollection<T> keys2)
        {
            if (keys1 == null || keys2 == null)
            {
                return false;
            }
            return ElementsInFirstAreInSecond(keys1, keys2) && ElementsInFirstAreInSecond(keys2, keys1);
        }

        private static bool ElementsInFirstAreInSecond<T>(ICollection<T> list1, ICollection<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            foreach (var s1 in list1)
            {
                if (!list2.Contains(s1))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValueEquals<T, TU>(this Dictionary<T, TU> map, Dictionary<T, TU> otherMap)
        {
            if (map == null)
            {
                throw new NullReferenceException(); // I hate that you can call extension methods on null objects.
            }

            if (otherMap == null)
            {
                return false;
            }

            if (map.Keys.Count != otherMap.Keys.Count)
            {
                return false;
            }

            if (map.Keys.Count == 0 && otherMap.Keys.Count == 0)
            {
                return true;
            }

            foreach (var key in map.Keys)
            {
                if (!otherMap.ContainsKey(key))
                {
                    return false;
                }

                if (!map[key].Equals(otherMap[key]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AllMembersAreEqual<T>(this List<T> list) where T : class
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }

            if (list.Count == 0)
            {
                return true;
            }

            var item = list[0];

            if (list.Exists(listItem => ((listItem != null) && !listItem.Equals(item)) || (listItem != item)))
            {
                return false;
            }

            if (list.TrueForAll(listItem => listItem == null))
            {
                return true;
            }

            return true;
        }

        public static List<T> SortByColumnsGoingDownEachColumn<T>(this List<T> attributes, int numColumns)
        {
            try
            {
                var columns = new List<List<T>>();
                var rowsPerColumn = new List<int>();
                for (var columnIndex = 0; columnIndex < numColumns; columnIndex++)
                {
                    columns.Add(new List<T>());

                    var minNumRowsPerColumn = attributes.Count/numColumns;
                    var remainder = attributes.Count%numColumns;
                    var rows = minNumRowsPerColumn;
                    if (columnIndex <= remainder - 1)
                    {
                        rows++;
                    }
                    rowsPerColumn.Add(rows);
                }

                {
                    var columnIndex = 0;
                    foreach (var attribute in attributes)
                    {
                        if (columns[columnIndex].Count >= rowsPerColumn[columnIndex])
                        {
                            columnIndex++;
                            if (columnIndex >= numColumns) // safety, shouldn't happen
                            {
                                columnIndex = numColumns - 1;
                            }
                        }

                        columns[columnIndex].Add(attribute);
                    }
                }

                var result = new List<T>();
                var rowIndex = 0;
                while (columns.Exists(column => rowIndex < column.Count))
                {
                    for (var columnIndex = 0; columnIndex < numColumns; columnIndex++)
                    {
                        if (rowIndex < columns[columnIndex].Count)
                        {
                            result.Add(columns[columnIndex][rowIndex]);
                        }
                    }
                    rowIndex++;
                }
                return result;
            }
            catch (Exception)
            {
                return attributes;
            }
        }

        public static void Sort<T, TOutput>(this List<T> list, Converter<T, TOutput> converter, bool sortByAscendOrder)
            where T : class
            where TOutput : class, IComparable
        {
            IComparer<T> comparer = new ClassConverterComparer<T, TOutput>(converter);
            if (!sortByAscendOrder)
            {
                comparer = new ReverseComparer<T>(comparer);
            }
            list.Sort(comparer);
        }

        public static void Sort<T>(this List<T> list, Converter<T, int> converter) where T : class
        {
            list.Sort((a, b) => converter(a).CompareTo(converter(b)));
        }

        public static void Sort<T>(this List<T> list, Converter<T, DateTime> converter) where T : class
        {
            Sort(list, converter, true);
        }

        public static void Sort<T>(this List<T> list, Converter<T, DateTime> converter, bool sortAscending)
            where T : class
        {
            list.Sort(
                (a, b) =>
                    sortAscending
                        ? DateTime.Compare(converter(a), converter(b))
                        : DateTime.Compare(converter(b), converter(a)));
        }

        /// <summary>
        ///     Extension method to take an Object, convert it to a String (usually one of it's properties) and sort the strings
        ///     using the Current Culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="converter"></param>
        public static void Sort<T>(this List<T> list, Converter<T, string> converter)
        {
            Sort(list, converter, true);
        }

        public static void Sort<T>(this List<T> list, Converter<T, string> converter, bool sortByAscendOrder)
        {
            IComparer<T> comparer = new StringConverterComparer<T>(converter, StringComparison.CurrentCulture);
            if (!sortByAscendOrder)
            {
                comparer = new ReverseComparer<T>(comparer);
            }
            list.Sort(comparer);
        }

        private class StringConverterComparer<TInputType> : Comparer<TInputType>
        {
            private readonly StringComparison comparisonType;
            private readonly Converter<TInputType, string> converter;

            public StringConverterComparer(Converter<TInputType, string> converter, StringComparison comparisonType)
            {
                this.converter = converter;
                this.comparisonType = comparisonType;
            }

            public override int Compare(TInputType x, TInputType y)
            {
                var itemX = converter(x);
                var itemY = converter(y);
                return string.Compare(itemX, itemY, comparisonType);
            }
        }

        #region Nested type: ClassConverterComparer

        private class ClassConverterComparer<TInputType, TResultType> : Comparer<TInputType>
            where TResultType : class, IComparable
            where TInputType : class
        {
            private readonly Converter<TInputType, TResultType> converter;

            public ClassConverterComparer(Converter<TInputType, TResultType> converter)
            {
                this.converter = converter;
            }

            public override int Compare(TInputType x, TInputType y)
            {
                // Implementing Comparer, not IComparer. So, null checks of x and y are already dealt with.
                var itemX = converter(x);
                var itemY = converter(y);

                if (itemX == null)
                {
                    return itemY != null ? -1 : 0;
                }
                return itemY == null ? 1 : itemX.CompareTo(itemY);
            }
        }

        #endregion
    }
}