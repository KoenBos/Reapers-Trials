using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public GameObject player;
    private InfoTextManager infoTextManager;
    public string InfoText = "Use (E)";   

    public void Start()
    {
        infoTextManager = GameObject.Find("InfoTextManager").GetComponent<InfoTextManager>();
        player = GameObject.Find("Player");
        OnStart();
    }
    //if player presses e and is nearby the weapon pickup, pick up the weapon
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby)
        {
            UseItem();
        }
    }
    public virtual void  UseItem()
    {
        // Do nothing by default.
        // Child classes can override this method to provide specific behavior.
    }
    public virtual void  OnStart()
    {
        // Do nothing by default.
        // Child classes can override this method to provide specific behavior.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            infoTextManager.ShowInfo(InfoText);
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
