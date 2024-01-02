using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPopUp : BasePopUp, IKey
{
    // define the priority of the pop up
    public int Priority => (int)PrioritiesValues.MediumPriority;

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
