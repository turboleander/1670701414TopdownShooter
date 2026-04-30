using UnityEngine;

public class AnotherObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"[AnotherObject] PersistentObject.publicDebugText: {PersistentObject.staticPublicDebugText}");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            PersistentObject.staticPublicDebugText = "B";
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PersistentObject.SetStaticPrivateText("C");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var persistentObject = GameObject.Find("PersistentObject").GetComponent<PersistentObject>();
            persistentObject.SetInstancePrivateText("D");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PersistentObject.GetInstance().instancePublicDebugText = "E";
        }
    }
}
