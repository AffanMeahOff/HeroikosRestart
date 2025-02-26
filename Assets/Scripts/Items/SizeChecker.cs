using UnityEngine;

public class SizeChecker : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        if (rend != null)
        {
            Debug.Log($"📏 Taille du Mesh de {gameObject.name} : {rend.bounds.size}");
        }
        else
        {
            Debug.LogWarning($"❌ Aucun Renderer trouvé sur {gameObject.name} !");
        }
    }
}
