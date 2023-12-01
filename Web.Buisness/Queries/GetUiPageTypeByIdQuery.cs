using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Buisness.Models;

namespace WebBuisness.Queries
{
    public record GetUiPageTypeByIdQuery(int Id) : IRequest<UiPageType>;
}
