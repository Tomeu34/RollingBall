using UnityEngine;

public class PlataformaFisicaVert1 : MonoBehaviour
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

            currentDirection = currentDirection == Vector3.up ? Vector3.down : Vector3.up;
            rb.linearVelocity = currentDirection * speed;
            timer = 0;
        }
    }
}
