using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private CharacterController CharacterController;


    [SerializeField] float MoveSpeed;
    [SerializeField] float Jumpforce;
    [SerializeField] float GravityForce;

    [SerializeField] Vector3 Movement;


    [SerializeField] float Hangtime, Hangcounter;
    [SerializeField] float JumpBufferTime, JumpBufferCount;

    
    [SerializeField] int MaxHealth, CurrentHealth;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrentHealth = MaxHealth;
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();

    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        float ystore = Movement.y;

        Movement = (transform.forward * Vertical) + (transform.right * Horizontal);

        //normalize movement
        //make sure to normalize movemnt before we retreive y store
        Movement.Normalize();

        Movement.y = ystore;

        Jumping();

        Movement.y += Physics.gravity.y * Time.deltaTime * GravityForce;

        CharacterController.Move(Movement * Time.deltaTime * MoveSpeed);
    }

    private void Jumping()
    {
        if (CharacterController.isGrounded)
        {
            Hangcounter = Hangtime;
            Movement.y = -1f;
        }
        else
        {
            Hangcounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpBufferCount = JumpBufferTime;
        }

        else
        {
            JumpBufferCount -= Time.deltaTime;
        }

        //when we click the jump button Jumpbuffercount will be reset to its max and count down
        //if the controller is on the ground(hangcounter > 0) whilst the jumpbuffercount is greater than 0
        //then we will be able to jump

        if (JumpBufferCount >= 0 && Hangcounter > 0)
        {
            Movement.y += Mathf.Sqrt(Jumpforce * -2f * Physics.gravity.y);
            JumpBufferCount = 0f;
        }
    }


    public void Takedamage(int damage)
    {
        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            DIE.instance.StartCoroutine(DIE.instance.die());
        }
    }
}
