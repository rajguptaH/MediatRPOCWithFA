using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Web.Buisness.Interface;
using WebBuisness.Repository.Interface;

namespace Web.Buisness.Features.UiPageType
{
    public static class GetUiPageType
    {
        public class Command : IRequest<List<Web.Buisness.Models.UiPageType>>
        {
        }
        public class Authorization : IAuthorizationRule<Command>
        {

            public Task Authorize(Command request, CancellationToken cancellationToken, IHttpContextAccessor contex)
            {
                throw new NotImplementedException();
            }
        }
        public class Handler : IRequestHandler<Command, List<Web.Buisness.Models.UiPageType>>
        {
            private readonly IUiPageTypeRepository _uiPageTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IUiPageTypeRepository uiPageTypeRepository, IMapper mapper)
            {
                _uiPageTypeRepository = uiPageTypeRepository;
                _mapper = mapper;
            }

            Task<List<Models.UiPageType>> IRequestHandler<Command, List<Models.UiPageType>>.Handle(Command request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_uiPageTypeRepository.Get());
            }
        }
    }
    
}
