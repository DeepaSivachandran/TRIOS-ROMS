
using System.Collections.Generic;

public class PurchaseRecoverySnapshot
{
    public Dictionary<string, string> Fields { get; set; }
        = new Dictionary<string, string>();

    public Dictionary<string, PurchaseGridSnapshot> GridSnapshots
    { get; set; }
        = new Dictionary<string, PurchaseGridSnapshot>();
    public Dictionary<string, string> Variables { get; set; }
    = new Dictionary<string, string>();
}

public class PurchaseGridSnapshot
{
    public List<string> ColumnNames { get; set; }
        = new List<string>();

    public List<List<string>> Rows { get; set; }
        = new List<List<string>>();
}
