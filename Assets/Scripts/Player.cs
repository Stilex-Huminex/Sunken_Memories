using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif


[System.Serializable]
public class Player : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private Camera playerCamera;
    private float speed = 1;
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private float runSpeed = 1.5f;
    [SerializeField] private float jump = 10;
    [SerializeField] private float mainForce = 10;

    [HideInInspector]
    public float minVisionEditor;

    private float minVision;

    [HideInInspector]
    public float maxVisionEditor;

    private float maxVision;



    private bool canJump = false;

#if UNITY_EDITOR
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Player player = (Player)target;
            base.OnInspectorGUI();
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Vision From Horizontal view extend to Vertical view");

            EditorGUILayout.LabelField("BottomVision");
            player.minVisionEditor = EditorGUILayout.Slider(player.minVisionEditor, -80, 0);

            EditorGUILayout.LabelField("TopVision");
            player.maxVisionEditor = EditorGUILayout.Slider(player.maxVisionEditor, 0, 80);

            if (GUI.changed)
            {
                EditorUtility.SetDirty(player);
            }
        }



    }
#endif


    // Start is called before the first frame update
    void Start()
    {
        playerCamera.gameObject.SetActive(true);
        rb.GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        minVision = minVisionEditor + 79;
        maxVision = 359 - maxVisionEditor;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed * mainForce;
        float y = Input.GetAxisRaw("Vertical") * speed * mainForce;

        Vector3 move = transform.right * x + transform.forward * y;
        Vector3 newMove = new Vector3(move.x, rb.velocity.y, move.z);

        rb.velocity = newMove;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jump * mainForce, ForceMode.Impulse);
        }

        playerCamera.transform.Rotate(Input.GetAxisRaw("Mouse Y") * -2, 0, 0);
        this.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0);

        if (playerCamera.transform.localEulerAngles.x > minVision && playerCamera.transform.localEulerAngles.x < 180)
            playerCamera.transform.localEulerAngles = new Vector3(minVision, playerCamera.transform.localEulerAngles.y, 0);

        if (playerCamera.transform.localEulerAngles.x < maxVision && playerCamera.transform.localEulerAngles.x > 180)
            playerCamera.transform.localEulerAngles = new Vector3(maxVision - 360, playerCamera.transform.localEulerAngles.y, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Terrain"))
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("Terrain"))
        {
            canJump = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z),
            new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + (minVisionEditor) * -1 - 80, playerCamera.transform.position.z) + 10 * transform.forward);

        Gizmos.DrawLine(new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z),
            new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + maxVisionEditor, playerCamera.transform.position.z) + 10 * transform.forward);


    }
   
}


