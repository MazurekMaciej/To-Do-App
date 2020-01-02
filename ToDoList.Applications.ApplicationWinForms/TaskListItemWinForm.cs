using System;
using System.Windows.Forms;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWinForms
{
    class TaskListItemWinForm
    {
        ITaskListManager _taskListManager;
        ISecurityManager _securityManager;

        public TaskListItemWinForm(ITaskListManager taskListManager, ISecurityManager securityManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public void ShowTaskListItems(int id)
        {
            DataGridView itemsGridView = Application.OpenForms["frmMain"].Controls["ItemsGridView"] as DataGridView;

            TaskList taskList = _taskListManager.GetTaskList(id);
            var taskListItems = _taskListManager.ListTaskListItems(taskList);

            itemsGridView.DataSource = taskListItems;
            itemsGridView.ClearSelection();
        }

        public void AddTaskListItem()
        {
            ListView taskListItemView = Application.OpenForms["frmMain"].Controls["taskListItemList"] as ListView;
            TextBox nameBox = Application.OpenForms["frmMain"].Controls["ItemName"] as TextBox;
            CheckBox checkBox = Application.OpenForms["frmMain"].Controls["ItemIsCompletedAdd"] as CheckBox;
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;

            if (nameBox.Text != "")
            {
                int taskListId = int.Parse(taskListBox.SelectedValue.ToString());
                TaskList taskList = _taskListManager.GetTaskList(taskListId);
                TaskListItem taskListItem = new TaskListItem { Text = nameBox.Text, IsCompleted = checkBox.Checked, TaskList = taskList };
                _taskListManager.CreateTaskListItem(taskListItem);
            }
            else
            {
                MessageBox.Show("Don't add a blank Item");
            }
            int tListId = int.Parse(taskListBox.SelectedValue.ToString());
            ShowTaskListItems(tListId);
        }

        public void UpdateTaskListItem(int id)
        {
            TextBox nameBox = Application.OpenForms["frmMain"].Controls["ItemNewName"] as TextBox;
            CheckBox checkBox = Application.OpenForms["frmMain"].Controls["ItemIsCompletedUpdate"] as CheckBox;
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;
            DataGridView itemsGridView = Application.OpenForms["frmMain"].Controls["ItemsGridView"] as DataGridView;
            TaskListItem currentObject = (TaskListItem)itemsGridView.CurrentRow.DataBoundItem;

            if (nameBox.Text != "")
            {
                int TaskListId = int.Parse(taskListBox.SelectedValue.ToString());
                TaskList taskList = _taskListManager.GetTaskList(TaskListId);

                int ItemId = currentObject.Id;
                TaskListItem taskListItem = new TaskListItem {Id= ItemId, Text = nameBox.Text, IsCompleted = checkBox.Checked, TaskList = taskList };
                try
                {
                    _taskListManager.UpdateTaskListItem(taskListItem);
                }
                catch (TaskListItemException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch
                {
                    MessageBox.Show("There is nothing selected to update");
                }
            }
            else
            {
                MessageBox.Show("Don't add a blank Item");
            }
        }

        public void DeleteTaskListItem(int id)
        {
            ListBox taskListBox = Application.OpenForms["frmMain"].Controls["taskList"] as ListBox;
            DataGridView itemsGridView = Application.OpenForms["frmMain"].Controls["ItemsGridView"] as DataGridView;
            TaskListItem currentItemObject = (TaskListItem)itemsGridView.CurrentRow.DataBoundItem;

            int taskListId = int.Parse(taskListBox.SelectedValue.ToString());
            TaskList taskList = _taskListManager.GetTaskList(taskListId);
            int itemId = currentItemObject.Id;
            string text = currentItemObject.Text;
            bool completed = currentItemObject.IsCompleted;

            TaskListItem taskListItem = new TaskListItem { Id = itemId, Text = text, IsCompleted = completed, TaskList = taskList };
            try
            {
                _taskListManager.DeleteTaskListItem(taskListItem);
            }
            catch(TaskListItemException e)
            {
                MessageBox.Show(e.Message);
            }
            catch
            {
                MessageBox.Show("There is nothing selected to delete");
            }
        }

        public void ShowDetails(string text)
        {
            MessageBox.Show(text);
        }

    }
}
