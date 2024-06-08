using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing; // suavizar o efeito da câmera
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public ColorBlindFilter filter;

    void Start()
    {
        filter = GetComponent<ColorBlindFilter>();
    }

    void LateUpdate()
    {
        if(transform.position != target.position){
            // A câmera segue o personagem em x e y
            Vector3 targetPosition = new 
            Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

            // restringe o valor entre os dois intervalos x e y
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Transição gradual da câmera (a + (b-a)t = a(1-t) -bt, portanto t=1 retorna targetPosition e t=0 retorna transform.position)
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}