using UnityEngine;

public class Platform : MonoBehaviour
{
    public int speed;
    public Vector3 initialPos;
    public Vector3 finalPos;
    public int stopX, stopY;
    private bool movingToEnd;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        finalPos = new Vector3(initialPos.x + stopX, initialPos.y + stopY, initialPos.z);
        //posicionFinal = new Vector3(posicionInicio.x + topeX, posicionInicio.y + topeY, posicionInicio.x);
        movingToEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //Debug.Log("Move");
        Vector3 posicionDestino = (movingToEnd) ? finalPos : initialPos;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, speed * Time.deltaTime);
        if (transform.position == finalPos)
        {
            movingToEnd = false;
        }
        else if (transform.position == initialPos)
        {
            movingToEnd = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
