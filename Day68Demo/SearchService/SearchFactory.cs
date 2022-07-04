namespace Day68Demo.SearchService
{
    public static class SearchFactory
    {
        public static ISearchService Create()
        {
            //return new DbService();
            return new ApiSerice();
        }
    }
}
