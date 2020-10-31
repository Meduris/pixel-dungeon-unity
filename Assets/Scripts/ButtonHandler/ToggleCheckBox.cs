using UnityEngine;
using UnityEngine.UI;

public class ToggleCheckBox : MonoBehaviour
{
    public Sprite checkedImg;
    public Sprite uncheckedImg;

    public GameObject checkBox;
    public ValueAccessor checkBoxState;

    private void OnEnable()
    {
        UpdateCheckBox();
    }

    public void toggleCheckBox()
    {
        var ticked = !checkBoxState.GetValue<bool>();
        checkBoxState.SetValue(ticked);
        UpdateCheckBox();
    }

    private void UpdateCheckBox()
    {
        checkBox.GetComponent<Image>().sprite = checkBoxState.GetValue<bool>() ? checkedImg : uncheckedImg;
    }
}