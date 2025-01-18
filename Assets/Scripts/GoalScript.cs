using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField] private LayerMask isPlayer;
    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //falta comprobar que la colision sea el player mediante layers o tags
            Debug.Log("Muelto");
            gameManager.GoalReached();

        }



    }
}
