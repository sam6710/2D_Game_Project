using UnityEngine;

public class EagleController : MonoBehaviour
{
    public float velocidad;
    public Vector3 endPosition;
    public Vector3 initialPosition;
    private bool movingToEnd;
    public int endX, endY;
    public SpriteRenderer sprite;
    private GameObject player;
    private PlayerController playerCon;
    void Start()
    {
        movingToEnd = true;
        initialPosition = transform.position;
        endPosition = new Vector3(initialPosition.x + endX, initialPosition.y + endY, initialPosition.z);
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
		Flip();
	}

    void Fly()
    {
        Vector3 posicionDestino = (movingToEnd) ? endPosition : initialPosition;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);
        if (transform.position == endPosition)
        {
            movingToEnd = false;
        }
        if (transform.position == initialPosition)
        {
            movingToEnd = true;
        }
    }

	void Flip()
	{
		//Debug.Log("Current Position: " + transform.position.x + ", End Position: " + endPosition.x);
		if ((transform.position.x < initialPosition.x) && movingToEnd  == true)
		{
			sprite.flipX = false;
			//CambiarDireccion(1f);
		}
		if (transform.position.x <= endPosition.x)
		{
			sprite.flipX = true;
			//CambiarDireccion(-1f);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCon.PlayerDeath();
        }
    }
}
