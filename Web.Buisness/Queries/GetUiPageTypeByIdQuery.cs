using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBuisness.Models;

namespace WebBuisness.Queries
{
    public record GetUiPageTypeByIdQuery(int Id) : IRequest<UiPageType>;
}
