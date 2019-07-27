namespace P02._Books_Before.Contracts
{
    public interface IBook
    {
        string Title { get;}
        string Author { get;  }
        
        string TurnPage(int page);
    }
}
