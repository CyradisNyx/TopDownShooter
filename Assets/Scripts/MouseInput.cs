using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Face Mouse
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(hit.point);
        }

        // Get mouse clicks and send event
        if (Input.GetMouseButtonDown(0))
        {
            EventMaster.Instance.LeftClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            EventMaster.Instance.RightClick();
        }
    }
}
