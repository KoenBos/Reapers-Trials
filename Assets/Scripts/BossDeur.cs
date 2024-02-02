using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeur : Interactable
{
    public override void UseItem()
    {
        LevelManager.Instance.LoadScene("BossScene2");
    }
}
