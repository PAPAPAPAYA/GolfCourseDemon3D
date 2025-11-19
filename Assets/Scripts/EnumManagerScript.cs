using UnityEngine;

public class EnumManagerScript : MonoBehaviour
{
    public enum SideType
    {
        None,
        Wall,
        WalledPath,
        WalledLeft,
        WalledRight,
        Open
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
