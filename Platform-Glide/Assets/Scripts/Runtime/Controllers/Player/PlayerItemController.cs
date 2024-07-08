using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemController : MonoBehaviour
{
    public Button buton;
    public int selectedItem;
    private ControllerEnum _controllerEnum;
    public int value;

    private void Start()
    {
        buton.onClick.AddListener(tikla);
    }

    public void tikla()
    {
        if (_controllerEnum == ControllerEnum.Close)
        {
            UISignals.Instance.onGetCupText?.Invoke(-50);

            _controllerEnum = ControllerEnum.Open;

              if (_controllerEnum == ControllerEnum.Open)
                CoreGameSignals.Instance.nnn?.Invoke(selectedItem);
        }

        else if (_controllerEnum == ControllerEnum.Open)
            CoreGameSignals.Instance.nnn?.Invoke(selectedItem);
    }
}