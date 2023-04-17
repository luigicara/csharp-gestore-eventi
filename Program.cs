namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgrammaEventi programma = new ProgrammaEventi();

            Console.Write("Indica il numero di eventi da inserire: ");

            int numeroEventi;

            while (!int.TryParse(Console.ReadLine(), out numeroEventi))
                Console.WriteLine("Inserisci un NUMERO!");

            for (int i = 0; i < numeroEventi; i++)
            {   
                try
                {
                    Evento evento = new Evento(i + 1);
                    
                    programma.AggiungiEvento(evento);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Riprova!");
                    i--;
                }
            }

            Console.WriteLine($"Il numero di eventi nel programma è : {programma.ContaEventi()}");

            Console.WriteLine($"Ecco il tuo programma eventi: {programma.ProgrammaToString()}");

            Console.Write("\r\nInserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");

            DateOnly dataDaCercare;

            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out dataDaCercare))
                Console.Write("Inserisci Formato Valido! (gg/mm/yyyy): ");

            Console.WriteLine(ProgrammaEventi.ListaToString(programma.CercaPerData(dataDaCercare)));
        }
    }
}