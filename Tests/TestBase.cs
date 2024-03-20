using Application.Mapper;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Tests
{
    public class TestBase
    {
        private HomeApplianceContext? _context;
        protected HomeApplianceContext Context 
        {
            get 
            {
                if (_context is not null)
                {
                    return _context;
                }

                var options = new DbContextOptionsBuilder<HomeApplianceContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                _context = new HomeApplianceContext(options);
                _context.Database.EnsureCreated();
                return _context;
            } 
        }

        protected static IMapper Mapper
        {
            get
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                return mapperConfig.CreateMapper();
            }
        }
    }
}
