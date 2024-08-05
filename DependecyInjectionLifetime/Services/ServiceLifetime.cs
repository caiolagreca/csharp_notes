public interface ITransientService
{
    Guid GetID();
}

public interface IScopedService
{
    Guid GetID();
}

public interface ISingletonService
{
    Guid GetID();
}

public class ServiceLifetime : ITransientService, IScopedService, ISingletonService
{
    Guid id;

    public ServiceLifetime()
    {
        id = Guid.NewGuid();
    }

    public Guid GetID()
    {
        return id;
    }
}
