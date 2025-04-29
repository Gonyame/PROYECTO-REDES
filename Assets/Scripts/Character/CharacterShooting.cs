using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterShooting : MonoBehaviourPun
{
    [Header("Settings: Shoot")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform aimPoint;
    [SerializeField] float bSpeed;
    [SerializeField] AudioSource audioPewpew;

    // Update is called once per frame
    void Update()
    {
        //Verifica si el jugador local es el dueño del PhotonView y si presiona el botón se instancia la bala
        if (photonView.IsMine && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //Instancia la bala en la red usando PhotonNetwork.Instancia
        //Solo el jugador local (dueño del PhotonView) ejecuta esta logica
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, aimPoint.position, aimPoint.rotation);

        //Inicializa la bala con la velocidad y el dueño (jugador que disparo)
        bullet.GetComponent<Bullet>().Initialize(bSpeed, photonView.Owner);
        audioPewpew.Play();
    }
}
