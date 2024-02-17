using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : PickUp
{
    [SerializeField]
    int ponts = 5;
    public override void Picked()
    {
        GameManager.instance.AddPoints(ponts);
        base.Picked();
    }
}
