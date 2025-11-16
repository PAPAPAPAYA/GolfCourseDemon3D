using UnityEngine;

public class EnumManagerScript : MonoBehaviour
{
    public enum SideType
    {
        None,
        Wall,
        WalledPath
    };

    public enum Direction
    {
        None,
        Up,
        Right,
        Down,
        Left,
    }
}
