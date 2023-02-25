using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    internal class Game
    {
        private static int money = 0;
        private static FishingRod fishingrod = new FishingRod("Bamboo stick", 0, 0);
        private static List<Fish> container = new List<Fish>();

        private static void Main(string[] args)
        {
            List<Lake> lakeList = new List<Lake>()
      {
        new Lake("Lake Tahoe", new List<Fish>()
        {
          (Fish) new Catfish(35),
          (Fish) new Albacore(20),
          (Fish) new Bluefin(5)
        }),
        new Lake("Big Bear lake", new List<Fish>()
        {
          (Fish) new Catfish(30),
          (Fish) new Albacore(35),
          (Fish) new Yellowtail(15)
        })
      };
            List<FishingRod> all_rods = new List<FishingRod>()
      {
        new FishingRod("Swift Model E", 50, 2),
        new FishingRod("Perry Water Eye Gouger", 200, 6),
        new FishingRod("The Senator", 400, 10),
        new FishingRod("Ocean Depleter", 1000, 20)
      };
            Console.WriteLine("Welcome to deep sea fishing!");
            Console.WriteLine("---------");
            while (true)
            {
                Console.WriteLine("1. Go fishing");
                Console.WriteLine("2. Bass pro shop");
                Console.WriteLine("3. Sell fish");
                Console.WriteLine("What would you like to do?");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n\nWhich lake would you like to go to?");
                        for (int index = 0; index < lakeList.Count; ++index)
                            Console.WriteLine(string.Format("{0}. {1}", (object)(index + 1), (object)lakeList[index].Name));
                        string s = Console.ReadLine();
                        Game.go_fishing(lakeList[int.Parse(s) - 1]);
                        break;
                    case "2":
                        Game.bassproshop(all_rods);
                        break;
                    case "3":
                        Game.sellfish();
                        break;
                }
            }
        }

        private static void sellfish()
        {
            if (Game.container.Count == 0)
            {
                Console.WriteLine("\n\nYou have no fish. Come back when you have something to sell.");
            }
            else
            {
                int num = 0;
                foreach (Fish fish in Game.container)
                    num += fish.MarketPrice;
                Console.WriteLine(string.Format("You made ${0} from your fish.", (object)num));
                Game.money += num;
                Game.container = new List<Fish>();
            }
        }

        private static void bassproshop(List<FishingRod> all_rods)
        {
            int num;
            while (true)
            {
                Console.WriteLine("\n\nWelcome to the Bass Pro shop!");
                Console.WriteLine(string.Format("You have ${0}.", (object)Game.money));
                for (int index = 0; index < all_rods.Count; ++index)
                    Console.WriteLine(string.Format("{0}. {1} for ${2}", (object)(index + 1), (object)all_rods[index].Name, (object)all_rods[index].Price));
                Console.WriteLine(string.Format("{0}. Return to main menu", (object)(all_rods.Count + 1)));
                Console.WriteLine("What fishing rod would you like to buy?");
                num = int.Parse(Console.ReadLine());
                if (num != all_rods.Count + 1)
                {
                    if (Game.money < all_rods[num - 1].Price)
                        Console.WriteLine(string.Format("Sorry, {0} is out of your price range. Try another rod.", (object)all_rods[num - 1].Name));
                    else
                        goto label_5;
                }
                else
                    break;
            }
            return;
        label_5:
            Game.money -= all_rods[num - 1].Price;
            Console.WriteLine(string.Format("Congratulations, you are the new owner of {0}", (object)all_rods[num - 1].Name));
            Game.fishingrod = all_rods[num - 1];
        }

        private static void go_fishing(Lake lake)
        {
            Console.WriteLine(string.Format("\n\nWelcome to {0}", (object)lake.Name));
            List<Fish> availableFishes = lake.AvailableFishes;
            int num = 4;
            Random random = new Random();
            Console.WriteLine(string.Format("Our container holds {0} fish. Keep the ones you love.", (object)num));
            Console.WriteLine("Let's fish!");
            while (Game.container.Count < num)
            {
                int index = random.Next(availableFishes.Count);
                int chance = random.Next(100);
                if (availableFishes[index].BitesBait(Game.fishingrod, chance))
                {
                    Console.WriteLine("\nA fish bit your bait! What do you want to do?");
                    Console.WriteLine("1. Reel in fish");
                    Console.WriteLine("2. Use net\n");
                    string input = Console.ReadLine();
                    if (availableFishes[index].IsCaught(input))
                    {
                        Console.WriteLine("\nGot it! Let's see what we caught.");
                        availableFishes[index].PrintDetails();
                        Console.WriteLine("");
                        Game.container.Add(availableFishes[index]);
                    }
                    else
                        Console.WriteLine("Oh no! The fish got away. Keep trying!\n\n");
                }
                else
                {
                    Console.WriteLine("One minute went by...");
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine("We're full! Let's look at what we caught.");
            foreach (Fish fish in Game.container)
                fish.PrintDetails();
            Console.WriteLine("\n\n\n");
        }
    }
}
