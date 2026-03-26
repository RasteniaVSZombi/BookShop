namespace BookLibrary
{
    public enum CustomerRequestType
    {
        SpecificBook,
        Genre
    }

    public class Customer
    {
        public int Id { get; set; }
        public CustomerRequestType RequestType { get; set; }

        public string RequestedTitle { get; set; } = "";
        public string RequestedAuthor { get; set; } = "";
        public string RequestedGenre { get; set; } = "";

        public decimal MaxPrice { get; set; }
        public bool IsWaitingForOrder { get; set; }

        public override string ToString()
        {
            if (RequestType == CustomerRequestType.SpecificBook)
                return $"#{Id}: {RequestedTitle} — {RequestedAuthor}, до {MaxPrice:F2} руб.";

            return $"#{Id}: любая книга жанра {RequestedGenre}, до {MaxPrice:F2} руб.";
        }
    }
}