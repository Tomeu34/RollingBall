using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class MovementTrap : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float timeToReturn;
    private Vector3 currentDirection;
    private Rigidbody rb;

    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = currentDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToReturn){

            currentDirection = currentDirection == Vector3.right ? Vector3.left : Vector3.right;
            rb.linearVelocity = currentDirection * speed;
            timer = 0;
        }
    }
}
