using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;
using OpenTK;

namespace Engine1Core
{
    class GameInput
    {

        private static List<Key> keysDown;
        private static List<Key> keysDownlast;

        private static List<MouseButton> buttonsDown;
        private static List<MouseButton> buttonsDownlast;

        public static void Initialize(OpenTK.GameWindow game)
        {
            keysDown = new List<Key>();
            keysDownlast = new List<Key>();
            buttonsDown = new List<MouseButton>();
            buttonsDownlast = new List<MouseButton>();

            game.KeyDown += Game_KeyDown;
            game.KeyUp += Game_KeyUp;
            game.MouseDown += Game_MouseDown;
            game.MouseUp += Game_MouseUp;
        }

        public static void Update()
        {
            keysDownlast = new List<Key>(keysDown);
            buttonsDownlast = new List<MouseButton>(buttonsDown);


        }

        public static bool KeyPress(Key key)
        {
            return (keysDown.Contains(key) && !keysDownlast.Contains(key));
        }

        public static bool KeyRelease(Key key)
        {
            return (!keysDown.Contains(key) && keysDownlast.Contains(key));
        }

        public static bool KeyDown(Key key)
        {
            return keysDown.Contains(key);
        }

        public static bool MousePress(MouseButton button)
        {
            return (buttonsDown.Contains(button) && !buttonsDownlast.Contains(button));
        }

        public static bool MouseRelease(MouseButton button)
        {
            return (!buttonsDown.Contains(button) && buttonsDownlast.Contains(button));
        }

        public static bool MouseDown(MouseButton button)
        {
            return buttonsDown.Contains(button);
        }

        private static void Game_MouseUp(object sender, MouseButtonEventArgs e)
        {
            while (buttonsDown.Contains(e.Button))
                buttonsDown.Remove(e.Button);
        }

        private static void Game_MouseDown(object sender, MouseButtonEventArgs e)
        {
            buttonsDown.Add(e.Button);
        }

        private static void Game_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            while (keysDown.Contains(e.Key))
                keysDown.Remove(e.Key);
        }

        private static void Game_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keysDown.Add(e.Key);
        }
    }
}
