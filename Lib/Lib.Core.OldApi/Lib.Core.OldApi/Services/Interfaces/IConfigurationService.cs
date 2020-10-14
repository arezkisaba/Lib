namespace Lib.Core.Services.Interfaces
{
    public interface IConfigurationService
    {
        T Get<T>(string name);
    }
}