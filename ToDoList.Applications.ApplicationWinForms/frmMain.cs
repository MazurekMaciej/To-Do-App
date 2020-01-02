using System;
using System.Windows.Forms;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using Unity;

namespace ToDoList.Applications.ApplicationWinForms
{
    public partial class FrmMain : Form
    {
        ITaskListManager _taskListManager;
        ISecurityManager _securityManager;

        public FrmMain(ITaskListManager taskListManager, ISecurityManager securityManager)
        {
            _taskListManager = taskListManager;
            _securityManager = securityManager;
            InitializeComponent();
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            FrmMain MainForm = DependencyResolver.Container.Resolve<FrmMain>();
        }

        private void taskList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TaskListItemWinForm taskListItemWinForm = DependencyResolver.Container.Resolve<TaskListItemWinForm>();
            if (taskList.SelectedValue != null)
            {
                int currentItem = int.Parse(taskList.SelectedValue.ToString());
                string s = ((TaskList)taskList.SelectedItem).Name;
                TaskListInfoLabel.Text = s;

               taskListItemWinForm.ShowTaskListItems(currentItem);
            }
            else
            {
                TaskListInfoLabel.Text = "";
            }
        }

        private void listTaskListButton_Click(object sender, EventArgs e)
        {
            TaskListWinForm taskListWinForm = DependencyResolver.Container.Resolve<TaskListWinForm>();
            taskListWinForm.ShowTaskList();
        }

        private void AddTaskListButton_Click(object sender, EventArgs e)
        {
            TaskListWinForm taskListWinForm = DependencyResolver.Container.Resolve<TaskListWinForm>();
            taskListWinForm.AddTaskList();
            TaskListName.Text = "";
        }


        private void UpdateTaskListButton_Click(object sender, EventArgs e)
        {
            TaskListWinForm taskListWinForm = DependencyResolver.Container.Resolve<TaskListWinForm>();
            if (taskList.SelectedItem != null)
            {
                int currentItem = (int)(taskList.SelectedValue);
                taskListWinForm.UpdateTaskList(currentItem);
            }
            else
            {
                MessageBox.Show("There is nothing selected");
            }
            TaskListNewName.Text = "";
        }

        private void DeleteTaskListButton_Click(object sender, EventArgs e)
        {
            TaskListWinForm taskListWinForm = DependencyResolver.Container.Resolve<TaskListWinForm>();
            if (taskList.SelectedItem != null)
            {
                int currentItem = (int)(taskList.SelectedValue);
                taskListWinForm.DeleteTaskList(currentItem);
            }
            else
            {
                MessageBox.Show("There is nothing selected");
            }
        }

        //Task List Item control

        private void AddTaskListItemButton_Click(object sender, EventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                int currentItem = (int)(taskList.SelectedValue);
                TaskListItemWinForm taskListItemWinForm = DependencyResolver.Container.Resolve<TaskListItemWinForm>();

                taskListItemWinForm.AddTaskListItem();
                ItemName.Text = "";
            }
            else
            {
                MessageBox.Show("There is no Task List selected");
            }
        }

        private void UpdateTaskListItemButton_Click(object sender, EventArgs e)
        {
            TaskListItemWinForm taskListItemWinForm = DependencyResolver.Container.Resolve<TaskListItemWinForm>();
            if (selectedItem.Text != "")
            {
                TaskListItem currentObject = (TaskListItem)ItemsGridView.CurrentRow.DataBoundItem;
                int currentItem = currentObject.Id;
                taskListItemWinForm.UpdateTaskListItem(currentItem);
                ItemNewName.Text = "";
                int currentTaskList= (int)(taskList.SelectedValue);
               taskListItemWinForm.ShowTaskListItems(currentTaskList);
            }
            else
            {
                 MessageBox.Show("There is no Task List Item selected");
            }
        }

        private void DeleteTaskListItemButton_Click(object sender, EventArgs e)
        {
            TaskListItemWinForm taskListItemWinForm = DependencyResolver.Container.Resolve<TaskListItemWinForm>();
            if (selectedItem.Text != "")
            {
                TaskListItem currentObject = (TaskListItem)ItemsGridView.CurrentRow.DataBoundItem;
                int currentItem = currentObject.Id;
                taskListItemWinForm.DeleteTaskListItem(currentItem);
                selectedItem.Text = "";
                int currentTaskList = (int)(taskList.SelectedValue);
                taskListItemWinForm.ShowTaskListItems(currentTaskList);
            }
            else
            {
                MessageBox.Show("There is no Task List Item selected");
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TaskListItem currentObject = (TaskListItem)ItemsGridView.CurrentRow.DataBoundItem;
            string text = currentObject.Text.ToString();

            if (string.IsNullOrEmpty(text)) selectedItem.Text = text;
            else
            selectedItem.Text = text.Length <= 25 ? text : text.Substring(0, 25) + "...";
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            if (ItemsGridView.CurrentRow != null)
            {
                TaskListItem currentObject = (TaskListItem)ItemsGridView.CurrentRow.DataBoundItem;
                string text = currentObject.Text.ToString();
                TaskListItemWinForm taskListItemWinForm = DependencyResolver.Container.Resolve<TaskListItemWinForm>();
                taskListItemWinForm.ShowDetails(text);
            }
            else
            {
                MessageBox.Show("Nothing to show");
            }
        }
    }
}
