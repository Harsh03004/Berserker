using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool shouldMove = true;
    public float distance = 0;
    private void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }

    public  void Move()
    {
        float movement = speed * Time.deltaTime;
        transform.Translate(Vector3.left * movement);
        distance += movement;
    }

    public void StopMovement()
    {
        shouldMove = false;
    }
}
