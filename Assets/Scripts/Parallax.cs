using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour

{
    public GameObject cam;
    public float parallaxSpeed = 1.0f;

    private float length;
    private float origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxSpeed;
        Vector3 delta = new Vector3(origin + distance, transform.position.y, transform.position.z);
        transform.position = delta;
    }
}
