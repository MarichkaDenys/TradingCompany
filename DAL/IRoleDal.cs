namespace DAL
{
    public interface IRoleDal
    {
        List<Role> GetAll();

        Role GetById(int id);

        Role Insert(Role role);

        Role Update(Role role);

        void DeleteById(int id);

    }
}
