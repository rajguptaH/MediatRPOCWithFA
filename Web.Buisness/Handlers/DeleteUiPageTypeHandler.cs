using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBuisness.Commands;
using WebBuisness.Models;
using WebBuisness.Queries;
using WebBuisness.Repository.Interface;

namespace WebBuisness.Handlers
{
    public class DeleteUiPageTypeHandler : IRequestHandler<UiPageTypeDeleteCommand, int>
    {
        private readonly IUiPageTypeRepository _uiPageType;

        public DeleteUiPageTypeHandler(IUiPageTypeRepository uiPageType)
        {
            _uiPageType = uiPageType;
        }

        public Task<int> Handle(UiPageTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageType.Delete(request.Id));
        }
    }
}
