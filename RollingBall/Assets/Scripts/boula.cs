using TMPro;
using UnityEngine;

public class boula : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement parameters")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float movementForce;
    //[SerializeField] TMP_Text scoreText;

    [Header("Interactables")]
    [SerializeField] private float interactionDistance;
    [SerializeField] private float interactionRadius;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private LayerMask whatIsInteractable;

    float hInput, vInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(hInput, 0, vInput).normalized * movementForce, ForceMode.Force);
    }
}
