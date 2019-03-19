using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControllerInput))]
public class LocalPlayer : MonoBehaviour
{
    ControllerInput input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ControllerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.ConnectedController)
        {

        }
        print(Input.GetAxis(input.ButtonA));
    }
}
