namespace Master_Mind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt = Menu.NumberMenu(new string[] { "PLAY", "EXIT" });

            switch (opt)
            {
                case 0:
                    return;
                case 1:
                    Game.Play();
                    break;
            }
        }
    }
}