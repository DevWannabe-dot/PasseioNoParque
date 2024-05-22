using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        // A câmera segue o personagem em x e y
        transform.position =
        new Vector3(target.transform.position.x,
        target.transform.position.y,
        transform.position.z);
    }
}