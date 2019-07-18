using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public Vector2 joystick;

    public float speed = 5f;
    public GameObject centerEye;
    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        // joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

        transform.eulerAngles = new Vector3(0, centerEye.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);

        parentObject.transform.position = Vector3.Lerp(parentObject.transform.position, transform.position, 10f * Time.deltaTime);

        // Input.GetMouseButtonDown(0);
    }
}
