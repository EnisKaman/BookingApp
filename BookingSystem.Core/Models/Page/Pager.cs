namespace BookingSystem.Core.Models.Page
{
    public class Pager
    {
        private const int _PageSize = 5;
        public Pager()
        {

        }
        public Pager(int totalItems, int currentPage)
        {
            Configure(totalItems, currentPage);
        }

        private void Configure(int totalItems, int currentPage)
        {
            int totalPages = (int)Math.Ceiling((double)totalItems / _PageSize);
            int currPage = currentPage;
            int startPage = Math.Max(1, currPage - 3);
            int endPage = Math.Min(startPage + 3, totalPages);

            if (endPage >= 10)
            {
                startPage = endPage - 6;
            }

            TotalPages = totalPages;
            CurrentPage = currPage;
            PageSize = _PageSize;
            StartPage = startPage;
            EndPage = endPage;
            TotalItems  = totalItems;
        }

        /// <summary>
        /// Total number of entity records
        /// </summary>
        public int TotalItems  { get; private set; }
        /// <summary>
        /// The active page on page bar
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// The size of number of records displayed on the page
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Total number of pages on page bar
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// The page number which is first on page bar
        /// </summary>
        public int StartPage { get; private set; }
        /// <summary>
        ///  The page number which is last on page bar
        /// </summary>
        public int EndPage { get; private set; }
    }
}
