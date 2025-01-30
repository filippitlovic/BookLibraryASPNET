namespace BookLibrary.Models.Entities
{
    public class BookApiModel
    {
        public List<BookInfo> Items { get; set; }
    }

    public class BookInfo
    {
        public string Id { get; set; }
        public VolumeInfo volumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
    }
}
