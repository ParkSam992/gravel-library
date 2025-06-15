using System;

namespace Gravel.Utilities.Tests.Models;

public class ClassForTesting
{
    public string StringProperty { get; set; }
    public int IntProperty { get; set; }
    public bool BoolProperty { get; set; }
    public DateTime? DateProperty { get; set; }
    public SubClassForTesting SubClassForTesting { get; set; }
}

public class SubClassForTesting
{
    public string SubStringProperty { get; set; }
    public int SubIntProperty { get; set; }
    public bool SubBoolProperty { get; set; }
}