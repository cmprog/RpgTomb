using System.Collections;
using System.Collections.Generic;

namespace RpgTome.Repositories
{
    public class PagedResult<T> : IEnumerable<T>
    {
        private readonly IList<T> mResults;

        public PagedResult(IList<T> results, int totalCount, int skipped, int itemsPerPage)
        {
            this.mResults = results;
            TotalResults = totalCount;
            ItemsPerPage = itemsPerPage;
            Page = (int)((decimal)skipped / itemsPerPage);
            TotalPages = (int)((decimal)totalCount / ItemsPerPage + 1);
        }

        public int TotalResults { get; private set; }

        /// <summary>
        /// Page Number is 0 based
        /// </summary>
        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public int ItemsPerPage { get; private set; }

        public int Count
        {
            get { return mResults.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return mResults.GetEnumerator();
        }

        public T this[int index]
        {
            get { return mResults[index]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
