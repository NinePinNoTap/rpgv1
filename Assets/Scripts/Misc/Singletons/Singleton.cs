using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
 
                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("Multiple " + typeof(T) + " found.");
                        return _instance;
                    }
 
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString();
 
                        DontDestroyOnLoad(singleton);
 
                        Debug.Log("New " + typeof(T) + " created.");
                    }
                    else
                    {
                        Debug.Log("Using previous instance of " + typeof(T) + " : " + _instance.gameObject.name + ".");
                    }
                }
 
                return _instance;
            }
        }
    }
}