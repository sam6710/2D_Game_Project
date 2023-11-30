using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffect;
    private Transform camera;
    private Vector3 lastpositioncamera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        lastpositioncamera = camera.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 backgroundMovement = camera.position - lastpositioncamera;
        transform.position += new Vector3(backgroundMovement.x + parallaxEffect, backgroundMovement.y, 0);
        lastpositioncamera = camera.position;
    }
}
