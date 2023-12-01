using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Interactable
{
    public int weaponID = 0;
    public GameObject weaponDrop;

    public override void OnStart()
    {
        InfoText =  "Pick up  weapon (E)";
        GetComponent<SpriteRenderer>().sprite = player.GetComponent<WeaponHandler>().weapons[weaponID].weaponSprite;
    }
    public override void UseItem()
    {
            GameObject drop = Instantiate(weaponDrop, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            drop.GetComponent<WeaponPickup>().weaponID = player.GetComponent<WeaponHandler>().currentWeapon;
            drop.GetComponent<SpriteRenderer>().sprite = player.GetComponent<WeaponHandler>().weapons[player.GetComponent<WeaponHandler>().currentWeapon].weaponSprite;

            player.GetComponent<WeaponHandler>().currentWeapon = weaponID;
            player.GetComponent<WeaponHandler>().UpdateWeapon();
            
            Destroy(gameObject);
    }


}
