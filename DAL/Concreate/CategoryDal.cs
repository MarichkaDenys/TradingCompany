using AutoMapper;

namespace DAL.Concreate
{
    public class CategoryDal : ICategoryDal, IDisposable
    {
        private readonly TradingCompanyContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryDal(string connectionString, IMapper mapper)
        {
            _dbContext = new TradingCompanyContext(connectionString);
            _mapper = mapper;
        }
        public void DeleteById(int id)
        {
            var categoryToDelete = _dbContext.Categories.Find(id);

            if (categoryToDelete != null)
            {
                _dbContext.Categories.Remove(categoryToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<Category> GetAll()
        {
            List<Category> categories = _dbContext.Categories.ToList();
            return _mapper.Map<List<Category>>(categories);
        }

        public Category GetById(int id)
        {
            var category = _dbContext.Categories.Find(id);
            return _mapper.Map<Category>(category);
        }

        public Category Insert(Category category)
        {
            category.Date = DateTime.Now;
            var newCategory = _mapper.Map<Category>(category);
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return _mapper.Map<Category>(newCategory);
        }

        public Category Update(Category category)
        {
            var existingCategory = _dbContext.Categories.Find(category.CategoryId);

            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Date = DateTime.Now;

                _dbContext.SaveChanges();
                return _mapper.Map<Category>(existingCategory);
            }

            throw new InvalidOperationException($"Category with ID {category.CategoryId} not found."); ;
        }
    }
}
