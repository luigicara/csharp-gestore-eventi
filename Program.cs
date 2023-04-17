namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome dell'evento: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci la data dell'evento: ");
            string data = Console.ReadLine();

            Console.Write("Inserisci il numero di posti totali: ");
            int numeroPosti;

            while (!int.TryParse(Console.ReadLine(), out numeroPosti))
                Console.WriteLine("Inserisci un NUMERO!");

            Evento evento = new Evento(titolo, DateOnly.ParseExact(data, "dd/MM/yyyy"), numeroPosti);

            Console.Write("Quanti posti vuoi prenotare? ");

            int postiDaPrenotare;

            while (!int.TryParse(Console.ReadLine(), out postiDaPrenotare))
                Console.WriteLine("Inserisci un NUMERO!");

            evento.PrenotaPosti(postiDaPrenotare);

            Console.WriteLine($"Numero di posti prenotati: {evento.PostiPrenotati}");

            Console.WriteLine($"Numero di posti disponibili: {evento.NumPosti - evento.PostiPrenotati}");

            string scelta;

            do
            {
                Console.Write("\r\nVuoi disdire dei posti (si/no)? ");

                scelta = Console.ReadLine() ?? string.Empty;

                while ((scelta != "si" && scelta != "no") || string.IsNullOrEmpty(scelta))
                {
                    Console.WriteLine("Inserisci scelta VALIDA!");
                    scelta = Console.ReadLine() ?? string.Empty;
                }

                if (scelta == "si")
                {
                    Console.Write("Inserisci il numero di posti da disdire: ");
                    int numeroPostiDaDisdire;

                    while (!int.TryParse(Console.ReadLine(), out numeroPostiDaDisdire))
                        Console.WriteLine("Inserisci un NUMERO!");

                    evento.DisdiciPosti(numeroPostiDaDisdire);
                } else
                    Console.WriteLine("Ok va bene!");

                Console.WriteLine($"\r\nNumero di posti prenotati: {evento.PostiPrenotati}");

                Console.WriteLine($"Numero di posti disponibili: {evento.NumPosti - evento.PostiPrenotati}");

            } while (scelta == "si");

            
        }
    }
}