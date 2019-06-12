namespace Panda.WebApp
{
    using SIS.MvcFramework;

    public static class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
