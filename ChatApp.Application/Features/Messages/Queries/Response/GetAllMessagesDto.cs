namespace ChatApp.Application.Features.Messages.Queries.Response
{
    public class GetAllMessagesDto
    {
        public int Id { get; set; }

        public string SenderUserName { get; set; } = string.Empty;

        public string RecipientUserName { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime MessageSent { get; set; }
    }
}
