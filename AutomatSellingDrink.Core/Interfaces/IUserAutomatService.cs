namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatService
    {
        void DepositCoins();
        void GetChange();
        void GetAvailableDepositCoins();
        void BuyDrink();
        void GetAvailableDrinks();
    }
}