using UnityEngine;
using System.Collections;

public class pickupBat : pickup {

    protected override void OnPickUp(PowerUpManager pum)
    {
        base.OnPickUp(pum);
        pum.GetBaseball();
    }

}
