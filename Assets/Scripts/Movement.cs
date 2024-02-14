using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    // create a public variable to control the speed from the UI itself
    public float speed;
    public Text display;
    public AudioSource asource;
    public AudioClip aclip;

    private Rigidbody rb;
    private Vector3 movement;
    private int count;

    // method called during the beginning of the game
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Called before application of a Physics Transform on any object
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a new Vector3 object movement = new Vector3( x, y, z )
        // x will be the moveHorizontal
        // y will be 0.0
        // z will be moveVertical
        // So, use it in this way

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // now that we have a public variable, the speed can be controlle
        // from the Unity UI itself, without having to recompile the script
        // each time that you want to change the value.
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            asource.PlayOneShot(aclip);
            count += 1;
            display.text = "Coins:-" + count.ToString();
        }
    }

}

