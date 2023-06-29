namespace BookingSystem.Core.Models.Page
{
    public class Pager
    {
        private const int _PageSize = 6;
        public Pager()
        {

        }
        public Pager(int totalItems, int currentPage) 
        {
            int totalPages = (int)Math.Ceiling((double)totalItems / _PageSize);
            int currPage = currentPage;
            int startPage = currPage - 5;
            int endPage = currPage + 5;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if(endPage > totalPages)
            {
                endPage = totalPages;
            }
            if(endPage > 10)
            {
                startPage = endPage - 9;
            }
            TotalPages = totalPages;
            CurrentPage = currPage;
            PageZise = _PageSize;
            StartPage = startPage;
            EndPage = endPage;
            TotalItmes = totalItems;
        }
        /// <summary>
        /// Total number of entity records
        /// </summary>
        public int TotalItmes { get; private set; }
        /// <summary>
        /// The active page on page bar
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// The size of number of records displayed on the page
        /// </summary>
        public int PageZise { get; private set; }
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
