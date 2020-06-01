using LongStoryShort.DAL.Repositories;

namespace LongStoryShort.ApplicationCore.Services
{
    public class ExampleService
    {
        public static string HelloWorld()
        {
            return ExampleRepository.HelloWorld();
        }
    }
}
