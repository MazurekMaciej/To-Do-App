using System;
using System.Windows.Forms;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWinForms
{
    class TaskListWinForm
    {
        ITaskListManager _taskListManager;
        ISecurityManager _securityManager;

        public TaskListWinForm(ITaskListManager taskListManager, ISecurityManager securityManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public void ShowTaskList()
        {
            ListBox taskList = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;

            User user = _securityManager.GetLoggedUser();
            var taskListDisplayed = _taskListManager.ListTaskLists(user);
            taskList.DisplayMember = "Name";
            taskList.ValueMember = "Id";
            taskList.DataSource = taskListDisplayed;
            taskList.SelectedIndex = -1;
        }

        public void AddTaskList()
        {
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;
            TextBox nameBox = Application.OpenForms["frmMain"].Controls["TaskListName"] as TextBox;
            if (nameBox.Text == "")
            {
                MessageBox.Show("Write a name of Task List");
            }
            else
            {
                TaskList taskList = new TaskList { Name = nameBox.Text, User = _securityManager.GetLoggedUser() };
                try
                {
                    _taskListManager.CreateTaskList(taskList);
                }
                catch (TaskListException e)
                {
                    MessageBox.Show(e.Message);
                }
                ShowTaskList();
            }
        }

        public void UpdateTaskList(int id)
        {
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;
            TextBox nameBox = Application.OpenForms["frmMain"].Controls["TaskListNewName"] as TextBox;

            int? userid = _securityManager.GetLoggedUserId();
            TaskList taskList = _taskListManager.GetTaskList(id);
            taskList.Name = nameBox.Text;
            _taskListManager.UpdateTaskList(taskList);
            ShowTaskList();
        }

        public void DeleteTaskList(int id)
        {
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;
            int? userid = _securityManager.GetLoggedUserId();
            TaskList taskList = _taskListManager.GetTaskList(id);

            try
            {
                _taskListManager.DeleteTaskList(taskList);
                ShowTaskList();
            }
            catch(TaskListException)
            {
                MessageBox.Show("You did not select anything");
            }
            catch
            {
                MessageBox.Show("You did not select anything");
            }            
        }
    }
}
