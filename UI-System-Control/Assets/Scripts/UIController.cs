using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    UniqueStack uniqueStack;
    IKey currentUI;

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
        if(uniqueStack.PushToStack(UI))
        {
            currentUI = UI;
            Debug.LogWarning($"Managed to push, currentUI is {currentUI.InfoName}");
            uniqueStack.PrintContents();
        }
        
        
        
        Debug.Log(uniqueStack.PeekAtStack().InfoName + " AFTER PEEKING() ");
    }

}
