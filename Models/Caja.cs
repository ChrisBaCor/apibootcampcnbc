using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Caja
{
    public int CajaId { get; set; }

    public string? CajaDescripcion { get; set; }

    public string? Estado { get; set; }
}
