using UnityEngine;


public class CupFinderManager : MonoBehaviour
{
    [SerializeField] private Material cupGreenMaterial;
    [SerializeField] private Material cupRedMaterial;

    public bool FindBall = false;
    private void Update()
    {
        if(FindBall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 200))
                {
                    if (hit.collider != null && hit.collider.CompareTag("Cup"))
                    {
                        if (hit.transform.childCount > 0)
                        {
                            Renderer renderer = hit.transform.GetComponent<Renderer>();
                            renderer.material = cupGreenMaterial;
                            FindBall = false;
                            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
                        }
                        else
                        {
                            Renderer renderer = hit.transform.GetComponent<Renderer>();
                            renderer.material = cupRedMaterial;
                            FindBall = false;
                            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
                        }
                    }
                }
            }
        }      
    }

    private void OnFindBall(bool ss) => FindBall = ss;
    private void OnReset() => FindBall = false;

    private void OnEnable() => SubscribeEvents();
    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onFindBall += OnFindBall;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onFindBall -= OnFindBall;
        CoreGameSignals.Instance.onReset -= OnReset;
    }
    private void OnDisable() => UnsubscribeEvents();
}