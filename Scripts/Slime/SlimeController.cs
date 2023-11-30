using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Animator anim;
    public float animationWaitTime;
    public float elapsedTime;
    //private Rigidbody2D rb;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        animationWaitTime = 2.5f;
        elapsedTime = 0f;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        animation();
    }

    new void animation()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= animationWaitTime)
        {
            //anim.Play("Slimer");
            anim.SetFloat("WaitTimer", elapsedTime);
            elapsedTime = 0f;
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
