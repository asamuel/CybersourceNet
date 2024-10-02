using CybersourceNet_App.Contracts;
using CybersourceNet_App.Services;
using CybersourceNet_Common.Configurations;
using HGUtils.Helpers.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurations(
           this IServiceCollection services, IConfiguration configuration) =>
           services
               .AddConfig<ApiConfig>(configuration)
               .AddConfig<JwtConfig>(configuration);
        public static IServiceCollection AddIoC(this IServiceCollection services) =>
           services
               .AddTransient<IPayment, PaymentService>()
               .AddTransient<ICapture, CaptureService>()
               .AddTransient<IReversal, ReversalService>()
               .AddTransient<IAuth, AuthService>()
               .AddTransient<ITransactionSearch, TransactionSearchService>();
    }
}
