using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : PickUp
{
    [SerializeField]
    bool isAddingTime;
    [SerializeField]
    int time =5;
    public override void Picked()
    {
        int sign;
        if (isAddingTime) sign = 1;
        else sign = -1;
        GameManager.instance.AddTime(time * sign);
        base.Picked();
    }
}
