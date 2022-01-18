using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubControlOcean : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Camera shipcamera;

    [SerializeField] private GameObject Helice;
    [SerializeField] private GameObject myPlayer;

    [SerializeField] private float forwardSpeed = 15f, strafeSpeed = 10f;
    private float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;

    private bool rotateBool;
    private bool rotateAroundBool;

    private bool isControlable = false;
    // Start is called before the first frame update
    void Start()
    {
        
        rb.transform.InverseTransformVector(rb.velocity);
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlable)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Cursor.visible = true;
                rotateAroundBool = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                rotateAroundBool = false;
            }
            if (rotateAroundBool)
            {
                shipcamera.transform.RotateAround(this.transform.position, transform.up, Input.GetAxisRaw("Mouse X"));

            }

            Helice.transform.Rotate(rb.velocity.magnitude * Time.deltaTime * 10, 0, 0);


            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                rotateBool = true;
                lookInput.x = 0;
                lookInput.y = 0;
                Cursor.Equals(0, 0);

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                rotateBool = false;
                mouseDistance.x = 0;
                mouseDistance.y = 0;
            }
            if (rotateBool)
            {
                mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
                mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
            }
            if(transform.position.y >= 574)
            {
                transform.position = new Vector3(transform.position.x, 573, transform.position.y);
            }
            transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, 0, 0, Space.Self);
            //transform.Rotate(0, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0, Space.Self);
            transform.Rotate(0, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0, Space.World);


            rb.AddForce(transform.forward * forwardSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime * 500);
            rb.AddForce(transform.right * strafeSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 500);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isControlable)
            {
                rb.isKinematic = true;
                myPlayer.transform.position = transform.position + Vector3.up * 3;
                myPlayer.SetActive(true);
                shipcamera.gameObject.SetActive(false);
                ActiveControl(false);
            }
            else
            {
                rb.isKinematic = false;
                myPlayer.SetActive(false);
                shipcamera.gameObject.SetActive(true);
                ActiveControl(true);
            }
        }
      
    }
    public void ActiveControl(bool active)
    {
        isControlable = active;
    }
}
