namespace DAL
{
    public interface IPersonDal
    {
        List<Person> GetAll();

        Person GetById(int id);

        Person Insert(Person person);

        Person Update(Person person);

        void DeleteById(int id);
    }
}
