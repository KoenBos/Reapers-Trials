                                     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject interactCollider;

    //when player is using wasd or the arrow keys move the attack collider to the correct position
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            interactCollider.transform.localPosition = new Vector3(0, 2.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            interactCollider.transform.localPosition = new Vector3(0, -2.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            interactCollider.transform.localPosition = new Vector3(-1.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            interactCollider.transform.localPosition = new Vector3(1.5f, 0, 0);
        }
    }
}
