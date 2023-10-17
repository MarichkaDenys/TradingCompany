using AutoMapper;

namespace DAL.Concreate
{
    public class ProductDal : IProductDal, IDisposable
    {
        private readonly TradingCompanyContext _dbContext;
        private readonly IMapper _mapper;

        public ProductDal(string connectionString, IMapper mapper)
        {
            _dbContext = new TradingCompanyContext(connectionString);
            _mapper = mapper;
        }

        public ProductDal(object connectionString, object mapper)
        {
            ConnectionString = connectionString;
            Mapper = mapper;
        }

        public object ConnectionString { get; }
        public object Mapper { get; }

        public void DeleteById(int id)
        {
            var productToDelete = _dbContext.Products.Find(id);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<Product> GetAll()
        {
            List<Product> products = _dbContext.Products.ToList();
            return _mapper.Map<List<Product>>(products);
        }

        public Product GetById(int id)
        {
            var product = _dbContext.Products.Find(id);
            return _mapper.Map<Product>(product);
        }

        public Product Insert(Product product)
        {
            product.Date = DateTime.Now;
            var newProduct = _mapper.Map<Product>(product);
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return _mapper.Map<Product>(newProduct);
        }

        public Product Update(Product product)
        {
            var existingProduct = _dbContext.Products.Find(product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ProductName = product.ProductName;
                existingProduct.Quantity = product.Quantity;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.Date = DateTime.Now; 

                _dbContext.SaveChanges();
                return _mapper.Map<Product>(existingProduct);
            }

            throw new InvalidOperationException($"Product with ID {product.ProductId} not found.");

        }
    }
}
