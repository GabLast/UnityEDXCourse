using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    private Renderer renderer;
    public int hp = 100;
    public float speed;
    public float forceValue;
    public float jumpValue;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0,
            Input.GetAxis("Vertical") * speed * Time.deltaTime);*/
                                            /*check if we're over a surface*/
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.01f)
        {
            rigidbody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            audioSource.Play();
        }

    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")) * forceValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp -= 10;
            print("Choque contra enemigo");
            /*Destroy(collision.gameObject);*/
            if(hp <= 0)
            {
                print("RIP");
                
                renderer.material.color = Color.black;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Inside invisible cube");
    }

    /*
     Para acceder a los componentes de un objeto, usar GetComponent:
    GameObject a = collision.gameObject;
    a.GetComponent<MeshRenderer o cualquier otro objeto>().unatributo = algo
     */
}
