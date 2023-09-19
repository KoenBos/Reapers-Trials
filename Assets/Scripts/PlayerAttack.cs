using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackCollider;

    void Start()
    {
        AttackCollider.SetActive(false);
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

    //when the attack collider collides with an enemy, get the enemys healthmanager script and deal damage to it, so not the collider on the player but the collider on the attack collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(10);
        }
    }
}
