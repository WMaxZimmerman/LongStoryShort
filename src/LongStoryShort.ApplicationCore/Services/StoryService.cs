using System;
using System.Linq;
using LongStoryShort.DAL.Repositories;
using LongStoryShort.Shared.Models;

namespace LongStoryShort.ApplicationCore.Services
{
    public interface IStoryService
    {
        Story LoadStory(string path);
        Story ProgressStory(Story story, int? option);
        void SaveStory(Story story);
    }
    
    public class StoryService: IStoryService
    {
        private IFileRepository _fileRepo;
        
        public StoryService(IFileRepository fileRepo = null)
        {
            _fileRepo = fileRepo ?? new FileRepository();
        }

        public Story LoadStory(string path)
        {
            var story = _fileRepo.ImportJsonFile<Story>(path);
            return story;
        }

        public Story ProgressStory(Story story, int? option = null)
        {
            if (option != null)
            {
                var nextIndex = story.CurrentNarrative().Decisions[(int)option - 1].NextNarrative;
                story.CurrentNarrativeIndex = nextIndex;
            }            
            
            Console.WriteLine(story.CurrentNarrative().Body);
            var decisions = story.CurrentNarrative().Decisions;
            if (decisions == null || decisions.Count == 0) return null;
            else
            {
                Console.WriteLine("Choose One:");
                var i = 0;
                foreach (var decision in decisions)
                {
                    i++;
                    Console.WriteLine($"- ({i}) {decision.Body}");
                }
            }
            
            return story;
        }

        public void SaveStory(Story story)
        {
            var title = story.Title.Replace(" ", "_");
            var file = $"../../resources/stories/{title}.json";

            _fileRepo.ExportJsonFile(file, story);
        }
    }
}
