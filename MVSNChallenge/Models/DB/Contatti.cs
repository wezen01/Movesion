using System;
using System.Collections.Generic;

namespace MVSNChallenge.Models.DB;

public partial class Contatti
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public string? Contatto { get; set; }

    public int? Idcompagnia { get; set; }

    public virtual Compagnie? IdcompagniaNavigation { get; set; }
}
