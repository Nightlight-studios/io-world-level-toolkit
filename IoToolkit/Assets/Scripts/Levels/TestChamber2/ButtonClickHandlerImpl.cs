using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandlerImpl : IButtonClickHandler
{

    private ButtonData data;

    public ButtonClickHandlerImpl(ButtonData data) {
        this.data = data;
    }


    public void Activate() {

        data.SpriteRenderer.color = Color.red;
        data.Transform.localScale = new Vector3(data.Transform.localScale.x, 0.3f, 0);
        Debug.Log("button activated from handler :D");
        
    }

}
