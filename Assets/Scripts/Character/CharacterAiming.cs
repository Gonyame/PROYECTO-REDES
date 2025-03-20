using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CharacterAiming : MonoBehaviourPun
{
    [SerializeField] float rSpeed = 10;
    void Update()
    {
        if (photonView.IsMine)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 direction = hit.point - transform.position;
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    Quaternion targetRotatiion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotatiion, Time.deltaTime * rSpeed);
                }
            }
        }
    }
}
