using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public GameObject panel;
    
    public void OpenPanel()
    {
        Text text = this.gameObject.GetComponent<Text>();
        if(panel != null && text !=null)
        {
            
            bool isActive = panel.activeSelf;
            text.text = isActive ? "Upgrade" : "Cancel";
            panel.SetActive(!isActive);
        }
    }
}
