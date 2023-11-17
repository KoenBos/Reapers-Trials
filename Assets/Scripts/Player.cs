using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
      public int keys = 0;
      public GameObject KeyPanel;

      public void UpdateKeys()
      {
            if (keys > 0)
            {
                KeyPanel.SetActive(true);
                KeyPanel.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = keys.ToString();
            }
            else
            {
                  KeyPanel.SetActive(false);
            }
      }
}
