using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] float releaseForce = 7f;
    [SerializeField] float releaseForceFactor = 10f;
    [SerializeField] float defaultForce = 5f;
    private SpringJoint springJoint;


    private void Start()
    {
        springJoint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        //ToDo: neues inputsystem verwenden
        if (Input.GetKeyDown(KeyCode.P))
        {
            springJoint.spring = defaultForce;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            springJoint.spring = releaseForce * releaseForceFactor;
        }
    }
}
