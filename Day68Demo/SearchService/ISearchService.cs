namespace Day68Demo.SearchService
{
    public interface ISearchService
    {
        SearchResponse Search(int caseId, string serviceNo);
        bool CheckIfServiceNoExists(int serviceNo1);
    }
}
