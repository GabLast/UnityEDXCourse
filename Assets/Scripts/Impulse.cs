using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public GameObject stone;
    public float firerate = 0.5f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowStone());
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            Instantiate(stone, transform.position, Random.rotation);
        }*/
    }

    IEnumerator ThrowStone()
    {
        while (true)
        {
            Instantiate(stone, transform.position, Random.rotation);
            //null means to call me on the next frame. so use this instead:
            yield return new WaitForSeconds(firerate);
        }
    }
}
