using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueDataItem
{
    public string _ID;
    public string _Text;
    public float _displayTime;


    public string ID
    {
        get
        {
            return _ID;
        }
        set
        {
            _ID = value;
        }
    }
    public string Text
    {
        get
        {
            return _Text;
        }
        set
        {
            _Text = value;
        }
    }
    public float displayTime
    {
        get
        {
            return _displayTime;
        }
        set
        {
            _displayTime = value;
        }
    }


    public DialogueDataItem(string ID,string Text,float displayTime )
    {
        _ID = ID;
        _Text = Text;
        _displayTime = displayTime;
    }


    public DialogueDataItem()
    {
        this.ID = "null";
    }

    public override bool Equals(object obj)
    {
        return (obj as DialogueDataItem).ID == this.ID;
    }
    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }

}
