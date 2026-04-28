using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;    // Arraste o Prefab da esfera aqui no Inspector
    public Transform firePoint;        // Um objeto vazio na frente do cubo para sair a bala
    public float bulletSpeed = 20f;    // Velocidade do disparo

    void Update()
    {
        // "Fire1" geralmente é o botão esquerdo do mouse ou Ctrl
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cria a instância da bala na posição e rotação do firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Pega o Rigidbody da bala para aplicar força
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        // Destrói a bala após 3 segundos para não pesar o jogo
        Destroy(bullet, 3f);
    }
}