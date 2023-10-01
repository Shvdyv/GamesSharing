namespace GameSharing.Forum.Service
{
    public class AddPostRepresantation
    {
        public string Author { get; set; }
        public string Content { get; set; }

        public AddPostRepresantation(string author, string content)
        {
            Author = author;
            Content = content;
        }
    }
}
