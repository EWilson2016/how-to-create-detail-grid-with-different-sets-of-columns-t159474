using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDescriptorExample
{
    public class TaskViewModel
    {
        private List<ParentTaskData> _TaskData;

        public List<ParentTaskData> TaskData
        {
            get
            {
                if (_TaskData == null)
                {
                    _TaskData = new List<ParentTaskData>();
                    for (int i = 0; i < 10; i++)
                    {
                        ParentTaskData parentData = new ParentTaskData() { TaskGroup = "TaskGroup " + i, Number = i, List = new List<Object>() };
                        if (i % 2 == 0)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                parentData.List.Add(new Task() { Name = "Task " + j, Number = j, Ready = j % 2 != 0 });
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                parentData.List.Add(new MultipleTask() { SubNameOne = "Sub Task " + j, SubNameTwo = "Sub Task " + (j + 1), SubNumber = j, MultipleReady = j % 2 != 0 });
                            }
                        }
                        
                        _TaskData.Add(parentData);
                    }
                }
                return _TaskData;
            }
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool Ready { get; set; }
    }

    public class MultipleTask
    {
        public string SubNameOne { get; set; }
        public string SubNameTwo { get; set; }
        public int SubNumber { get; set; }
        public bool MultipleReady { get; set; }
    }

    public class ParentTaskData
    {
        public string TaskGroup { get; set; }
        public int Number { get; set; }
        public List<Object> List { get; set; }
    }
}
