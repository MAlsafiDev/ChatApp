using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Mapping.Messages
{
    public partial class MessageProfile : Profile
    {
        public MessageProfile()
        {
            AddMessageMapping();

        }
    }
}
