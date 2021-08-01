namespace AutomatSellingDrink.API.Contracts
{
    public class Error
    {
        public string Text { get; set; }

        public Error(string text)
        {
            Text = text;
        }

        public Error()
        {
            
        }
    }
}