using System.Text.Json;
using SaveLogic;

namespace ClassLibrary
{
    public class Class1 { }

    public static class Astrid
    {
        public static Save MainSave;
        public static char[][] Map;

        public static void RenderMainMenu()
        {
            string menu = File.ReadAllText("./ClassLibrary/AstridClasses/Menus/MainMenu.txt");
            Console.WriteLine(menu);
            Console.CursorTop = 2;
            Console.CursorLeft = 14;
            bool exited = false;
            while (!exited)
            {
                exited = ProcessInput(InputType.MainMenu, Console.ReadKey(true));
            }
        }

        public static void RenderMap()
        {
            Console.Clear();
            bool exited = false;
            var mapLines = File.ReadAllLines("./ClassLibrary/AstridClasses/Maps/StartMap.txt");
            Map = new char[mapLines.Length][];
            for (int i = 0; i < mapLines.Length; i++)
            {
                Map[i] = mapLines[i].ToCharArray();
            }
            // Editing the map to change for secrets goes here.
            foreach (char[] mapRow in Map)
            {
                Console.WriteLine(mapRow);
            }
            (int, int) playerMapPosition = MainSave.Player.MapPosition;
            Console.SetCursorPosition(playerMapPosition.Item2, playerMapPosition.Item1);
            while (!exited)
            {
                exited = ProcessInput(InputType.Map, Console.ReadKey(true));
            }
        }

        public static bool RenderSaveMenu()
        {
            Console.Clear();
            string saveMenu = File.ReadAllText("./ClassLibrary/AstridClasses/Menus/SaveMenu.txt");
            Console.WriteLine(saveMenu);
            Console.SetCursorPosition(9, 2);
            bool exited = false;
            while (!exited)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                exited = ProcessInput(InputType.SaveMenu, inputKey);
            }
            bool ExitGame;
            switch (Console.CursorTop)
            {
                case 1:
                {
                    ExitGame = false;
                    break;
                }
                case 2:
                {
                    ExitGame = false;
                    break;
                }
                case 3:
                {
                    ExitGame = true;
                    break;
                }
                case 4:
                {
                    ExitGame = true;
                    break;
                }
                default:
                {
                    ExitGame = false;
                    break;
                }
            }
            Console.Clear();
            if (!ExitGame)
            {
                foreach (char[] mapRow in Map)
                {
                    Console.WriteLine(mapRow);
                }
                (int, int) playerMapPosition = MainSave.Player.MapPosition;
                Console.SetCursorPosition(playerMapPosition.Item2, playerMapPosition.Item1);
            }
            return ExitGame;
        }

        public static void RenderSaveSlotMenu()
        {
            int savedChoice = Console.CursorTop;
            Console.Clear();
            string saveSlotsMenu = File.ReadAllText(
                "./ClassLibrary/AstridClasses/Menus/SaveSlots.txt"
            );
            Console.WriteLine(saveSlotsMenu);
            Save tempSave;
            int currentLine = 1;
            foreach (var saveFile in Directory.GetFiles("./ClassLibrary/AstridClasses/SaveFiles"))
            {
                Console.SetCursorPosition(8, currentLine);
                string rawData = File.ReadAllText(saveFile);
                tempSave = JsonSerializer.Deserialize<Save>(rawData);
                Console.Write(tempSave.Player.Name);
                currentLine++;
            }
            Console.SetCursorPosition(8, 1);
            bool exited = false;
            while (!exited)
            {
                exited = ProcessInput(InputType.SaveSlotsMenu, Console.ReadKey(true));
            }
            Console.CursorTop = savedChoice;
        }

        public static bool ProcessInput(InputType type, ConsoleKeyInfo input)
        {
            // if arrow key, then handle movement. else if enter trigger that function. else do nothing. (I may need this to return something, or not)
            switch (type)
            {
                case InputType.MainMenu:
                {
                    return ProcessMainMenuInput(input);
                }
                case InputType.SaveMenu:
                {
                    return ProcessSaveMenuInput(input);
                }
                case InputType.SaveSlotsMenu:
                {
                    return ProcessSaveSlotsMenuInput(input);
                }
                case InputType.Map:
                {
                    return ProcessMapInput(input);
                }
                default:
                {
                    return false;
                }
            }
        }

        private static bool ProcessMainMenuInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    switch (Console.CursorTop)
                    {
                        case 2:
                        {
                            Console.CursorTop = 4;
                            break;
                        }
                        default:
                        {
                            Console.CursorTop--;
                            break;
                        }
                    }
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    switch (Console.CursorTop)
                    {
                        case 4:
                        {
                            Console.CursorTop = 2;
                            break;
                        }
                        default:
                        {
                            Console.CursorTop++;
                            break;
                        }
                    }
                    return false;
                }
                case ConsoleKey.Enter:
                {
                    switch (Console.CursorTop)
                    {
                        case 2: // New Game
                        {
                            MainSave = new Save(new Player("Astrid", Gender.Female));
                            RenderMap();
                            break;
                        }
                        case 3: // Continue
                        {
                            // MainSave.LoadProgress(1);
                            break;
                        }
                        case 4: // Exit
                        {
                            break;
                        }
                        default: // Idk
                        {
                            Console.Clear();
                            Console.WriteLine("How and what did you do?");
                            Console.ReadLine();
                            break;
                        }
                    }
                    return true;
                }
                case ConsoleKey.Escape:
                {
                    return true;
                }
                default:
                {
                    return false;
                }
            }
        }

        private static bool ProcessSaveMenuInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    switch (Console.CursorTop)
                    {
                        case 1:
                        {
                            Console.CursorTop = 4;
                            break;
                        }
                        default:
                        {
                            Console.CursorTop--;
                            break;
                        }
                    }
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    switch (Console.CursorTop)
                    {
                        case 4:
                        {
                            Console.CursorTop = 1;
                            break;
                        }
                        default:
                        {
                            Console.CursorTop++;
                            break;
                        }
                    }
                    return false;
                }
                case ConsoleKey.Enter:
                {
                    switch (Console.CursorTop)
                    {
                        case 1:
                        {
                            return true;
                        }
                        case 2:
                        {
                            RenderSaveSlotMenu();
                            return true;
                        }
                        case 3:
                        {
                            RenderSaveSlotMenu();
                            return true;
                        }
                        case 4:
                        {
                            return true;
                        }
                        default:
                        {
                            return false;
                        }
                    }
                }
                case ConsoleKey.Escape:
                {
                    Console.CursorTop = 1;
                    return true;
                }
                default:
                {
                    return false;
                }
            }
        }

        private static bool ProcessSaveSlotsMenuInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    if (Console.CursorTop == 1)
                    {
                        Console.CursorTop = 9;
                    }
                    else
                    {
                        Console.CursorTop--;
                    }
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    if (Console.CursorTop == 9)
                    {
                        Console.CursorTop = 1;
                    }
                    else
                    {
                        Console.CursorTop++;
                    }
                    return false;
                }
                case ConsoleKey.Enter:
                {
                    (int, int) savedCurrentPosition = (Console.CursorTop, Console.CursorLeft);
                    if (
                        File.Exists(
                            $"./ClassLibrary/AstridClasses/SaveFiles/file{Console.CursorTop}.json"
                        )
                    )
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write(
                            "This file already exists. \nWould you like to overwrite it? [y/n] "
                        );
                        ConsoleKeyInfo decision = Console.ReadKey(false);
                        if (decision.Key == ConsoleKey.Y)
                        {
                            Console.Write(
                                "\nYou chose to overwrite it. \nPress any key to continue"
                            );
                            Console.ReadKey(true);
                            MainSave.SaveProgress(savedCurrentPosition.Item1);
                            return true;
                        }
                        else if (decision.Key == ConsoleKey.N)
                        {
                            Console.Write(
                                "\nYou chose not to. We'll let you pick a different slot.\nPress any key to continue"
                            );
                            Console.ReadKey(true);
                            Console.SetCursorPosition(0, 12);
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine(
                                    "                                                                             "
                                );
                            }
                            Console.SetCursorPosition(
                                savedCurrentPosition.Item2,
                                savedCurrentPosition.Item1
                            );
                            return false;
                        }
                        else
                        {
                            Console.Write(
                                "\nWe're not really sure what you chose.\nWe'll just let you pick a different slot.\nPress any key to continue"
                            );
                            Console.ReadKey(true);
                            Console.SetCursorPosition(0, 12);
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine(
                                    "                                                                             "
                                );
                            }
                            Console.SetCursorPosition(
                                savedCurrentPosition.Item2,
                                savedCurrentPosition.Item1
                            );
                            return false;
                        }
                    }
                    else
                    {
                        MainSave.SaveProgress(Console.CursorTop);
                        return true;
                    }
                }
                // case ConsoleKey.Escape:
                // {
                //     return true;
                // }
                default:
                {
                    return false;
                }
            }
        }

        private static bool ProcessMapInput(ConsoleKeyInfo input)
        {
            int mapRow = Console.CursorTop;
            int mapColumn = Console.CursorLeft;
            char currentMapSpot = Map[mapRow][mapColumn];
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    if (mapRow <= 0) { }
                    // else if (Movable) {then move}
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    if (mapRow >= Map.Length) { }
                    // else if (Movable) {then move}
                    return false;
                }
                case ConsoleKey.LeftArrow:
                {
                    if (mapColumn <= 0) { }
                    // else if (Movable) {then move}
                    return false;
                }
                case ConsoleKey.RightArrow:
                {
                    if (mapColumn <= Map[mapRow].Length) { }
                    // else if (Movable) {then move}
                    // maybe return Movable();
                    return false;
                }
                case ConsoleKey.Enter:
                {
                    return false;
                }
                case ConsoleKey.Escape:
                {
                    return RenderSaveMenu();
                }
                default:
                {
                    return false;
                }
            }
        }

        // Map key behaviours:
        // Movable characters: . , ☐   = | ‒
        // . Nothing. This is the default movement spot
        // , Nothing for now. This signifies a spot that can be dug when pressing enter.
        // ☐ Nothing. This is just the starting spot.
        //   You die. The space character signifies a hole/empty space. You can walk into it, doing so will cause you to fall and die.
        // = Nothing. This signifies the part of a bridge that you can walk on. It does nothing else for now.
        // | ‒ Signals a scene transition, allowing you to traverse to the next area over, depending on where it is located.
        // Immovable characters: █ # \ / _ ‾
        // █ An unbreakable wall. Cannot be passed through or over.
        // # A breakable wall. It is possible to remove this and replace it with . | or ‒ to signal traversing to the next area.
        // \ / _ ‾ These are pieces of bridge, the parts you can not traverse on top of. These are the supports at the side you hold on to when crossing the bridge.

        public enum InputType
        {
            MainMenu,
            SaveMenu,
            SaveSlotsMenu,
            Map,
        }
    }
}
