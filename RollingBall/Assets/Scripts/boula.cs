using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boula : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement parameters")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float movementForce;

    [Header("Interactables")]
    [SerializeField] private float interactionDistance;
    [SerializeField] private float interactionRadius;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private LayerMask whatIsInteractable;

    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject TopCamera;

    float hInput, vInput;

    private Vector3 initPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
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

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Asegurar que no haya movimiento en el eje Y
        forward.y = 0;
        right.y = 0;

        // Normalizar para evitar que el movimiento diagonal sea más rápido
        forward.Normalize();
        right.Normalize();

        // Calcular la dirección de movimiento
        Vector3 moveDirection = forward * vInput + right * hInput;

        // Aplicar fuerza al Rigidbody
        rb.AddForce(moveDirection * movementForce, ForceMode.Acceleration);
    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name);

        if (other.name == "DeadZone")
        {

            transform.position = initPos;
        }
        else if (other.name == "CameraChange" || other.name == "CameraChange2")
        {
            if (MainCamera.activeSelf)
            {
                MainCamera.SetActive(false);
                TopCamera.SetActive(true);

            }
            else if (!MainCamera.activeSelf) {

                MainCamera.SetActive(true);
                TopCamera.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("RampTraps"))
        {

            transform.position = initPos;
        }
        else if (collision.gameObject.CompareTag("FakeDoors"))
        {

            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("CheckPoint"))
        {

            initPos = transform.position;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {

            SceneManager.LoadScene(0);
        }
    }
}
