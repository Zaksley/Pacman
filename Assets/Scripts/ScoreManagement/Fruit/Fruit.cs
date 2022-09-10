using UnityEngine;

namespace ScoreManagement
{
    public class Fruit : MonoBehaviour
    {
        private void Eat()
        {
            FindObjectOfType<FruitSpawner>().FruitEaten();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
            {
                Eat();
            }
        }
    }
}