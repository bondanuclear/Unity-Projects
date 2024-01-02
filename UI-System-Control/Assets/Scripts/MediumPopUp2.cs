using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPopUp2 : BasePopUp, IKey
{
    // define the priority of the pop up
    public int Priority => (int)PrioritiesValues.MediumPriority;

    public string InfoName => "Medium Pop UP 2";

    public void ClosePopUp()
    {

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
