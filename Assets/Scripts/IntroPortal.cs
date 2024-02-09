using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPortal : Interactable
{
    public override void UseItem()
    {
        LevelManager.Instance.LoadSceneNoLoadScreen("DungeonSelectScene");
    }
}
