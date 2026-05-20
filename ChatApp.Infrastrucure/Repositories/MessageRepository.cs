using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entites;
using ChatApp.Infrastrucure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastrucure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatAppDbContext context) : base(context)
        {
        }
    }
}
