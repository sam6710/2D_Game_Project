using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float speed;
    public Vector3 endPosition;
    public Vector3 initialPosition;
    private bool movingtoEnd;
    public int endX;
    public SpriteRenderer sprite;
    private PlayerController player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movingtoEnd = true;
        initialPosition = transform.position;
        endPosition = new Vector3(initialPosition.x + endX, initialPosition.y, initialPosition.z);
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
		Flip();
	}

    void Move()
    {
        Vector3 posicionDestino = (movingtoEnd) ? endPosition : initialPosition;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, speed * Time.deltaTime);
        if (transform.position == endPosition)
        {
            movingtoEnd = false;
        }
        if (transform.position == initialPosition)
        {
            movingtoEnd = true;
        }
    }

	void Flip()
	{
		//Debug.Log("Current Position: " + transform.position.x + ", End Position: " + endPosition.x);
		if ((transform.position.x > initialPosition.x) && movingtoEnd == true)
		{
			sprite.flipX = true;
			//CambiarDireccion(1f);
		}
		if (transform.position.x >= endPosition.x)
		{
			sprite.flipX = false;
			//CambiarDireccion(-1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Hit = true;
            anim.SetBool("Destroyed", true);
            Invoke("DestroyObject", 0.6f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.PlayerDeath();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
