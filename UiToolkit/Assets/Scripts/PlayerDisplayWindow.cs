using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Json;

public class PlayerDisplayWindow : MonoBehaviour
{

    // Een UI Document voeg je toe als een VisualTreeAsset in de inspector.
    [SerializeField] private VisualTreeAsset rowAsset;

    private PanelRenderer panelRenderer;
    private ScrollView scrollView;
    private Button refreshButton;
    public Entries entries;
    public Label nameLabel;
    public Label scoreLabel;
    public Label favoriteLabel;


    private void OnEnable()
    {
        panelRenderer = GetComponent<PanelRenderer>();
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
        entries = JsonUtility.FromJson<Entries>(json);
    }

    private void OnDisable()
    {
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);
        UnregisterCallbacks();
    }

    private void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
    {
        scrollView = rootElement.Q<ScrollView>("PlayerListScrollView");
        refreshButton = rootElement.Q<Button>("RefreshButton");


        UnregisterCallbacks();
        RegisterCallbacks();
    }

    private void RegisterCallbacks()
    {
        refreshButton.clicked += OnRefreshClicked;
    }

    private void UnregisterCallbacks()
    {
        if (refreshButton != null)
        {
            refreshButton.clicked -= OnRefreshClicked;
        }
    }

    private void OnRefreshClicked()
    {
        scrollView.Clear();

        for (int i = 0; i < entries.entries.Count; i++)
        {

            // Maak een nieuwe rij aan door de VisualTreeAsset te klonen
            VisualElement row = rowAsset.CloneTree();

            // Voeg de rij toe aan de ScrollView
            scrollView.Add(row);
            nameLabel = row.Q<Label>("FirstLabel");
            scoreLabel = row.Q<Label>("SecondLabel");
            favoriteLabel = row.Q<Label>("ThirdLabel");

            // Vul de labels met de gegevens van de speler
            nameLabel.text = entries.entries[i].username;
            scoreLabel.text = entries.entries[i].score.ToString();
            favoriteLabel.text = entries.entries[i].favoriteUnit;

        }
    }
    [System.Serializable]
    public class Entries
    {
        public List<PlayerData> entries;
    }

    [System.Serializable]
    public class PlayerData
    {
        public string username;
        public float score;
        public string favoriteUnit;
    }
    [TextArea(4, 10)] public string json;

  

}