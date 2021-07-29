using System.Dynamic;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class UserMemoryService : IUserMemoryService
    {
        private int _serSummMoney = 0;

        public int IncreaseMoney(int summ)
        {
            return _serSummMoney += summ;
        }

        public int DecreaseMoney(int summ)
        {
            return _serSummMoney -= summ;
        }

        public int GetUserMoney()
        {
            return _serSummMoney;
        }
    }
}