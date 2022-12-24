using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDirector : MonoBehaviour
{

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
        ButtonClick buttonBehaviour = button.GetComponent<ButtonClick>();
        buttonBehaviour.handler = new ButtonClickHandlerImpl(new ButtonDataImpl(buttonBehaviour));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
