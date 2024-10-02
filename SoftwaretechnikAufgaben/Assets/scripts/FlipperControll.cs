using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControll : MonoBehaviour
{
    public float resetPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public bool right = true;

    private HingeJoint joint;

    private void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useSpring = true;

        JointLimits limits = joint.limits;
        limits.min = resetPosition - 10; 
        limits.max = pressedPosition + 10; 
        joint.limits = limits;
    }

    private void Update()
    {
        JointSpring spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };

        if (right)
        {
            if (Input.GetMouseButton(1))  
            {
                spring.targetPosition = pressedPosition;
            }
            else
            {
                spring.targetPosition = resetPosition;
            }
        }
        else 
        {
            if (Input.GetMouseButton(0))  
            {
                spring.targetPosition = pressedPosition;
            }
            else
            {
                spring.targetPosition = resetPosition;
            }
        }

        joint.spring = spring;
        joint.useLimits = true;
    }
}
