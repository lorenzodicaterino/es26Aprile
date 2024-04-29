using System;
using System.Collections.Generic;

namespace Esercitazione26Aprile.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string? CodiceUtente { get; set; }

    public string Nominativo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passsword { get; set; } = null!;
}
