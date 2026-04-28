using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 5.0f;
    public float sensibilidadeRato = 2.0f;

    private float rotacaoY = 0f;

    void Start()
    {
        // Opcional: Esconde o rato e prende-o no centro do ecrã
        Cursor.lockState = CursorLockMode.Locked;
    }

 void Update()
{
    // 1. ROTAÇÃO com o Rato
    float ratoX = Input.GetAxis("Mouse X") * sensibilidadeRato;
    rotacaoY += ratoX;
    transform.localRotation = Quaternion.Euler(0f, rotacaoY, 0f);

    // 2. MOVIMENTO (Corrigido)
    float v = Input.GetAxis("Vertical");   // W, S, Seta Cima, Seta Baixo
    float h = Input.GetAxis("Horizontal"); // A, D, Seta Esquerda, Seta Direita

    Vector3 movimento = (transform.forward * v) + (transform.right * h);
    transform.position += movimento * velocidade * Time.deltaTime;
}
}