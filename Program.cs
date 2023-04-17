namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evento evento = new Evento();

            Console.WriteLine(evento.ToString());

            evento.PrenotaPosti();

            evento.PrenotatiEDisponibili();

            evento.DisdiciPosti();
        }
    }
}