using UnityEngine;

public class Gem : MonoBehaviour
{
    private bool picked;
    public AudioSource audio;
    public Animator anim;
    //public LvlData data;
    // Start is called before the first frame update
    void Start()
    {
        picked = false;
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //data = new LvlData();
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
            //collision.gameObject.GetComponent<LvlData>().pickedGems();
            //data.pickedGems();
            Destroy(gameObject, 0.5f);
        }
    }
}
