using UnityEngine;
using System.Collections;

public class pickupShotgun :pickup {
    protected override void OnPickUp(PowerUpManager pum)
    {
        base.OnPickUp(pum);
        pum.GetShotgun();
    }
}
