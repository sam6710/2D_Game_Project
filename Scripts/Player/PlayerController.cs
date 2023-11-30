using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jump;
    private Rigidbody2D physics;
    private SpriteRenderer sprite;
    public Animator anim;
    float Xentry = 0f;
    public bool Hit = false;
    public Transform playerTransform;
    public float deathHeight = -8.5f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        jump = 7;
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Xentry = Input.GetAxis("Horizontal");
        Jump();
        Flip();
        Crouch();
        //Animar
        anim.SetFloat("xspeed", Mathf.Abs(physics.velocity.x));
        anim.SetFloat("yspeed", physics.velocity.y);
        CheckPlayerHeight();
    }

    private void FixedUpdate()
    {
        physics.velocity = new Vector2(Xentry * speed, physics.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchingFloor())
        {
            physics.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        if (Hit)
        {
            physics.AddForce(Vector2.up * jump * 1.5f, ForceMode2D.Impulse);
            Hit = false;
        }
    }

    private void Flip()
    {
        if (physics.velocity.x > 0f)
        {
            Quaternion nuevaRotacion = Quaternion.Euler(0, 0, 0f);
            sprite.flipX = false;
        }
        else if (physics.velocity.x < 0f)
        {
            Quaternion nuevaRotacion = Quaternion.Euler(0, 180, 0f);
            sprite.flipX = true;
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S) && touchingFloor())
        {
            anim.SetBool("crouched", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) && touchingFloor())
        {
            anim.SetBool("crouched", false);
        }
    }

    private bool touchingFloor()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position + new Vector3(1, -2f, 0), Vector2.down, 0.2f);
        RaycastHit2D touch2 = Physics2D.Raycast(transform.position + new Vector3(-1, -2f, 0), Vector2.down, 0.2f);
        if (touch || touch2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckPlayerHeight()
    {
        if (playerTransform.position.y < deathHeight)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
