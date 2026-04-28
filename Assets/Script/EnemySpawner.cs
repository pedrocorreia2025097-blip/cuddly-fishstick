using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configurações de Spawn")]
    public GameObject enemyPrefab;    // Arraste o Prefab da Esfera aqui
    public float spawnRate = 2.0f;    // Tempo em segundos entre cada inimigo
    public float spawnRadius = 10f;   // Distância do centro onde eles podem surgir

    private float nextSpawnTime;

    void Update()
    {
        // Verifica se já passou o tempo necessário para o próximo spawn
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Gera uma posição aleatória dentro de um círculo (no plano XZ)
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomCircle.x, 1f, randomCircle.y) + transform.position;

        // Cria o inimigo na posição calculada
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    // Desenha o raio de spawn no Editor para facilitar a visualização
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}