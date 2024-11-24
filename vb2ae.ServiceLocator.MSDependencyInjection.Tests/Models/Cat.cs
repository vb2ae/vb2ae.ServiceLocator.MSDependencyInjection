namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models
{
    public class Cat : IPet
    {
        public string Speak()
        {
            return "Meow";
        }
    }
}
