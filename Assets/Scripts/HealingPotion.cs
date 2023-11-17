using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : Interactable
{
    public override void OnStart()
    {
        InfoText =  "Use Potion (E)";
    }
    public override void UseItem()
    {
            player.GetComponent<PlayerHealth>().Heal(40);
            Destroy(gameObject);
    }
}

