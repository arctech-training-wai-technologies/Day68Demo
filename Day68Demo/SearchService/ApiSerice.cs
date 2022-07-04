namespace Day68Demo.SearchService
{
    public class ApiSerice : ISearchService
    {
        public SearchResponse Search(int caseId, string serviceNo)
        {
            // API Code

            return new SearchResponse {Answer = "Test"};
        }

        public bool CheckIfServiceNoExists(int serviceNo1)
        {
            // API 

            return true;
        }
    }
}
