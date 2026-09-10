using UnityEngine;
using UnityEngine.UIElements;

public class CalcScript : MonoBehaviour
{
    private PanelRenderer panelRenderer;
    //private extField Solution;
    private Button oneButton;
    private Button twoButton;


    //calculator buttons
    private Button pressedButton;
    private void OnEnable()
    {
        panelRenderer = GetComponent<PanelRenderer>();

        // Registreer een callback die wordt uitgevoerd wanneer de UI
        // is geladen of opnieuw wordt geladen.
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    private void OnDisable()
    {
        // Stop met luisteren naar het laden of opnieuw laden van de UI.
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);

        // Verwijder ook onze callbacks van de UI-elementen.
        UnregisterCallbacks();
    }

    // Deze methode wordt aangeroepen wanneer de UI door de PanelRenderer is geladen.
    // rootElement is het bovenste element van onze geladen UXML-layout.
    private void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
    {
        // Q<T>() zoekt in de UI naar een element van het opgegeven type
        // en met de opgegeven naam.
        // Deze namen hebben we eerder in de UI Builder ingesteld.
        oneButton = rootElement.Q<Button>("1");

        // Verwijder eerst eventuele oude callbacks om te voorkomen dat dezelfde
        // callback meerdere keren geregistreerd staat als de UI opnieuw wordt geladen.
        UnregisterCallbacks();

        // Registreer de callbacks op de zojuist gevonden UI-elementen.
        RegisterCallbacks();
    }

    private void RegisterCallbacks()
    {
        // Voer OnOneButtonPress uit wanneer op de button wordt geklikt.
        oneButton.clicked += OnOneButtonPress;
    }

    private void UnregisterCallbacks()
    {
        // Controleer eerst of de button al gevonden en opgeslagen is.
        if (oneButton != null)
        {
            // Verwijder de eerder geregistreerde callback van de button.
            oneButton.clicked -= OnOneButtonPress;
        }
    }

    private void OnOneButtonPress()
    {
        Debug.Log("1 button pressed");
    }
}
