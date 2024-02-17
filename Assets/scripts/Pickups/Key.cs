using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    [SerializeField]
    KeyColor keyColor;
    public override void Picked()
    {
        GameManager.instance.AddKey(keyColor);
        base.Picked();
    }
}
