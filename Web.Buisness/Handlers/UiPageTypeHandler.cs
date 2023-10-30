using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBuisness.Models;
using WebBuisness.Queries;
using WebBuisness.Repository.Interface;

namespace WebBuisness.Handlers
{
    public class UiPageTypeHandler : IRequestHandler<GetUiPageTypeQuery, List<UiPageType>>
    {
        private readonly IUiPageTypeRepository _uiPageTypeRepository;

        public UiPageTypeHandler(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public Task<List<UiPageType>> Handle(GetUiPageTypeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Get());
        }
    }
}
