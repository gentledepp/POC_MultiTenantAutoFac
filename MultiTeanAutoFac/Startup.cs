public interface IDependency
{
    string Postfix();
}

public class CommonDependency : IDependency
{
    public CommonDependency()
    {
        
    }
    public string Postfix()
    {
        return "[]";
    }
}