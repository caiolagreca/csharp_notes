namespace DI.Services;

public interface ITransientService
{
    Guid GetId();
}

public interface IScopedService
{
    Guid GetId();
}

public interface ISingletonService
{
    Guid GetId();
}

public class SomeService : ITransientService, IScopedService, ISingletonService
{
    Guid id;
    public SomeService()
    {
        id = Guid.NewGuid();
    }

    public Guid GetId()
    {
        return id;
    }
}