using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject Bindedoor;
    private bool Oneway = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bindedoor != null)
        {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = Bindedoor.transform.position;
            Bindedoor.SetActive(false);
            if (Oneway)
            {
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(DisableDoor());
            }
        }
        }
    }

    //disable this door for 3 seconds
    private IEnumerator DisableDoor()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(true);
    }
}
