using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;
    [SerializeField] private float teleportCooldown = 1f;
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            if (gameObject == Door1)
            {
                TeleportPlayer(Door2);
            }
            else if (gameObject == Door2)
            {
                TeleportPlayer(Door1);
            }
            StartCoroutine(TeleportCooldown());
        }
    }
    private void TeleportPlayer(GameObject door)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = door.transform.position;
    }
    private IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}
