namespace Reko.Contracts.ApiRequestFramework
{
    public interface IMovieDbSettings
    {
        string ApiKey { get; }

        string ApiUrl { get; }
    }
}