using System;
using System.Collections.Generic;

namespace Esercitazione26Aprile.Models;

public partial class Piatto
{
    public int PiattoId { get; set; }

    public string? CodicePiatto { get; set; }

    public string NomePiatto { get; set; } = null!;

    public string DescrizionePiatto { get; set; } = null!;

    public decimal PrezzoPiatto { get; set; }

    public int RistoranteRif { get; set; }

    public virtual Ristorante RistoranteRifNavigation { get; set; } = null!;
}
