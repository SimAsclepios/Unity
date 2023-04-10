using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    public static void Spawn(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        if (!IsObjectAtPosition(position, 2f/*gameObject.collider.raidus*/));
            Instanciate(gameObject, position, rotation); 
    }

    public static Quaternion GetRotation_FromDirection(Vector3 start, Vector3 end)
    {
        Vector3 direction = end - start;
        Quaternion rotation = Quaternion.LookRotation(direction);
        return rotation;
    }

    public bool IsObjectAtPosition(Vector3 position, Vector2 detectionBoxSize, float detectionRadius)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, detectionBoxSize, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                float distance = Vector2.Distance(collider.transform.position, position);
                if (distance <= detectionRadius)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public bool IsObjectAtPosition(Vector3 position, float detectionRadius)
    {
        Collider2D collider = GetComponent<Collider2D>();
        Vector2 detectionBoxSize = collider.bounds.size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, detectionBoxSize, 0f);
        foreach (Collider2D otherCollider in colliders)
        {
            if (otherCollider.gameObject != gameObject)
            {
                float distance = Vector2.Distance(otherCollider.transform.position, position);
                if (distance <= detectionRadius)
                {
                    return true;
                }
            }
        }
        return false;
    }




}