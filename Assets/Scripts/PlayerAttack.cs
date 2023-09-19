using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackCollider;

    private Collider2D attackCollider;

    void Start()
    {
        AttackCollider.SetActive(false);

        attackCollider = AttackCollider.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AttackCollider.transform.localPosition = new Vector3(0, 2.5f, 0);
            AttackCollider.SetActive(true);
            StartCoroutine(DisableCollider());
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AttackCollider.transform.localPosition = new Vector3(0, -2.5f, 0);
            AttackCollider.SetActive(true);
            StartCoroutine(DisableCollider());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AttackCollider.transform.localPosition = new Vector3(-1.5f, 0, 0);
            AttackCollider.SetActive(true);
            StartCoroutine(DisableCollider());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AttackCollider.transform.localPosition = new Vector3(1.5f, 0, 0);
            AttackCollider.SetActive(true);
            StartCoroutine(DisableCollider());
        }
    }

    //disable the attack collider after 0.1 seconds
    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        AttackCollider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthManager enemyHealth = collision.GetComponent<HealthManager>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
    }
}
