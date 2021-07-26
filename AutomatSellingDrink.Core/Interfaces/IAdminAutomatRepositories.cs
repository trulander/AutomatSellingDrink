namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatRepositories
    {
        void CreateDrink();
        void DeleteDrink();
        void UpdateDrink();
        void GetDrink();
        void GetAllDrinks();
        void UpdateQuantityCoins();
        void GetQuantityCoins();
        void UpdateAvailableDepositCoins();
        void GetAvailableDepositCoins();
    }
}