using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandlerImpl : IButtonClickHandler
{

    public ButtonClickHandlerImpl() {
        Debug.Log("Creating button handler");
    }


    public void Activate() {
        Debug.Log("button activated from handler :D");
        
    }

}
