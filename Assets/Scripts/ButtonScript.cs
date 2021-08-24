using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent buttonclick;

    void Awake()
    {
        if(buttonclick == null)
        {
            buttonclick = new UnityEvent();
        }
    }
    void OnMouseUp()
    {
        buttonclick.Invoke();   
    }

}
