using System.Collections.Generic;
using TaskSystemMain.Task;
using UnityEngine;

namespace TaskSystemMain
{
    public class TaskSystem : MonoBehaviour
    {
        [SerializeField] private Dictionary<int, TaskSystemMain.Task.Task> _taskList = new Dictionary<int, TaskSystemMain.Task.Task>();

        /*  Создать словарь, в который по Id будут записываться задачи, а после выполнения задачи она должна удалить себя и очитстить элемент словаря уменьшив словарь */
    }
}