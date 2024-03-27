using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float forceMag;
    [SerializeField] private float speed;

    [SerializeField] GameObject lan1Cube;
    [SerializeField] GameObject lan2Cube;
    [SerializeField] GameObject lan3Cube;
    [SerializeField] Animator animController;
    [SerializeField] Transform attackPoint; // Reference to the Attack_point transform
    private Vector3[] lanePos;

    int currentLaneIndex;
    int targetIndex;

    void Start()
    {
        Debug.Log("Start");
        lanePos = new Vector3[3];

        currentLaneIndex = 1;
        lanePos[0] = lan1Cube.transform.position;
        lanePos[1] = lan2Cube.transform.position;
        lanePos[2] = lan3Cube.transform.position;

        UpdateAttackPointPosition(); // Initial position setup
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLaneIndex != 0)
                targetIndex = currentLaneIndex - 1;

            currentLaneIndex = targetIndex;

            UpdateAttackPointPosition(); // Update Attack_point position when changing lanes
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLaneIndex != 2)
                targetIndex = currentLaneIndex + 1;

            currentLaneIndex = targetIndex;

            UpdateAttackPointPosition(); // Update Attack_point position when changing lanes
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetBool("Jump", true);
        }
        else if (!Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetBool("Jump", false);
        }

        var step = speed * Time.deltaTime; // Calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, lanePos[targetIndex], step);
    }

    // Function to update the position of the Attack_point based on the current lane
    void UpdateAttackPointPosition()
    {
        // Set the Attack_point's position to be aligned with the current lane's position
        Vector3 newPosition = lanePos[currentLaneIndex];
        newPosition.y = attackPoint.position.y; // Maintain the same height as before
        attackPoint.position = newPosition;
    }
}
