namespace HappyMama.BusinessLogic.ViewModels.Event
{
    public class EventPayModel 
    {
        public int Id { get; set; }

        public string EventName { get; set; } = string.Empty;

        public decimal PaySum { get; set; }
    }
}
