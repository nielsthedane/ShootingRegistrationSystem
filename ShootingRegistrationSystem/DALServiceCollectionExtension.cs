using DAL;

namespace Microsoft.Extensions.DependencyInjection
{
    public  static class DALServiceCollectionExtension
    {
        public static IServiceCollection AddSrsDAL(this IServiceCollection services)
        {
            services.AddSingleton<IdbRepository, DbRepository>();
            return services;
        }
    }
}