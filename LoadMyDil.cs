using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSMyDil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // En cas de collision :
    {
        if (collision.CompareTag("Player")) // le joueur se t�l�porte ...
        {
            SceneManager.LoadScene("Workshop"); // Dans la zone de la remise du workshop
        }
    }

}