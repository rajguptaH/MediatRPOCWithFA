using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Buisness.Models;
using WebBuisness.Queries;
using WebBuisness.Repository.Interface;

namespace WebBuisness.Handlers
{
    public class UiPageTypeByIdHandler : IRequestHandler<GetUiPageTypeByIdQuery, UiPageType>
    {
        private readonly IUiPageTypeRepository _uiPageTypeRepository;

        public UiPageTypeByIdHandler(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public Task<UiPageType> Handle(GetUiPageTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Get(request.Id));
        }
    }
}
