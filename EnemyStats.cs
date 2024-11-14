using UnityEngine;


public class EnemyStats : MonoBehaviour
{
    public int health;
    public ParticleSystem explosao;
    private ParticleSystem copia;
    public AudioClip collectSound; 
    private AudioSource audioSource;
    
    void start()
    {
    audioSource = gameObject.AddComponent<AudioSource>();
    health = 100;
    }


public void TakeDamage(int damage)
    {
    health -= damage;
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
          TakeDamage(15);
          Destroy (other.gameObject);
          if (health <=0)
          {
            Destroy (this.gameObject);
            copia = Instantiate(explosao, this.transform.position, Quaternion.identity);
          }
        }
    }
}