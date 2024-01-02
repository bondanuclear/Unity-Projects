using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    UniqueStack uniqueStack;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        uniqueStack = new UniqueStack();
    }

    public void SetUIControl(IKey UI)
    {
        uniqueStack.PushToStack(UI);
    }

}
