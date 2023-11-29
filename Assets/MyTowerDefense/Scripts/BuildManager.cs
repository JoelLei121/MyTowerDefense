using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private TurretBlueprint TurretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BulidManager!!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private void Start()
    {
        TurretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
        selectedNode = null;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return TurretToBuild;
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        TurretToBuild = null;

        nodeUI.SetTarget(node);
        
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public bool CanBuild{ get { return TurretToBuild != null; } }

    public bool EnoughMoney { get { return PlayerStats.Money >= TurretToBuild.cost; } }
}
