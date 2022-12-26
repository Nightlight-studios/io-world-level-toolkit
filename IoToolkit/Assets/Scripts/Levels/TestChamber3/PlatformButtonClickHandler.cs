using UnityEngine;
public class PlatformButtonClickHandler : IButtonClickHandler
{

    private ButtonData data;
    private RailPlaftform[] platforms;

    public PlatformButtonClickHandler(ButtonData data, RailPlaftform[] platforms) {
        this.data = data;
        this.platforms = platforms;
    }

    public void Activate() {
        
        data.SpriteRenderer.color = Color.red;
        data.Transform.localScale = new Vector3(data.Transform.localScale.x, 0.3f, 0);

        foreach (RailPlaftform plaftform in platforms)
        {
            plaftform.isMoving = true;
        }

    }

}