using UnityEngine;


namespace EnemyNameSpace
{
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
    }

}

