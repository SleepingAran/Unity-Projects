using UnityEngine;
using System.Collections;
[RequireComponent (typeof (BoxCollider2D))]
public class DrawLine : MonoBehaviour {
    public LayerMask collisionMask;
    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D colliders;
    RayCastOrigin raycastOrigin;
    void Start()
    {
        colliders = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }
   

    void VerticalCollision(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1)?raycastOrigin.bottomLeft:raycastOrigin.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            Debug.DrawRay(raycastOrigin.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.green);

            if (hit)
            {
                velocity.y = (hit.distance -skinWidth)* directionY;
                rayLength = hit.distance;
            }
        }
    }

 void HorizontalCollision(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigin.bottomLeft : raycastOrigin.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i );
            RaycastHit2D hitRight = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
          
            Debug.DrawRay(raycastOrigin.bottomLeft + Vector2.up * horizontalRaySpacing * i, Vector2.right * -2, Color.green);
       
            if (hitRight)
            {
                velocity.x = (hitRight.distance - skinWidth) * directionX;
                rayLength = hitRight.distance;
            }
       
        }
    }
    void UpdateRayCastOrigin()
    {
        Bounds bounds = colliders.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigin.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigin.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigin.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigin.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = colliders.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public void Move(Vector3 velocity)
    { 
        UpdateRayCastOrigin();
        if (velocity.x != 0)
        {
            HorizontalCollision(ref velocity);
        }
        if (velocity.y != 0)
        {
            VerticalCollision(ref velocity);
        }
        transform.Translate(velocity);
    }
    struct RayCastOrigin
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
    
}
