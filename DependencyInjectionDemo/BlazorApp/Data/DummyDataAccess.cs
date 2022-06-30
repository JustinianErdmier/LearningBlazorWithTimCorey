namespace BlazorApp.Data;

public class DummyDataAccess : IDataAccess
{
    private int Age { get; init; }

    public DummyDataAccess()
    {
        Random rnd = new Random();
        Age = rnd.Next(1, 10);
    }

    public int GetUserAge()
    {
        return Age;
    }
}
