using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePopUp : MonoBehaviour
{
    [SerializeField] protected Button closeButton;
    [SerializeField] protected Button acceptButton;
    protected  void Start() {
        closeButton.onClick.AddListener(CloseWithUIController);
        acceptButton.onClick.AddListener(CloseWithUIController);
        
    }
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
    public void CloseWithUIController()
    {
        Debug.Log("Calling from " + transform.name);
        UIController.instance.CloseCurrentUI();
    }
    
    //public abstract void ShowPopUp();
    //public abstract void ClosePopUp();
    //public abstract void HidePopUp();

}
