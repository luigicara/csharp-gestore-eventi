﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Il campo \"Titolo\" non può essere vuoto!");
                }
                else
                {
                    _titolo = value;
                }
            }
        }

        public List<Evento> Eventi { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        public List<Evento> CercaPerData(DateOnly data)
        {
            List<Evento> risultati = new List<Evento>();

            foreach (Evento evento in Eventi)
            {
                if (evento.Data == data)
                    risultati.Add(evento);
            }

            return risultati;
        }

        public int ContaEventi()
        {
            return Eventi.Count;
        }

        public string ProgrammaToString()
        {
            string risultato = Titolo + ":";
            risultato += ProgrammaEventi.ListaToString(Eventi);

            return risultato;
        }

        public void SvuotaLista()
        {
            Eventi.Clear();
        }

        public static string ListaToString(List<Evento> eventi)
        {
            string risultato = string.Empty;

            int index = 1;

            foreach (Evento evento in eventi)
            {
                risultato += $"\r\n\t{index}. {evento.Titolo} - {evento.Data}";
                index++;
            }

            return risultato;
        }
    }
}
