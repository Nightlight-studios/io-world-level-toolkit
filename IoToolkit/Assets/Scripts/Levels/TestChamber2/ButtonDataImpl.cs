using UnityEngine;

public class ButtonDataImpl : ButtonData
{
    public ButtonDataImpl(ButtonClick parent) : base(parent) {
        this.SpriteRenderer.color = Color.green;
    }
}