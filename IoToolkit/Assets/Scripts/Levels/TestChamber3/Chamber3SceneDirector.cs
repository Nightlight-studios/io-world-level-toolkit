using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamber3SceneDirector : MonoBehaviour
{

    public GameObject button;
    public GameObject platform;
    public GameObject platform2;

    // Start is called before the first frame update
    void Start()
    {

        RailPlaftform[] platforms = new RailPlaftform[] { platform.GetComponent<RailPlaftform>(), platform2.GetComponent<RailPlaftform>() };

        button = GameObject.Find("PlatformStartButton");
        ButtonClick buttonBehaviour = button.GetComponent<ButtonClick>();
        buttonBehaviour.handler = new PlatformButtonClickHandler(new ButtonDataImpl(buttonBehaviour), platforms);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
