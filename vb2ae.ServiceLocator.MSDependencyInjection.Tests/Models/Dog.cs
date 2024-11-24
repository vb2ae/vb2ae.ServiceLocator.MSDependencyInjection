namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models
{
    public class Dog : IPet
    {
        public string Speak()
        {
            return "Bark";
        }
    }
}
