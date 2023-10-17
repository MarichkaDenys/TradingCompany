namespace DAL
{
    public interface IProductDal
    {
        List<Product> GetAll();

        Product GetById(int id);

        Product Insert(Product product);

        Product Update(Product product);

        void DeleteById(int id);

    }
}