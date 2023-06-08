namespace Portfolio.Web.Models.Responses
{
    public class CoreListResponse<TEntity> : CoreResponseModel
    {
        public List<TEntity>? Data { get; set; }
    }
}
