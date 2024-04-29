using System;
using System.Collections.Generic;

namespace Esercitazione26Aprile.Models;

public partial class Ristorante
{
    public int RistoranteId { get; set; }

    public string? CodiceRistorante { get; set; }

    public string NomeRistorante { get; set; } = null!;

    public string Tipologia { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public string OrarioApertura { get; set; } = null!;

    public string OrarioChiusura { get; set; } = null!;

    public virtual ICollection<Piatto> Piattos { get; set; } = new List<Piatto>();
}
