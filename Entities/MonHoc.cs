using System;
using System.Collections.Generic;

namespace webapi.Entities;

public partial class MonHoc
{
    public int MaMh { get; set; }

    public string? TenMh { get; set; }

    public virtual ICollection<BangDiem> BangDiems { get; } = new List<BangDiem>();
}
