using System;
using System.Collections.Generic;

namespace MVSNChallenge.Models.DB;

public partial class Compagnie
{
    public int Id { get; set; }

    public string? NomeCompagnia { get; set; }

    public string? DescrizioneCompagnia { get; set; }

    public virtual ICollection<Contatti> Contattis { get; } = new List<Contatti>();

    public virtual ICollection<Indirizzi> Indirizzis { get; } = new List<Indirizzi>();

    public virtual ICollection<Prodotti> Prodottis { get; } = new List<Prodotti>();
}
