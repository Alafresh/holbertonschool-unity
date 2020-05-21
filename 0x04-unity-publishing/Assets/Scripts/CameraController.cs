using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public Vector3 offset;
    public Vector3 rotation;
    private void Start()
    {
        transform.Rotate(rotation);
    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
