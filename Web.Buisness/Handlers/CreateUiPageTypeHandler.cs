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
    public class CreateUiPageTypeHandler : IRequestHandler<UiPageTypeCreateCommand, UiPageType>
    {
        private readonly IUiPageTypeRepository _uiPageTypeRepository;

        public CreateUiPageTypeHandler(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public Task<UiPageType> Handle(UiPageTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Create(new UiPageType { Name= request.Name }));
        }
    }
}
