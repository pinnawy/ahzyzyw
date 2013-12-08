namespace Ahzyzyw.Model
{
    public class NewsQueryOption : QueryOptionBase
    {
        public NewsQueryOption()
        {
            QueryKeyWord = string.Empty;
        }

        public string QueryKeyWord { get; set; }
    }
}
