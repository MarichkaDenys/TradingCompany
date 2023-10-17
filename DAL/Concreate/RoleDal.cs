using AutoMapper;

namespace DAL.Concreate
{
    public class RoleDal : IRoleDal, IDisposable
    {
        private readonly TradingCompanyContext _dbContext;
        private readonly IMapper _mapper;

        public RoleDal(string connectionString, IMapper mapper)
        {
            _dbContext = new TradingCompanyContext(connectionString);
            _mapper = mapper;

        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<Role> GetAll()
        {
            List<Role> roles = _dbContext.Roles.ToList();
            return _mapper.Map<List<Role>>(roles);
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Role Insert(Role role)
        {
            var newRole = _mapper.Map<Role>(role);
            _dbContext.Roles.Add(newRole);
            _dbContext.SaveChanges();
            return _mapper.Map<Role>(newRole);
        }

        public Role Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
