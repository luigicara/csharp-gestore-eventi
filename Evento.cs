using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        private string _titolo;
        public string Titolo 
        { 
            get
            {
                return _titolo;
            } 
            set
            {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Il campo \"Titolo\" non può essere vuoto!");
                } else
                {
                    _titolo = value;
                }
            }
        }

        private DateOnly _data;
        public DateOnly Data 
        { 
            get 
            { 
                return _data;
            } 
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now)) { 
                    throw new ArgumentOutOfRangeException("La data di un evento non può essere antecedente ad oggi!");
                } else
                {
                    _data = value;
                }
            }
        }
        private int _numPosti;
        public int NumPosti 
        { 
            get
            {
                return _numPosti;
            } 
            private set
            {
                if (value < 0 == true) {
                    throw new ArgumentOutOfRangeException("Il numero di posti non può essere inferiore a zero!"); 
                } else
                {
                    _numPosti = value;
                }
            } 
        }
        public int PostiPrenotati { get; private set; }

        public Evento(string titolo, DateOnly data, int numPosti)
        {
            Titolo = titolo;
            Data = data;
            NumPosti = numPosti;
            PostiPrenotati = 0;
        }

        public void PrenotaPosti (int postiDaPrenotare)
        {
            if (Data < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentOutOfRangeException("L'evento si è gia svolto, impossibile prenotare nuovi posti");
            }

            if (PostiPrenotati + postiDaPrenotare > NumPosti)
            {
                throw new ArgumentOutOfRangeException($"L'evento non ha abbastanza posti disponibili, sono ancora disponibili {NumPosti - PostiPrenotati} posti");
            }

            PostiPrenotati += postiDaPrenotare;
        }

        public void DisdiciPosti(int postiDaRimuovere)
        {
            if (Data < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentOutOfRangeException("L'evento si è gia svolto, impossibile rimuovere posti");
            }

            if (postiDaRimuovere > PostiPrenotati)
            {
                throw new ArgumentOutOfRangeException($"Impossibile rimuovere più posti di quanti prenotati, sono stati prenotati {PostiPrenotati} posti");
            }

            PostiPrenotati -= postiDaRimuovere;
        }

        public override string ToString()
        {
            return Data.ToString() + " - " + Titolo;
        }
    }
}
