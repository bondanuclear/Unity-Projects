using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UniqueStack
{
   private Stack<IKey> popUpStack = new();
   
    public bool PushToStack(IKey key)
    {
        if (!popUpStack.Contains(key))
        {
            popUpStack.Push(key);
            Debug.Log("Pop Up pushed into stack with priority " + key.InfoName + " " + key.Priority);
            // if(popUpStack.Count > 1) 
            // {
            //     SortStack(); // Sort the stack after adding a new element
            //     Debug.Log("sorting...");
            // }
            return true;
        }
        else{
            
            Debug.Log("Pop Up already in the stack with priority " + key.Priority);
        }

        return false;
    }
    public bool AlreadyInStack(IKey key)
    {
        if(popUpStack.Contains(key))
        {
            return true;
        }
        return false;
    }
    public bool IsStackEmpty()
    {
        return popUpStack.Count == 0;
    }
    public IKey PopFromStack()
    {
        if (popUpStack.Count > 0)
        {
            return popUpStack.Pop();
        }
        else
        {
            return null;
        }
    }
    public IKey PeekAtStack()
    {
        if (popUpStack.Count > 0)
        {
            return popUpStack.Peek();
        }
        else
        {
            return null;
        }
    }
    public void SortStack()
    {
        List<IKey> sortedList = popUpStack.ToList();
        sortedList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        popUpStack = new Stack<IKey>(sortedList);
    }
    public void PrintContents()
    {
        foreach(var item in popUpStack)
        {
            Debug.Log(item.InfoName + " " + item.Priority);
        }
    }
}
