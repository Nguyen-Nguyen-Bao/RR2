using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rb;
    enum Rotate { left, right };
    float rotate_angle;
    float facing_angle;
    Vector3 facing_direction;
    Animator animator;
    public Transform cowboy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        if (gameManager.speed <= 0) gameManager.speed = 50;
    }
    // Update is called once per frame
    void Update()
    {
        cowboy.position = transform.position;
        if (rb.velocity.z > 10)
        {
            animator.SetBool("isMoving", true);
        }
        else animator.SetBool("isMoving", false);
        Rotate rotate;
        Vector3 try_rotate_vector = Quaternion.AngleAxis(rotate_angle, new Vector3(0, 1, 0)) * facing_direction;
        if (Vector3.Angle(try_rotate_vector, rb.velocity) == 0) rotate = Rotate.right;
        else rotate = Rotate.left;
        if (rb.velocity != Vector3.zero && rotate == Rotate.left)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - (rotate_angle < 6 ? rotate_angle : 6), 0);
            facing_angle -= rotate_angle < 6 ? rotate_angle : 6;
        }
        else if (rb.velocity != Vector3.zero && rotate == Rotate.right)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (rotate_angle < 6 ? rotate_angle : 6), 0);
            facing_angle += rotate_angle < 6 ? rotate_angle : 6;
        }
        facing_direction = Quaternion.AngleAxis(facing_angle, new Vector3(0, 1, 0)) * new Vector3(0, 0, 1);
        //transform.eulerAngles = new Vector3(0, rb.velocity, 0);
        if (Input.GetMouseButton(0))
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector3(rb.velocity.x, 0, 1);
            rb.velocity = rb.velocity.normalized * gameManager.speed;
            rb.velocity = new Vector3(rb.velocity.x, y, rb.velocity.z);
        }
        cowboy.eulerAngles = Vector3.zero;
    }
}
