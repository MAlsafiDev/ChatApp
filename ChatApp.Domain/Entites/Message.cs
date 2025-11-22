using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entites
{
    public class Message : BaseEntity
    {
        public int SenderId { get; set; }
        public string SenderUserName { get; set; } = string.Empty;
        public int RecipintId { get; set; }

        public string RecipintUserName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime? DateRead { get; set; }
        public DateTime MessageSend { get; set; } = DateTime.UtcNow;

        public bool SenderDeleted { get; set; }
        public bool RecipintDeleted { get; set; }
    }
}
