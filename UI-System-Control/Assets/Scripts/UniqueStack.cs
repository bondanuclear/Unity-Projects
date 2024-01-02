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
            //SortStack(); // Sort the stack after adding a new element
            return true;
        }
        else{
            
            Debug.Log("Pop Up already in the stack with priority " + key.Priority);
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
}
