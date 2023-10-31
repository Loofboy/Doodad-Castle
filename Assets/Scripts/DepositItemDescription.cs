using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DepositItemDescription
{
    public int index;
    public int stackSize;
    public bool completed;

    public DepositItemDescription(int index, int stackSize, bool completed)
    {
        this.completed = completed;
        this.index = index;
        this.stackSize = stackSize;
    }
}
