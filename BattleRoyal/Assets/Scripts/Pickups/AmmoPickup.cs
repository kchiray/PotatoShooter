using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupItem {

    public override void OnPickup(Transform item)
    {
        base.OnPickup(item);
        print("pickup");
    }
}
