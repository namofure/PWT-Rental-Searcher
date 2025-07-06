using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Rental_RNG;
using static Rental_RNG.RentalList;

internal class RentalSearcher
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("\n======================================");
            Console.Write("PWT Tournament Searcher\n");
            Console.Write("Initial SEED : 0x");   // 初期SEED入力

            if (ulong.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber, null, out ulong Seed))
            {
                string outputPath = $"RentalPokemon.txt";
                List<RentalList> RpokemonList = PokemonData.GetPokemonRentalList();
                using (StreamWriter writer = new(outputPath))
                {
                    writer.WriteLine("【RentalPokemon List】");
                    writer.WriteLine($"Initial Seed：0x{Seed:X16}");
                    writer.WriteLine("");

                    Console.Write("1：");
                    string target1 = Console.ReadLine();
                    Console.Write("2：");
                    string target2 = Console.ReadLine();
                    Console.WriteLine("");

                    for (int Count = 0; Count < 100; Count++, Seed = NextSeed(Seed))
                    {
                        ulong temp = NextSeed(Seed);

                        writer.WriteLine($"Seed：0x{temp:X16}");

                        List<RentalList> SelectedList = new();
                        HashSet<string> SelectedPokemon = new();
                        HashSet<string> SelectedItem = new();

                        for (int i = 0; i < 6; i++, temp = NextSeed(temp))
                        {
                            ulong ExCount = 0;

                            for (int n = 0; n < 350; n++)
                            {
                                var Entry = RpokemonList[n];

                                if (SelectedPokemon.Contains(Entry.PokemonName) || SelectedItem.Contains(Entry.ItemName))
                                {
                                    ExCount++;
                                }
                            }

                            ulong temp1 = temp >> 48;
                            ulong temp2 = temp1 + ((temp >> 32) - (temp1 << 16));
                            ulong temp3 = temp >> 48;
                            if (temp2 > 0xFFFF) temp3++;

                            var RentalIndex = 0;
                            ulong RawIndex = temp3 % (350 - ExCount);

                            while (RawIndex > 0)
                            {
                                var Entry = RpokemonList[RentalIndex];
                                RentalIndex++;

                                if (SelectedPokemon.Contains(Entry.PokemonName) || SelectedItem.Contains(Entry.ItemName))
                                {
                                    continue;
                                }

                                RawIndex--;
                            }

                            if (RawIndex == 0)
                            {
                                var Entry = RpokemonList[RentalIndex];

                                if (SelectedPokemon.Contains(Entry.PokemonName) || SelectedItem.Contains(Entry.ItemName))
                                {
                                    RentalIndex++;
                                }
                            }

                            RentalList SelectedIndex = RpokemonList[RentalIndex];

                            writer.WriteLine($"{i + 1}: {SelectedIndex.PokemonName}@{SelectedIndex.ItemName}");

                            SelectedList.Add(SelectedIndex);
                            SelectedPokemon.Add(SelectedIndex.PokemonName);
                            SelectedItem.Add(SelectedIndex.ItemName);
                        }

                        writer.WriteLine("");

                        if (SelectedList[0].PokemonName == target1 && SelectedList[1].PokemonName == target2)
                        {
                            for (int n = 0; n < 6; n++)
                            {
                                Console.WriteLine($"{n + 1}：{SelectedList[n].PokemonName}@{SelectedList[n].ItemName}");
                            }

                            ulong TempSeed = Seed;
                            for (int n = 0; n < 24; n++)
                            {
                                TempSeed = NextSeed(TempSeed);
                            }

                            Console.WriteLine($"\nSeed：0x{Seed:X16}");
                            Console.WriteLine($"Current Seed：0x{TempSeed:X16}");
                        }
                    }
                    Console.WriteLine("======================================");
                }
            }

        } while (Console.ReadKey().Key == ConsoleKey.R);
    }

    static ulong NextSeed(ulong PWTSeed)
    {
        ulong a = 0x5D588B656C078965;
        ulong b = 0x269EC3;
        ulong result = (a * PWTSeed + b) & 0xFFFFFFFFFFFFFFFF;
        return result;
    }
}



