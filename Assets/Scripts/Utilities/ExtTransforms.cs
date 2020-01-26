using UnityEngine;

public static class Transforms
{

    public static void DestroyChildren(this Transform t, bool detsroyImmediately = false)
    {
        foreach(Transform child in t){
            if(detsroyImmediately)
                MonoBehaviour.DestroyImmediate(child.gameObject);
            else
                MonoBehaviour.Destroy(child.gameObject);
        }
    }

}