using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Buisness.Models;
using WebBuisness.Commands;
using WebBuisness.Queries;
using WebBuisness.Repository.Interface;

namespace WebBuisness.Handlers
{
    public class UpdateUiPageTypeHandler : IRequestHandler<UiPageTypeUpdateCommand, UiPageType>
    {
        private readonly IUiPageTypeRepository _uiPageTypeRepository;

        public UpdateUiPageTypeHandler(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public Task<UiPageType> Handle(UiPageTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Update(new UiPageType { Id = request.Id, Name = request.Name }));
        }
    }
}
