using System.Windows;
using DAL;
using Shared.Models;
using Unity;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Shooting, ShootingModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Caliber, CaliberModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<PaymentTypes, PaymentTypesModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<ShootingTypes, ShootingTypesModel>().ReverseMap().PreserveReferences();
            });
            //AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
