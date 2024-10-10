using UnityEngine;

public class FlipperControll : MonoBehaviour
{
    [SerializeField] float resetPosition = 0f;
    [SerializeField] float pressedPosition = 45f;
    [SerializeField, Range(0, 10)] float hitStrength = 10f;
    [SerializeField] float flipperDamper = 150f;
    [SerializeField] float minMaxRange = 10f;

    [SerializeField] HingeJoint rightFlipperJoint;
    [SerializeField] HingeJoint leftFlipperJoint;

    private float hitStrengthFactor = 1000f;

    private void Start()
    {
        if (rightFlipperJoint != null)
        {
            rightFlipperJoint.useSpring = true;
            JointLimits rightLimits = rightFlipperJoint.limits;
            rightLimits.min = resetPosition - minMaxRange;
            rightLimits.max = pressedPosition + minMaxRange;
            rightFlipperJoint.limits = rightLimits;
        }

        if (leftFlipperJoint != null)
        {
            leftFlipperJoint.useSpring = true;
            JointLimits leftLimits = leftFlipperJoint.limits;
            leftLimits.min = resetPosition - minMaxRange;
            leftLimits.max = -pressedPosition + minMaxRange;
            leftFlipperJoint.limits = leftLimits;
        }
    }

    private void FixedUpdate()
    {
        ControlRightFlipper();
        ControlLeftFlipper();
    }

    private void ControlRightFlipper()
    {
        if (rightFlipperJoint != null)
        {
            JointSpring rightSpring = new JointSpring
            {
                spring = hitStrength * hitStrengthFactor,
                damper = flipperDamper
            };

            if (Input.GetMouseButton(1))
            {
                rightSpring.targetPosition = pressedPosition;
            }
            else
            {
                rightSpring.targetPosition = resetPosition;
            }

            rightFlipperJoint.spring = rightSpring;
            rightFlipperJoint.useLimits = true;
        }
    }

    private void ControlLeftFlipper()
    {
        if (leftFlipperJoint != null)
        {
            JointSpring leftSpring = new JointSpring
            {
                spring = hitStrength * hitStrengthFactor,
                damper = flipperDamper
            };

            if (Input.GetMouseButton(0))
            {
                leftSpring.targetPosition = -pressedPosition;
            }
            else
            {
                leftSpring.targetPosition = resetPosition;
            }

            leftFlipperJoint.spring = leftSpring;
            leftFlipperJoint.useLimits = true;
        }
    }
}
