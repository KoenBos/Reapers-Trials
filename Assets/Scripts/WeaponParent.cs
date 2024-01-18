using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon
{
    public string weaponWeaponName;
    public int weaponDamage;
    public float weaponAttackDelay;
    public float weaponAttackRange;
    public Sprite weaponWeaponSprite;
    public string weaponUseSound;
    public float weaponSwingAnimationSpeed;
}

public class WeaponParent : MonoBehaviour
{
    //for the weapon---------
    private int damage = 0;
    private Slider delaySlider;
    private float attackTimer = 0.0f;
    private float attackRange = 0.0f;
    //-------------------------

    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition;

    public Animator animator;
    public float attackDelay = 0.3f;
    private bool attackBlocked;

    public bool IsAttacking { get; private set; }

    public Transform circleOrigin;
    public float radius;

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        PointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        attackBlocked = false;
        IsAttacking = false;
    }

    //private AudioManager audioManager;
    public Weapon[] weapons;
    public int currentWeapon = 0;
    public GameObject weaponVisual;
    public GameObject UIWeaponImage;
    public TextMeshProUGUI weaponName;
    private void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        //UpdateWeapon();
    }

    // public void UpdateWeapon()
    // {
    //     weaponVisual.GetComponent<SpriteRenderer>().sprite = weapons[currentWeapon].weaponSprite;
    //     UIWeaponImage.GetComponent<Image>().sprite = weapons[currentWeapon].weaponSprite;
        
    //     delaySlider.maxValue = weapons[currentWeapon].weaponAttackDelay;
    //     weaponName.text = weapons[currentWeapon].weaponWeaponName;
    //     damage = weapons[currentWeapon].weaponDamage;
    //     attackDelay = weapons[currentWeapon].weaponAttackDelay;
    //     attackRange = weapons[currentWeapon].weaponAttackRange;
    //     animator.speed = weapons[currentWeapon].weaponSwingAnimationSpeed;
    // }

}