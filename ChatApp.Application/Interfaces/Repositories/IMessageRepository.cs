using ChatApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
