namespace DAL
{
    public interface ICategoryDal
    {
        List<Category> GetAll();

        Category GetById(int id);

        Category Insert(Category category);

        Category Update(Category category);

        void DeleteById(int id);
    }
}
