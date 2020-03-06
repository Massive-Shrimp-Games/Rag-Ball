using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class MenuItem : MonoBehaviour
{
    [SerializeField] private readonly Image image;

    public Vector3 Position
    {
        get { return gameObject.transform.position; }
    }

    [SerializeField] private MenuItem up;
    public MenuItem Up
    {
        set { up = value; }
        get { return up == null ? this : up.GetComponent<MenuItem>(); }
    }

    [SerializeField] private MenuItem down;
    public MenuItem Down
    {
        set { down = value; }
        get { return down == null ? this : down.GetComponent<MenuItem>(); }
    }

    [SerializeField] private MenuItem left;
    public MenuItem Left
    {
        set { left = value; }
        get { return left == null ? this : left.GetComponent<MenuItem>(); }
    }

    [SerializeField] private MenuItem right;
    public MenuItem Right
    {
        set { right = value; }
        get { return right == null ? this : right.GetComponent<MenuItem>(); }
    }

    abstract public MenuItem Navigate(InputValue inputValue);
    abstract public void Select(PlayerCursor cursor);
    public virtual void updateDisplay() {}
    public virtual Vector3 localScale() {
        return Vector3.one;
    }
}
