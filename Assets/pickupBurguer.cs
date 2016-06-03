using UnityEngine;
using System.Collections;

public class pickupBurguer : pickup {

    protected override void OnPickUp(PowerUpManager pum)
    {
        base.OnPickUp(pum);
        pum.Resize(1);
    }
}
