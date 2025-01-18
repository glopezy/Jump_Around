using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private LayerMask isPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //falta comprobar que la colision sea el player mediante layers o tags
            Debug.Log("Muelto");
            GameManager.Restart();
        }
        
        
        
    }
}
