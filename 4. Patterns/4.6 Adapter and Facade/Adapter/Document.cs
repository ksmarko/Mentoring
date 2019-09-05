namespace Adapter
{
    public class Document
    {
        public string Name { get; }
        public string Content { get; }
        public int Size { get; }

        public Document(string name, string content)
        {
            Name = name;
            Content = content;
            Size = content.Length;
        }
    }
}
