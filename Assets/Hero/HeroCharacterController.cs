using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour

{

    [SerializeField] LayerMask groundlayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;
    public AudioSource someSound;
    


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;

        //Character schaut nach vorne
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //Berührt den Boden
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundlayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = 0;
        }
        else
        {
            //Fügt Gravitation hinzu
            velocity.y += gravity * Time.deltaTime;
        }


        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);


        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            someSound.Play();
        }


    //verticale Geschwindigkeit
    characterController.Move(velocity * Time.deltaTime);
    }
}
