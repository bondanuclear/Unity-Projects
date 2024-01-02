using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPopUp : BasePopUp, IKey
{
    // define the priority of the pop up
    public int Priority => (int)PrioritiesValues.MediumPriority;

    public string InfoName => "Medium Pop UP";
    
    public void ClosePopUp()
    {
        Debug.Log("Closing medium");
        ProcessAnimationClose();
        // other logic
    }

    public void HidePopUp()
    {
        ProcessAnimationHide();
        // other logic
    }
    
    public void ShowPopUp()
    {
        ProcessAnimationShow();

        // other logic
    }
    public void TriggerPopUp()
    {
        UIController.instance.SetUIControl(this);
    }
}
