using MediatR;
using WebBuisness.Repository.Interface;

namespace Web.Buisness.Features.UiPageType.Queries
{
    public class UiPageTypeHandler : IRequestHandler<GetUiPageTypeQuery, List<Models.UiPageType>>,IRequestHandler<GetUiPageTypeByIdQuery, Models.UiPageType>
    {
        private readonly IUiPageTypeRepository _uiPageTypeRepository;

        public UiPageTypeHandler(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }

        public Task<List<Models.UiPageType>> Handle(GetUiPageTypeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Get());
        }

        public Task<Models.UiPageType> Handle(GetUiPageTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_uiPageTypeRepository.Get(request.Id));
        }
    }
}
