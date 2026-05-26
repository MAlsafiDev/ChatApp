using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Queries.Response
{
    public class GetMessageByIdDto
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public string SenderUserName { get; set; } = string.Empty;

        public int RecipientId { get; set; }

        public string RecipientUserName { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime MessageSent { get; set; }
    }
}
