using UnityEngine;

public class TeleportPlayers : MonoBehaviour
{
    private void Awake() 
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            player.transform.SetPositionAndRotation(new Vector3(679, 560, 308), player.transform.rotation);
        }
    }
}
