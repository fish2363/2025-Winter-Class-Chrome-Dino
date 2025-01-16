using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 5;
    private float scrollRange = 17.5f;

    public Transform target;

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x <= -scrollRange)
            transform.position = target.position + Vector3.right * scrollRange;
    }
}
