using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string weaponName;
    public int damage;
    public float attackDelay;
    public float attackRange;
    public Sprite weaponSprite;
    public string useSound;
}
public class WeaponHandler : MonoBehaviour
{
    //private AudioManager audioManager;
    public Weapon[] weapons;
    public int currentWeapon = 0;
    public GameObject weaponVisual;

    PlayerAttack playerAttack;

    private void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        PlayerAttack playerAttack = GetComponent<PlayerAttack>();
        UpdateWeapon();
    }

    //Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateWeapon();
        }
    }

    public void UpdateWeapon()
    {
        weaponVisual.GetComponent<SpriteRenderer>().sprite = weapons[currentWeapon].weaponSprite;
        playerAttack.damage = weapons[currentWeapon].damage;
        playerAttack.attackDelay = weapons[currentWeapon].attackDelay;
        playerAttack.attackRange = weapons[currentWeapon].attackRange;
    }

}
