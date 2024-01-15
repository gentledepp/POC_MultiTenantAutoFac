public interface IDependency
{
    string Postfix();
}

public class CommonDependency : IDependency
{
    public string Postfix()
    {
        return "[]";
    }
}