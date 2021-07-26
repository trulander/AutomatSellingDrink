namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatRepository
    {
        void DepositCoins();
        void GetChange();
        void GetAvailableDepositCoins();
        void BuyDrink();
        void GetAvailableDrinks();
    }
}