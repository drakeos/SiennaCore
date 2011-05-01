﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shared.Database;

[DataTable(DatabaseName = "Characters", TableName = "RaceSexMask_Info", PreCache = true)]
[Serializable]
public class RaceSexMask_Info : DataObject
{
    [DataElement]
    public long Race;

    [DataElement]
    public long Sex;

    [DataElement]
    public long Mask;
}
