namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models
{
    public interface ICar
    {
        string Name { get; set; }
    }

    public class Ford : ICar
    {
        public string Name { get; set; } = "Ford";
    }

    public class Toyota : ICar
    {
        public string Name { get; set; } = "Toyota";
    }

    public class Chevy : ICar
    {
        public string Name { get; set; } = "Chevy";
    }
}
