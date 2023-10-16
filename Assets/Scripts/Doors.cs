using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject Bindedoor;
    private GameObject fade;
    private Animator fadeAnimator;
    private GameObject player;
    [SerializeField] private bool DoActivate = false;
    [SerializeField] private GameObject[] ToActivate;
    private GameObject Door_Closed;
    private GameObject Door_Opened;
    void Start()
    {
        fade = GameObject.Find("Fade");
        fadeAnimator = fade.GetComponent<Animator>();

        Door_Closed = transform.GetChild(0).gameObject;
        Door_Opened = transform.GetChild(1).gameObject;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bindedoor != null)
        {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            GetComponent<BoxCollider2D>().enabled = false;
            Bindedoor.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(EnableBothDoors());
        }
        }
    }

    IEnumerator EnableBothDoors()
    {
        Door_Closed.SetActive(false);
        Door_Opened.SetActive(true);
        //get players first child, which is the sprite and fade it out by setting alpha slowly to 0 with a lerping function
        SpriteRenderer playerSprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
        while (playerSprite.color.a > 0)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, playerSprite.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        player.transform.position = Bindedoor.transform.position;
        Door_Closed.SetActive(true);
        Door_Opened.SetActive(false);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
        yield return new WaitForSeconds(0.4f);
        fadeAnimator.SetTrigger("FadeOut");
        if (DoActivate)
        {
            foreach (GameObject obj in ToActivate)
            {
                obj.SetActive(true);
            }
            DoActivate = false;
        }
        yield return new WaitForSeconds(3.0f);
        GetComponent<BoxCollider2D>().enabled = true;
        Bindedoor.GetComponent<BoxCollider2D>().enabled = true;
    }
}
