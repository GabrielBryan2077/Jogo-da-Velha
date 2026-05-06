namespace Jogo_da_Velha
{
    public class Tabuleiro
    {
        private readonly string[] tab = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        public void ExibirTabuleiro()
        {
            Console.SetCursorPosition(11, 04); Console.WriteLine($"x-----------------x");
            Console.SetCursorPosition(11, 05); Console.WriteLine($"|     |     |     |");
            Console.SetCursorPosition(11, 06); Console.WriteLine($"|  {tab[0]}  |  {tab[1]}  |  {tab[2]}  |");
            Console.SetCursorPosition(11, 07); Console.WriteLine($"|_____|_____|_____|");
            Console.SetCursorPosition(11, 08); Console.WriteLine($"|     |     |     |");
            Console.SetCursorPosition(11, 09); Console.WriteLine($"|  {tab[3]}  |  {tab[4]}  |  {tab[5]}  |");
            Console.SetCursorPosition(11, 10); Console.WriteLine($"|_____|_____|_____|");
            Console.SetCursorPosition(11, 11); Console.WriteLine($"|     |     |     |");
            Console.SetCursorPosition(11, 12); Console.WriteLine($"|  {tab[6]}  |  {tab[7]}  |  {tab[8]}  |");
            Console.SetCursorPosition(11, 13); Console.WriteLine($"|     |     |     |");
            Console.SetCursorPosition(11, 14); Console.WriteLine($"x-----------------x");
        }
        public string[] GetTabuleiro()
        {
            return tab;
        }
    }
}