using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSortingAnimation : MonoBehaviour
{
    public Transform parentContainer; // Assign the parent container in the Inspector
    public int sortingLayerOffset = 1; // Offset to control the rendering order change
    public bool moveToTop = false; // Public bool to control sorting order change

    private Transform buttonTransform;
    private int initialSiblingIndex;

    private void Start()
    {
        // Assuming this script is attached to each button individually
        buttonTransform = transform;
        initialSiblingIndex = buttonTransform.GetSiblingIndex();
    }

    void Update()
    {
        if (moveToTop)
        {
            ChangeOrder();
        }
        else
        {
            ChangeOrderBack();
        }
    }

    private void ChangeOrder()
    {
        if (!moveToTop)
        {
            return; // If moveToTop is false, do nothing
        }

        int newSiblingIndex = initialSiblingIndex + sortingLayerOffset;
        newSiblingIndex = Mathf.Clamp(newSiblingIndex, 0, parentContainer.childCount - 1);
        buttonTransform.SetSiblingIndex(newSiblingIndex);
    }

    private void ChangeOrderBack()
    {
        if (moveToTop)
        {
            return; // If moveToTop is true, do nothing
        }

        int newSiblingIndex = initialSiblingIndex - sortingLayerOffset;
        newSiblingIndex = Mathf.Clamp(newSiblingIndex, 0, parentContainer.childCount - 1);
        buttonTransform.SetSiblingIndex(newSiblingIndex);
    }
}
