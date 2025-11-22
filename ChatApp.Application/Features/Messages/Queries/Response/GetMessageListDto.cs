namespace ChatApp.Application.Features.Messages.Queries.Response
{
    public class GetMessageListDto

    {
        public string SenderUserName { get; set; } = string.Empty;
        public string RecipintUserName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime? DateRead { get; set; }
       
    }
}
