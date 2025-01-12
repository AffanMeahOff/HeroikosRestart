using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //Voir doc

    public float speed = 12f;
    public float gravity = -9.81f * 4;
    public float jumpHeight = 3f;
 
    public Transform groundCheck; //Voir doc
    public float groundDistance = 0.4f; //Rayon de detection du sol. 
    public LayerMask groundMask; //Voir Doc 
 
    Vector3 velocity;
 
    bool isGrounded;
 
    void Update()
    {
        //Augmentation de la vitesse de la chute si le joueur n"estpas au sol
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //Stabilisation lors de la chute {pour eviter que ca repart a la chute}
        }
 
        float x = Input.GetAxis("Horizontal"); //Touche A/D
        float z = Input.GetAxis("Vertical"); //Touche W/S
 
        Vector3 move = transform.right * x + transform.forward * z; //Update de la position 
 
        controller.Move(move * speed * Time.deltaTime); //Mouvement en lui meme
 
        if (Input.GetButtonDown("Jump") && isGrounded) //Gestion du saut 
        {
            //Equation du saut
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //V = a la racine carré de 2gh 
        }
 
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);
    }
}