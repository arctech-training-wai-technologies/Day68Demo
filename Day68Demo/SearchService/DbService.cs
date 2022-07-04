namespace Day68Demo.SearchService;

public class SearchResponse
{
    public string Answer { get; set; }
}

public class DbService : ISearchService
{
    public SearchResponse Search(int caseId, string serviceNo)
    {
        //var connection = new SqlConnection();

        return new SearchResponse { Answer = "Test" };
    }

    public bool CheckIfServiceNoExists(int serviceNo1)
    {
        //db code
        return true;
    }
}