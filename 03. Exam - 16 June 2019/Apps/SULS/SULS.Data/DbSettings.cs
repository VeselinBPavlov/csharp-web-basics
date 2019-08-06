namespace SULS.Data
{
    public class DbSettings
    {
        public const string ConnectionStringHome = "Server=.;Database=SulsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        public const string ConnectionStringWork = "Server=(LocalDB)\\MSSQLLocalDB;Database=SulsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}