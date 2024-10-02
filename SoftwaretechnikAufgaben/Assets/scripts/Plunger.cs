using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public float releaseForce = 100f;
    public float defaultForce = 5f;
    private SpringJoint springJoint;            
   

    private void Start()
    {
        springJoint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            springJoint.spring = defaultForce;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            springJoint.spring = releaseForce; 
        }
    }
}
