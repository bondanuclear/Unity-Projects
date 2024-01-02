using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePopUp : MonoBehaviour
{
    [SerializeField] protected Button closeButton;
    [SerializeField] protected Button acceptButton;
    protected virtual void ProcessAnimationHide()
    {
        transform.gameObject.SetActive(false);
    }
    protected virtual void ProcessAnimationShow()
    {
        transform.gameObject.SetActive(true);
    }
    protected virtual void ProcessAnimationClose()
    {
        transform.gameObject.SetActive(false);
    }
    //public abstract void ShowPopUp();
    //public abstract void ClosePopUp();
    //public abstract void HidePopUp();

}
