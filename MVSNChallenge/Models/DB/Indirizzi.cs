using System;
using System.Collections.Generic;

namespace MVSNChallenge.Models.DB;

public partial class Indirizzi
{
    public int Id { get; set; }

    public string? Indirizzo { get; set; }

    public string? Citta { get; set; }

    public string? InfoAggiuntive { get; set; }

    public int Idcompagnia { get; set; }

    public virtual Compagnie? IdcompagniaNavigation { get; set; }
}
