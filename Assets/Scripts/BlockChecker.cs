using UnityEngine;

public static class BlockChecker
{
    private const float VectorLens = 0.55f;
    
    public static bool CheckIsGrounded(Vector3 position)
    {
        return Physics.Raycast(position, Vector3.down, VectorLens);
    }

    public static bool HasWallInDirection(Vector3 position,Vector3 direction)
    {
        return Physics.Raycast(position, direction, VectorLens);
    }
    
    public static bool HasBlockInDirection(Vector3 position,Vector3 direction)
    {
        //
        // var forwardDownDirection = direction;
        // forwardDownDirection.y = -0.8f;
        //
        // var len = forwardDownDirection.magnitude;
        return Physics.Raycast(position + direction, Vector3.down, 1f);
    }
    
    public static void SnapPositionToInteger(Transform transform)
    {
        var pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);
        
        transform.position = pos;
    }
}