namespace EthereumApi.Framework.DTO
{
    public class ApiRequest : BaseApiDto
    {
        public string Method { get; set; }
        public string[] Params { get; set; }
    }
}