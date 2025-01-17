using UnityEngine;


namespace EnemyNameSpace
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private int hp;

        protected int Hp { get => hp; set => hp = value; }

        protected abstract void Attack();
        
        protected virtual void Chase()
        {
            //distance
            //move
        }

        protected void TakeDamage(int damage)
        {

        }

        protected void Reset()
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                Debug.Log("kill");
            }
        }
    }

}

