using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBuisness.Models;

namespace WebBuisness.Commands
{
    public record UiPageTypeCreateCommand(string Name) : IRequest<UiPageType>;
}
