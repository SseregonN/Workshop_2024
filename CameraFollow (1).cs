using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables public
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    //Variables privées
    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
