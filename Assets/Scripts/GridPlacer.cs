using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QUIZ.Cells;
using QUIZ.Tasks;
using QUIZ.EvetsSO;
using UnityEngine.Events;

public class GridPlacer : MonoBehaviour
{
    [Header("Cell Amount Set & Get Froms Game Mode SO")]
    [SerializeField] private int cellsAmount;

    [Header("Current Active Task")]
    [SerializeField] private TaskVariableSO activeTaskVariableSO;

    [Header("Cell Prefab From Assets")]
    [SerializeField] private GameObject cellPrefab;

    [Header("Temp List of Cells")]
    [SerializeField] private List<Cell> InstantiatedCells = new List<Cell>();

    [Header("Custom Scriptable Events")]
    [SerializeField] private VoidEventSO OnRestartGame;

    [SerializeField] private TaskListEventSO OnTaskListSet;

    [SerializeField] private IntEventSO OnModeAmountCellsSet;
    [SerializeField] private VoidEventSO OnGridClear;
    [SerializeField] private VoidEventSO OnTaskCompleted;

    public UnityEvent ParticlesPlayEvent = new UnityEvent();

    private void OnEnable()
    {
        OnModeAmountCellsSet.OnEventRised += SetCellAmount;
        OnTaskListSet.OnEventRised += PopulateGrid;
        OnRestartGame.OnEventRised += ClearGrid;
        OnGridClear.OnEventRised += ClearGrid;
    }

    private void OnDisable()
    {
        OnModeAmountCellsSet.OnEventRised -= SetCellAmount;
        OnTaskListSet.OnEventRised -= PopulateGrid;
        OnRestartGame.OnEventRised -= ClearGrid;
        OnGridClear.OnEventRised += ClearGrid;

        UnsubscribeCellsEvents();
    }

    private void UnsubscribeCellsEvents()
    {
        for (var i = 0; i < InstantiatedCells.Count; i++)
        {
            InstantiatedCells[i].OnCellTaskSelected -= OnTaskSelectionChanged;
        }
    }

    public void SetCellAmount(int amount)
    {
        cellsAmount = amount;
    }

    public void PopulateGrid(List<TaskSO> taskSOList)
    {
        if(taskSOList == null)
        { 
            return;
        }

        for (var i = 0; i < cellsAmount; i++)
        {
            GameObject cell = Instantiate(cellPrefab, transform);
            Cell item = cell.GetComponent<Cell>();
            item.SetCellData(taskSOList[i]);
            item.OnCellTaskSelected += OnTaskSelectionChanged;
            InstantiatedCells.Add(item);
        }
    }

    public void ClearGrid()
    {
        if(InstantiatedCells == null) { return; }

        for (var i = 0; i < InstantiatedCells.Count; i++)
        {
            InstantiatedCells[i].OnCellTaskSelected -= OnTaskSelectionChanged;
            Destroy(InstantiatedCells[i].gameObject);
        }

        InstantiatedCells = new List<Cell>();
    }

    public void OnTaskSelectionChanged(ICell cell)
    {
        if(cell.GetTask() == activeTaskVariableSO.ActiveTaskSO)
        {
            cell.Bounce();
            ParticlesPlayEvent.Invoke();
            StartCoroutine(CellProcess());
            Debug.Log("Task selected right");
        }
        else
        {
            cell.EaseInBounce();
            Debug.Log("Task selected not right");
        }
    }

    private IEnumerator CellProcess()
    {
        yield return new WaitForSeconds(2f);
        OnTaskCompleted.RisedEvent();
    }
}