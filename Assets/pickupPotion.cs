using UnityEngine;
using System.Collections;

public class pickupPotion : pickup {

    protected override void OnPickUp(PowerUpManager pum)
    {
        base.OnPickUp(pum);
        pum.Resize(-10);
    }
}
