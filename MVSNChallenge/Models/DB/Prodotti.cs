using System;
using System.Collections.Generic;

namespace MVSNChallenge.Models.DB;

public partial class Prodotti
{
    public int Id { get; set; }

    public string? NomeProdotto { get; set; }

    public string? CategoriaMerceologica { get; set; }

    public int? Quantita { get; set; }

    public int Idcompagnia { get; set; }

    public virtual Compagnie? IdcompagniaNavigation { get; set; }
}
