using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    static List<int> assignedControllers = new List<int>();
    int controllerID = 0;

    public bool ConnectedController { get { return controllerID > 0; } }
    public string Horizontal { get { return "Controller" + controllerID + "Horizontal"; } }
    //public string Vertical { get { return "Controller" + controllerID + "Vertical"; } }
    public string Jump { get { return "Controller" + controllerID + "Jump"; } }
    public string Action { get { return "Controller" + controllerID + "Action"; } }

    // Start is called before the first frame update
    void Start()
    {
        if (!assignedControllers.Contains(1))
        {
            assignedControllers.Add(1);
            controllerID = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerID <= 0)
        {
            //See if any controller activates
            for (int i = 1; i <= 2; i++)
            {
                print(i + " " + Input.GetButtonDown("Controller" + i + "Action"));
                if ((!assignedControllers.Contains(i)) && Input.GetButtonDown("Controller" + i + "Action"))
                {
                    controllerID = i;
                    assignedControllers.Add(i);
                }
            }
        }
    }
}
