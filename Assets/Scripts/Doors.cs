using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Doors : Interactable
{
    [SerializeField] private GameObject Bindedoor;
    private GameObject fade;
    private Animator fadeAnimator;
    [SerializeField] private bool DoActivate = false;
    [SerializeField] private bool Locked = false;
    [SerializeField] private GameObject[] ToActivate;
    private GameObject Door_Closed;
    private GameObject Door_Opened;
    private GameObject lock_Sprite;
    private GameObject Light;
    private GameObject SpotLight;
    public override void OnStart()
    {
        fade = GameObject.Find("Fade");
        fadeAnimator = fade.GetComponent<Animator>();

        Door_Closed = transform.GetChild(0).gameObject;
        Door_Opened = transform.GetChild(1).gameObject;
        lock_Sprite = transform.GetChild(2).gameObject;
        lock_Sprite = transform.GetChild(2).gameObject;
        Light = transform.GetChild(3).gameObject;
        SpotLight = transform.GetChild(4).gameObject;


        if (Locked)
        {
            lock_Sprite.SetActive(true);
            InfoText = "Unlock with Key (E)";
            Light.GetComponent<Light2D>().intensity = 0.1f;
        }
        else
        {
            lock_Sprite.SetActive(false);
            InfoText = "Open Door (E)";
        }
    }
    
    public override void UseItem()
    {
        if (Locked)
        {
            if (player.GetComponent<Player>().keys > 0)
            {
                player.GetComponent<Player>().keys--;
                player.GetComponent<Player>().UpdateKeys();
                Locked = false;
                lock_Sprite.SetActive(false);
                Light.GetComponent<Light2D>().intensity = 0.3f;
                InfoText = "Open Door (E)";
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                return;
            }
        }
        else
        {
        if (Bindedoor != null)
        {
            StartCoroutine(EnableBothDoors());
        }
        }
    }
    IEnumerator EnableBothDoors()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Bindedoor.GetComponent<BoxCollider2D>().enabled = false;
        Door_Closed.SetActive(false);
        Door_Opened.SetActive(true);
        SpotLight.SetActive(true);
        float tempSpeed = player.GetComponent<PlayerMovement>().playerSpeed;
        player.GetComponent<PlayerMovement>().playerSpeed = 0;
        SpriteRenderer playerSprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
        while (playerSprite.color.a > 0)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, playerSprite.color.a - (Time.deltaTime * 3.0f));
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.3f);
        player.transform.position = Bindedoor.transform.position;
        Door_Closed.SetActive(true);
        Door_Opened.SetActive(false);
        SpotLight.SetActive(false);
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1);
        yield return new WaitForSeconds(0.5f);
        fadeAnimator.SetTrigger("FadeOut");
        player.GetComponent<PlayerMovement>().playerSpeed = tempSpeed;
        if (DoActivate)
        {
            foreach (GameObject obj in ToActivate)
            {
                obj.SetActive(true);
            }
            DoActivate = false;
        }
        yield return new WaitForSeconds(1.0f);
        GetComponent<BoxCollider2D>().enabled = true;
        Bindedoor.GetComponent<BoxCollider2D>().enabled = true;
    }
}
