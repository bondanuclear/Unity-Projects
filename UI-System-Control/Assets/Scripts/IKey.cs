public interface IKey {
    void ShowPopUp();
    void ClosePopUp();
    void HidePopUp();
    int Priority {get;}
    string InfoName {get;}
}