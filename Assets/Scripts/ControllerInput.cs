using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    static List<int> assignedControllers = new List<int>();
    int controllerID = 1;

    public bool ConnectedController { get { return controllerID > 0; } }
    public string Horizontal { get { return "Controller" + controllerID + "Horizontal"; } }
    public string Vertical { get { return "Controller" + controllerID + "Vertical"; } }
    public string ButtonA { get { return "Controller" + controllerID + "A"; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerID <= 0)
        {
            //See if any controller activates
            for (int i = 0; i < 2; i++)
            {
                if (Input.GetButtonDown("Controller" + (i + 1) + "A"))
                    controllerID = i + 1;
            }
        }
    }
}
