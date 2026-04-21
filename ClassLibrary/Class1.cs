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
            // foreach (char[] mapRow in Map)
            // {
            //     Console.WriteLine(mapRow);
            // }
            // (int, int) playerMapPosition = MainSave.Player.MapPosition;
            // Console.SetCursorPosition(playerMapPosition.Item2, playerMapPosition.Item1);
            // return false;
            return true;
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
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    return false;
                }
                case ConsoleKey.Enter:
                {
                    return false;
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

        private static bool ProcessMapInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    return false;
                }
                case ConsoleKey.DownArrow:
                {
                    return false;
                }
                case ConsoleKey.LeftArrow:
                {
                    return false;
                }
                case ConsoleKey.RightArrow:
                {
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
            Map,
        }
    }
}
