using System;
using System.Collections.Generic;

namespace nvklesson10.Models;

public partial class Company
{
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public int? CateStatus { get; set; }
}
