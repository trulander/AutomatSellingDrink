namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserMemoryService
    {
        int IncreaseMoney(int summ);
        int DecreaseMoney(int summ);
        int GetUserMoney();
    }
}