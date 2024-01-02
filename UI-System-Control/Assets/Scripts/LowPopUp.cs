using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPopUp : BasePopUp, IKey
{
    // define the priority of the pop up
    public int Priority => (int)PrioritiesValues.LowPriority;

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
}
