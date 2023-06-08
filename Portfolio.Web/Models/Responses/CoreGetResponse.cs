namespace Portfolio.Web.Models.Responses
{
    public class CoreGetResponse<TEntity> : CoreResponseModel
    {
        public TEntity Data { get; set; }
    }
}
