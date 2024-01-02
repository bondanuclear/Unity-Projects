using System;
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
        if(uniqueStack.AlreadyInStack(UI)) 
        {
            Debug.LogError("Already in Stack!");
            return;
        }
        if(uniqueStack.IsStackEmpty())
        {
            if (uniqueStack.PushToStack(UI))
                currentUI = UI;
            currentUI.ShowPopUp();
            return;
        }
        ////
        if(currentUI.Priority > UI.Priority)
        {
            if (uniqueStack.PushToStack(UI))
                uniqueStack.SortStack();

        } 
        else if(currentUI.Priority < UI.Priority)
        {
            if (uniqueStack.PushToStack(UI))
            {
                currentUI.ClosePopUp();
                currentUI = UI;
                currentUI.ShowPopUp();
                //uniqueStack.SortStack();
            } 
        }
        else 
        {
            if (uniqueStack.PushToStack(UI))
                uniqueStack.SortStack();
        }

        
        
        
        
    }
   
    public void CloseCurrentUI()
    {
        currentUI = uniqueStack.PopFromStack(); 
        if (currentUI != null)
        {
            Debug.Log("Close Current and Open Following!" + currentUI.InfoName);
            currentUI.ClosePopUp();   
        }
        OpenFollowingUI();
        uniqueStack.PrintContents();
    }
    
    
    public void OpenFollowingUI()
    {
        if(uniqueStack.IsStackEmpty()) return;
        currentUI = uniqueStack.PeekAtStack();
        if (currentUI != null)
            currentUI.ShowPopUp();
    }
    public void Print()
    {
        Debug.ClearDeveloperConsole();
        uniqueStack.PrintContents();
    }
}
