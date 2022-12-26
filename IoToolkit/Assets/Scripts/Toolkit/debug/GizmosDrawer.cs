using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosDrawer : MonoBehaviour
{

    public Color color = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    
    }
}
