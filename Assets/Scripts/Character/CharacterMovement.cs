using UnityEngine;
using Photon.Pun;
using System;

public class CharacterMovement : MonoBehaviourPun
{
    [Header("Settings: Move")]
    [SerializeField] float pSpeed = 1;


    [Header("References")]
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");


            Vector3 dir = new Vector3(x, 0f, z);
            if(dir.magnitude > 0)
            {
                dir.Normalize();
                controller.Move(dir * pSpeed * Time.deltaTime);
            } 
        }
    }

}
