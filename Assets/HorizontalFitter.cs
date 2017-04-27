using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalFitter : MonoBehaviour, ICanvasElement
{
    // Use this for initialization
    void Start()
    {
        Refit();
    }

    public void Refit()
    {
        //Never used
        //HorizontalLayoutGroup group = GetComponent<HorizontalLayoutGroup>();

        RectTransform rectT = GetComponent<RectTransform>();

        //Never used
        //RectTransform rectP = rectT.transform.parent.parent.parent.GetComponent<RectTransform>();
        //float width = Mathf.Min((rectP.rect.width - group.padding.horizontal) / transform.childCount - group.spacing, rectT.rect.height - group.padding.vertical);
        float width = rectT.rect.height;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(width, width);
        }
    }

    public void Rebuild(CanvasUpdate executing)
    {
        Refit();
    }

    public void LayoutComplete()
    {
        throw new NotImplementedException();
    }

    public void GraphicUpdateComplete()
    {
        throw new NotImplementedException();
    }

    public bool IsDestroyed()
    {
        throw new NotImplementedException();
    }
}