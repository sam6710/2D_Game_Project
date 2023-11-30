using UnityEngine;
using UnityEngine.SceneManagement;

public class cherry : MonoBehaviour
{
    private bool picked;
    public AudioSource audio;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        picked = false;
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !picked)
        {
            picked = true;
            audio.Play();
            anim.SetBool("Picked", picked);
            Invoke("FinNivel", 0.5f);
        }
    }

    private void FinNivel()
    {
        SceneManager.LoadScene("BetweenLvlScene");
    }
}
