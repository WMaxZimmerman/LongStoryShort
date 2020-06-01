using LongStoryShort.ApplicationCore.Services;
using LongStoryShort.Shared.Models;
using NTrospection.CLI.Attributes;

namespace LongStoryShort.Console.Controllers
{
    [CliController("story", "An example of a CLI Controller")]
    public class StoryController
    {
        private static Story _story { get; set; }
        private IStoryService _storyService { get; set; }

        public StoryController()
        {
            _storyService = new StoryService();
        }
        
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        
        [CliCommand("start", "A Hello World for a CLI Project")]
        public void LoadStory(string file)
        {
            _story = _storyService.LoadStory(file);
            System.Console.WriteLine("story has been loaded");
        }

        [CliCommand("save", "A Hello World for a CLI Project")]
        public void SaveStory()
        {
            _storyService.SaveStory(_story);
        }

        [CliCommand("continue", "A Hello World for a CLI Project")]
        public void ContinueStory(int? option = null)
        {
            if (_story == null)
            {
                System.Console.WriteLine("=== No story has been loaded ===");
            }
            else
            {
                _story = _storyService.ProgressStory(_story, option);
            }            
        }
    }
}
