using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Buisness.Features.UiPageType;
using Web.Buisness.Features.UiPageType.Commands;
using Web.Buisness.Interface;
using Web.Buisness.Models;
using Web.Buisness.PipelineBehaviors;

namespace WebBuisness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IAuthorizationRule<GetUiPageType.Command>, GetUiPageType.Authorization>();
            services.AddTransient<IAuthorizationRule<GetByIdUiPageType.Command>, GetByIdUiPageType.Authorization>();
            services.AddTransient<IAuthorizationRule<CreateUiPageType.Command>, CreateUiPageType.Authorization>();
            services.AddTransient<IAuthorizationRule<UpdateUiPageType.Command>, UpdateUiPageType.Authorization>();
            services.AddTransient<IAuthorizationRule<DeleteUiPageType.Command>, DeleteUiPageType.Authorization>();
            return services;

        }
    }
}
