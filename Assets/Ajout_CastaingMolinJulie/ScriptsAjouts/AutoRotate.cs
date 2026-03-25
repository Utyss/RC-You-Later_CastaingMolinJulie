using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 100);
    public float speed = 2f;
    public float hauteur = 0.5f;

    private Vector3 startPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * hauteur;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
