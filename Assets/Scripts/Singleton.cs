using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    // https://www.youtube.com/watch?v=TuT3V4cfijQ&t=447s
    public bool dontDestroy = false;

    static T m_instance;

    public static T Instance{
        get{
            if(!m_instance){
                m_instance = GameObject.FindObjectOfType<T>();

                if(!m_instance){
                    GameObject Singleton = new GameObject(typeof(T).Name);
                    m_instance=Singleton.AddComponent<T>();
                }
            }
            return m_instance;
        }

    }

    public virtual void Awake(){
        if(!m_instance){
            m_instance = this as T;
            if(dontDestroy){
                transform.parent = null;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else{
            Destroy(gameObject);
        }
    }
}
