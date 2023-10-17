namespace DAL
{
    public interface ISupplyHistoryDal
    {
        List<SupplyHistory> GetAll();

        SupplyHistory GetById(int id);

        SupplyHistory Insert(SupplyHistory supplyhistory);

        SupplyHistory Update(SupplyHistory supplyhistory);

        void DeleteById(int id);

    }
}
