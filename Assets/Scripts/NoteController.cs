using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public Vector2 currentPosition;

    public Vector2[] linePositions = new Vector2[11];

    // Start is called before the first frame update
    void Start()
    {
        linePositions[0] = new Vector2(0, 1.5f);
        linePositions[1] = new Vector2(0, 1);
        linePositions[2] = new Vector2(0, 0.5f);
        linePositions[3] = new Vector2(0, 0);
        linePositions[4] = new Vector2(0, -0.5f);
        linePositions[5] = new Vector2(0, -1);
        linePositions[6] = new Vector2(0, -1.5f);
        linePositions[7] = new Vector2(0, -2);
        linePositions[8] = new Vector2(0, -2.5f);
        linePositions[9] = new Vector2(0, -3);
        linePositions[10] = new Vector2(0, -3.5f);
    }

    public float spacing = 0.5f; // spacing between staff lines

public void MoveNoteUp()
{
    currentPosition.y += spacing;
    SnapToNearestLine();
}

public void MoveNoteDown()
{
    currentPosition.y -= spacing;
    SnapToNearestLine();
}

private void SnapToNearestLine()
{
    float closestDistance = float.MaxValue;
    int closestIndex = 0;

    // Find the nearest line position to the current note position
    for (int i = 0; i < linePositions.Length; i++)
    {
        float distance = Vector2.Distance(currentPosition, linePositions[i]);
        if (distance < closestDistance)
        {
            closestDistance = distance;
            closestIndex = i;
        }
    }

    // Set the note position to the nearest line position
    currentPosition = linePositions[closestIndex];
    transform.position = currentPosition;
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
