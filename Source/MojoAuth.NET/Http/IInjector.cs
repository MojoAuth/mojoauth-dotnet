namespace MojoAuth.NET.Http
{
	public interface IInjector
    {
        void Inject(HttpRequest request);
    }
}
