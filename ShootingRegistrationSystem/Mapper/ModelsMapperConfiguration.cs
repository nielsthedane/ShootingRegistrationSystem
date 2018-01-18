using AutoMapper;
using Shared.Models;

namespace DAL.Mapper
{
    public class ModelsMapperConfiguration
    {
        public ModelsMapperConfiguration()
        {
           runConfig();
        }

        public void runConfig()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
            });
        }

    }
}
