using NTrospection.CLI.Core;

namespace LongStoryShort.Console
{
   class Program
   {
       static void Main(string[] args)
       {
           new Processor().ProcessArguments(args);
       }
   }
}
