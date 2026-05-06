namespace Jogo_da_Velha
{
    public class MenuInicial
    {
        public static void ExibirMenu()
        {
            Console.Title = "Jogo_da_Velha.exe";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(13, 9); Console.WriteLine("JOGO DA VELHA");
            Console.SetCursorPosition(1, 18); Console.WriteLine("Pressione qualquer tecla para iniciar!");

            Console.ReadKey(true);
            Console.Clear();
        }
    }
}