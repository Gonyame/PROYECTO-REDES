using UnityEngine;
using Photon.Pun;

/// <summary>
/// Gestiona la aplicaci�n de da�o a los jugadores en el juego multijugador.
/// Se encarga de detectar colisiones y aplicar da�o a los jugadores afectados.
/// </summary>
public class DamageDealer : MonoBehaviour
{
    /// <summary>
    /// Cantidad de da�o que este objeto aplica al colisionar con un jugador.
    /// </summary>
    public int damageAmount = 10;

    /// <summary>
    /// Se ejecuta cuando este objeto colisiona con otro collider.
    /// Detecta si el objeto golpeado es un jugador y le aplica el da�o correspondiente.
    /// </summary>
    /// <param name="collision">Informaci�n sobre la colisi�n ocurrida</param>
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto golpeado es un jugador
        CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
        if (characterHealth != null)
        {
            // Llamar al m�todo TakeDamage en el jugador
            characterHealth.photonView.RPC("TakeDamage", RpcTarget.All, damageAmount);
        }
    }
}