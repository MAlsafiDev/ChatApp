using ChatApp.Domain.Entites;
using ChatApp.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastrucure.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message>
    {

    }
}
