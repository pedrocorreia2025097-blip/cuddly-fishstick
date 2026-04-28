using UnityEngine;

public partial class EnemyFollow : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform playerTransform;

    void Start()
    {
        // Busca o objeto chamado "Player" na cena
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calcula a direção e move a esfera
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Detecta colisão com a bala
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // O inimigo desaparece
            Destroy(other.gameObject); // A bala também desaparece
        }
    }
}