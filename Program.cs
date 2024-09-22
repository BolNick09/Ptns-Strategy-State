using System.Threading;



namespace Ptns_Strategy_State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Oven oven = new();
            //oven.interact();


            IGenerateMap mountainMap = new GenerateMountainMap(new Map());
            Console.WriteLine("----------------------");
            IGenerateMap oseanMap = new GenerateOseanMap (new Map());
            Console.WriteLine("----------------------");
            IGenerateMap riverMap = new GenerateRiverMap (new Map());

        }

        

    }
}
