using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance_;

    public static T Instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = (T)FindObjectOfType(typeof(T));
            }
            return instance_;
        }
    }

    protected void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
        }
        else if (instance_ != this)
        {
            Destroy(this);
        }
    }
}