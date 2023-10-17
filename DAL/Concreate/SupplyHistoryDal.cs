using AutoMapper;

namespace DAL.Concreate
{
    public class SupplyHistoryDal : ISupplyHistoryDal, IDisposable
    {
        private readonly TradingCompanyContext _dbContext;
        private readonly IMapper _mapper;

        public SupplyHistoryDal(string connectionString, IMapper mapper)
        {
            _dbContext = new TradingCompanyContext(connectionString);
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            var supplyHistoryToDelete = _dbContext.SupplyHistories.Find(id);

            if (supplyHistoryToDelete != null)
            {
                _dbContext.SupplyHistories.Remove(supplyHistoryToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<SupplyHistory> GetAll()
        {
            List<SupplyHistory> supplyhistories = _dbContext.SupplyHistories.ToList();
            return _mapper.Map<List<SupplyHistory>>(supplyhistories);
        }

        public SupplyHistory GetById(int id)
        {
            var supplyHistory = _dbContext.SupplyHistories.Find(id);
            return _mapper.Map<SupplyHistory>(supplyHistory);
        }

        public SupplyHistory Insert(SupplyHistory supplyhistory)
        {
            supplyhistory.Date = DateTime.Now;
            var newSupplyHistory = _mapper.Map<SupplyHistory>(supplyhistory);
            _dbContext.SupplyHistories.Add(newSupplyHistory);
            _dbContext.SaveChanges();
            return _mapper.Map<SupplyHistory>(newSupplyHistory);
        }

        public SupplyHistory Update(SupplyHistory supplyhistory)
        {
            var existingSupplyHistory = _dbContext.SupplyHistories.Find(supplyhistory.SupplyHistoryId);

            if (existingSupplyHistory != null)
            {
                existingSupplyHistory.Product = supplyhistory.Product;
                existingSupplyHistory.Person = supplyhistory.Person;
                existingSupplyHistory.Action = supplyhistory.Action;
                existingSupplyHistory.Date = DateTime.Now; 

                _dbContext.SaveChanges();
                return _mapper.Map<SupplyHistory>(existingSupplyHistory);
            }

            throw new InvalidOperationException($"Supply history with ID {supplyhistory.SupplyHistoryId} not found.");
        }
    }
}
