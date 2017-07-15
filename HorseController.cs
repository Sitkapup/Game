using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class HorseController : MonoBehaviour
{

    Animator anim;
    public float MoveSpeed;
    public float RotationSpeed;
    public bool Vertical;
    CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));
        cc.Move(forward * Time.deltaTime);
        cc.SimpleMove(Physics.gravity);
        float move = Input.GetAxis("Vertical") * 0.5f;
        float turn = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
        anim.SetFloat("Direction", turn);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 10.0f;
            RotationSpeed = 100.0f;
            anim.SetFloat("Speed", 1f);

        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 2.0f;
            RotationSpeed = 20.0f;
            
        }
    }
}