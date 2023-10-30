using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBuisness.Commands
{
    public record UiPageTypeDeleteCommand(int Id):IRequest<int>;
}
