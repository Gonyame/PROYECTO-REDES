using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{
    public GameObject gameOverPanel; // Panel de "Game Over"
    public TextMeshProUGUI gameOverText; // Texto de "Game Over"

    void Start()
    {
        gameOverPanel.SetActive(false); // Ocultar el panel al inicio
    }

    public void ShowGameOver(string playerName)
    {
        if (photonView.IsMine)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = playerName + " ha sido eliminado";
        }
    }
}
