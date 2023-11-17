using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public override void OnStart()
    {
        InfoText =  "Pickup Key (E)";
    }
    public override void UseItem()
    {
            player.GetComponent<Player>().keys++;
            player.GetComponent<Player>().UpdateKeys();
            Destroy(gameObject);
    }
}
