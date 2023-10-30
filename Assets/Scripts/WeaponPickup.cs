using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public int weaponID = 0;
    private bool isPlayerNearby = false;
    private InfoTextManager infoTextManager;
    private GameObject player;
    public GameObject weaponDrop;

    private void Start()
    {
    infoTextManager = GameObject.Find("InfoTextManager").GetComponent<InfoTextManager>();

    player = GameObject.Find("Player");

    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = player.GetComponent<WeaponHandler>().weapons[weaponID].weaponSprite;
    }

    //if player presses e and is nearby the weapon pickup, pick up the weapon
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby)
        {
            //initiate weapon drop with the weapon that the player is currently holding
            GameObject drop = Instantiate(weaponDrop, transform.position, Quaternion.identity);
            drop.GetComponent<WeaponPickup>().weaponID = player.GetComponent<WeaponHandler>().currentWeapon;
            
            player.GetComponent<WeaponHandler>().currentWeapon = weaponID;
            player.GetComponent<WeaponHandler>().UpdateWeapon();
            

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            infoTextManager.ShowInfo("Pickup Weapon?");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            infoTextManager.HideInfo();
        }
    }
}
