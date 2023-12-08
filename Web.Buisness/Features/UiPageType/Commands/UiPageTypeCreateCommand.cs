using MediatR;

using Web.Buisness.Models;

namespace Web.Buisness.Features.UiPageType.Commands
{
    public record UiPageTypeCreateCommand(string Name) : IRequest<Web.Buisness.Models.UiPageType>;
    public record UiPageTypeDeleteCommand(int Id) : IRequest<int>;
    public record UiPageTypeUpdateCommand(int Id, string Name) : IRequest<Web.Buisness.Models.UiPageType>;
}
