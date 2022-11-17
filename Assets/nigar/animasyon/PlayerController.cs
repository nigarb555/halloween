using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float horizontal;
    float vertical;
    float turnSmoothVelocity;
    [SerializeField] float MovementForce = 10f;
    [SerializeField] float SmoothTurnTime = 0.1f;
    Rigidbody rb;
    Vector3 direction;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);
        //anim.SetFloat("Run", direction.magnitude);
        if (direction.magnitude > 0.01f)
        {
            anim.SetFloat("run", direction.magnitude);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0);

            rb.MovePosition(transform.position + (direction * MovementForce * Time.deltaTime));
        }
    }
}
