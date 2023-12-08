using MediatR;

namespace Web.Buisness.Features.UiPageType.Queries
{
    public record GetUiPageTypeQuery : IRequest<List<Models.UiPageType>>;
    public record GetUiPageTypeByIdQuery(int Id) : IRequest<Models.UiPageType>;
}
