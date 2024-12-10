using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Army : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rb;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            gameManager.lost = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager.lost = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 20);
    }
}
