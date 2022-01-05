namespace AzEnStudyApp.Application.Parameter
{

    public class RequestParameter
    {
        public RequestParameter(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }

}