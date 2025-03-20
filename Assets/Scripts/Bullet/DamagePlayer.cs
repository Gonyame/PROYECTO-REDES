using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que hace este objeto

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto golpeado es un jugador
        CharacterHealth playerHealth = collision.gameObject.GetComponent<CharacterHealth>();
        if (playerHealth != null)
        {
            // Llamar al método TakeDamage en el jugador
            playerHealth.photonView.RPC("TakeDamage", RpcTarget.All, damageAmount);
        }
    }
}
