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
    public float swingAnimationSpeed;
}
public class WeaponHandler : MonoBehaviour
{
    //private AudioManager audioManager;
    public Weapon[] weapons;
    public int currentWeapon = 0;
    public GameObject weaponVisual;
    public GameObject UIWeaponImage;
    public TMPro.TextMeshProUGUI weaponName;

    //player attack script
    private PlayerAttack playerAttack;
    private void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        //get player attack script
        playerAttack = GetComponent<PlayerAttack>();
        UpdateWeapon();
    }
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
        UIWeaponImage.GetComponent<UnityEngine.UI.Image>().sprite = weapons[currentWeapon].weaponSprite;
        
        playerAttack.delaySlider.maxValue = weapons[currentWeapon].attackDelay;

        weaponName.text = weapons[currentWeapon].weaponName;
        playerAttack.damage = weapons[currentWeapon].damage;
        playerAttack.attackDelay = weapons[currentWeapon].attackDelay;
        playerAttack.attackRange = weapons[currentWeapon].attackRange;
        playerAttack.animator.speed = weapons[currentWeapon].swingAnimationSpeed;
    }

}
