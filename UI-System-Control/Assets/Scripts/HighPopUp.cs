using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPopUp : BasePopUp, IKey
{
    // define the priority of the pop up
    public int Priority => (int)PrioritiesValues.HighPriority;

    public string InfoName => "High Pop UP";

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
