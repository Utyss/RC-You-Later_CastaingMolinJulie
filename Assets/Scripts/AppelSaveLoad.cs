using UnityEngine;

public class AppelSaveLoad : MonoBehaviour
{
    
    // Update is called once per frame
    public void BoutonSave()
    {
        Timer.Save(); 
    }

    public void BoutonLoad()
    {
        Timer.Load();
    }
}
