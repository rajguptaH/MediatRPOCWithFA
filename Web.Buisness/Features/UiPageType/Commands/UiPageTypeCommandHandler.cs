using MediatR;
using WebBuisness.Repository.Interface;
using AutoMapper;

namespace Web.Buisness.Features.UiPageType.Commands
{

    /// <summary>
    ///     Handles <see cref="" /> commands.
    /// </summary>
    public class UiPageTypeCreateCommandHandler : IRequestHandler<UiPageTypeCreateCommand,Web.Buisness.Models.UiPageType>,
                                              IRequestHandler<UiPageTypeUpdateCommand, Web.Buisness.Models.UiPageType>,
                                              IRequestHandler<UiPageTypeDeleteCommand, int>

    {


        private readonly IUiPageTypeRepository _uiPageTypeRepository;
        private readonly IMapper _mapper;

        public UiPageTypeCreateCommandHandler(IUiPageTypeRepository uiPageTypeRepository, IMapper mapper)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UiPageTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            return  _uiPageTypeRepository.Delete(request.Id);
        }

        public Task<Web.Buisness.Models.UiPageType> Handle(UiPageTypeCreateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Models.UiPageType>(request);
            return Task.FromResult(_uiPageTypeRepository.Create(product));
        }

        public Task<Web.Buisness.Models.UiPageType> Handle(UiPageTypeUpdateCommand request, CancellationToken cancellationToken)
        {

            var product = _mapper.Map<Models.UiPageType>(request);
            return Task.FromResult(_uiPageTypeRepository.Update(product));
        }
    }
}