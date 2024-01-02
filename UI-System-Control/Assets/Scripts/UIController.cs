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
            Debug.Log("Stack was empty.. Adding first UI!");
            return;
        }
        ////
        if(currentUI.Priority > UI.Priority)
        {
            Debug.Log("Current pop up seems to be more important! ");
            if (uniqueStack.PushToStack(UI))
                uniqueStack.SortStack();

        } 
        else if(currentUI.Priority < UI.Priority)
        {
            Debug.Log("New pop up seems to be more important! ");
            
            if (uniqueStack.PushToStack(UI))
            {
                Debug.LogWarning("Current UI is " + currentUI.InfoName + currentUI.Priority);
                currentUI.ClosePopUp();
                currentUI = UI;
                Debug.LogWarning("Changed current UI is " + currentUI.InfoName + currentUI.Priority);
                currentUI.ShowPopUp();
                uniqueStack.SortStack();
            } 
        }
        else 
        {
            Debug.Log("Adding another one with the same priority: ");
            if (uniqueStack.PushToStack(UI))
                uniqueStack.SortStack();
        }

        
        
        
        
    }
   
    public void CloseCurrentAndOpenFollowingUI()
    {
        Debug.Log("Clicked Close Button!");
        uniqueStack.PrintContents();
        currentUI = uniqueStack.PopFromStack();

        Debug.Log("Contents after popping ");
        uniqueStack.PrintContents();
        if (currentUI != null)
        {
            Debug.Log("Close Current and Open Following!" + currentUI.InfoName);
            currentUI.ClosePopUp();
            
            OpenFollowingUI();
        }
            
        uniqueStack.PrintContents();
    }
    public void CloseCurrentUI(Action closeMethod)
    {
        currentUI = uniqueStack.PopFromStack();
        if (currentUI != null)
            closeMethod();
        //     currentUI.ClosePopUp();
    }
    
    public void OpenFollowingUI()
    {
        if(uniqueStack.IsStackEmpty()) return;
        currentUI = uniqueStack.PopFromStack();
        Debug.Log("Popped for showing " + currentUI.InfoName);
        if (currentUI != null)
            currentUI.ShowPopUp();
    }
}
