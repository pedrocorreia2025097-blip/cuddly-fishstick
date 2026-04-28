using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Configurações de Spawn")]
    [SerializeField] private Transform pontoDePartida; 

    void Start()
    {
        VoltarAoInicio();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se tocar no plano de finalização (Tag: Fim)
        if (other.CompareTag("Fim"))
        {
            VoltarAoInicio();
        }
        
        // Se o inimigo encostar no player (Tag: Inimigo)
        if (other.CompareTag("Inimigo"))
        {
            VoltarAoInicio();
        }
    }

    public void VoltarAoInicio()
    {
        if (pontoDePartida != null)
        {
            transform.position = pontoDePartida.position;
            
            // Caso use física, zeramos a inércia para ele não "escorregar" ao spawnar
            if(TryGetComponent(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}