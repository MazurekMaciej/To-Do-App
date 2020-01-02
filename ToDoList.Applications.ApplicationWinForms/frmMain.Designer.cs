namespace ToDoList.Applications.ApplicationWinForms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.listTaskListButton = new System.Windows.Forms.Button();
            this.AddTaskListButton = new System.Windows.Forms.Button();
            this.UpdateTaskListButton = new System.Windows.Forms.Button();
            this.DeleteTaskListButton = new System.Windows.Forms.Button();
            this.TaskListNewName = new System.Windows.Forms.TextBox();
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.TaskListName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.selectedItem = new System.Windows.Forms.Label();
            this.DeleteTaskListItemButton = new System.Windows.Forms.Button();
            this.AddTaskListItemButton = new System.Windows.Forms.Button();
            this.ItemName = new System.Windows.Forms.TextBox();
            this.UpdateTaskListItemButton = new System.Windows.Forms.Button();
            this.ItemNewName = new System.Windows.Forms.TextBox();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemNewNameLabel = new System.Windows.Forms.Label();
            this.ItemIsCompletedUpdate = new System.Windows.Forms.CheckBox();
            this.ItemIsCompletedAdd = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.TaskListInfoLabel = new System.Windows.Forms.Label();
            this.taskList = new System.Windows.Forms.ListBox();
            this.ItemsGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCompletedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taskListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ShowDetailsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskListItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TaskLists";
            // 
            // listTaskListButton
            // 
            this.listTaskListButton.Location = new System.Drawing.Point(3, 53);
            this.listTaskListButton.Name = "listTaskListButton";
            this.listTaskListButton.Size = new System.Drawing.Size(110, 23);
            this.listTaskListButton.TabIndex = 2;
            this.listTaskListButton.Text = "Show task list";
            this.listTaskListButton.UseVisualStyleBackColor = true;
            this.listTaskListButton.Click += new System.EventHandler(this.listTaskListButton_Click);
            // 
            // AddTaskListButton
            // 
            this.AddTaskListButton.Location = new System.Drawing.Point(101, 298);
            this.AddTaskListButton.Name = "AddTaskListButton";
            this.AddTaskListButton.Size = new System.Drawing.Size(100, 23);
            this.AddTaskListButton.TabIndex = 6;
            this.AddTaskListButton.Text = "Add";
            this.AddTaskListButton.UseMnemonic = false;
            this.AddTaskListButton.UseVisualStyleBackColor = true;
            this.AddTaskListButton.Click += new System.EventHandler(this.AddTaskListButton_Click);
            // 
            // UpdateTaskListButton
            // 
            this.UpdateTaskListButton.Location = new System.Drawing.Point(101, 369);
            this.UpdateTaskListButton.Name = "UpdateTaskListButton";
            this.UpdateTaskListButton.Size = new System.Drawing.Size(100, 23);
            this.UpdateTaskListButton.TabIndex = 7;
            this.UpdateTaskListButton.Text = "Update";
            this.UpdateTaskListButton.UseVisualStyleBackColor = true;
            this.UpdateTaskListButton.Click += new System.EventHandler(this.UpdateTaskListButton_Click);
            // 
            // DeleteTaskListButton
            // 
            this.DeleteTaskListButton.Location = new System.Drawing.Point(252, 298);
            this.DeleteTaskListButton.Name = "DeleteTaskListButton";
            this.DeleteTaskListButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteTaskListButton.TabIndex = 8;
            this.DeleteTaskListButton.Text = "Delete";
            this.DeleteTaskListButton.UseVisualStyleBackColor = true;
            this.DeleteTaskListButton.Click += new System.EventHandler(this.DeleteTaskListButton_Click);
            // 
            // TaskListNewName
            // 
            this.TaskListNewName.Location = new System.Drawing.Point(101, 407);
            this.TaskListNewName.Name = "TaskListNewName";
            this.TaskListNewName.Size = new System.Drawing.Size(100, 20);
            this.TaskListNewName.TabIndex = 9;
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Location = new System.Drawing.Point(34, 410);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(61, 13);
            this.NewNameLabel.TabIndex = 10;
            this.NewNameLabel.Text = "New name:";
            // 
            // TaskListName
            // 
            this.TaskListName.Location = new System.Drawing.Point(101, 327);
            this.TaskListName.Name = "TaskListName";
            this.TaskListName.Size = new System.Drawing.Size(100, 20);
            this.TaskListName.TabIndex = 11;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(54, 330);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 12;
            this.NameLabel.Text = "Name: ";
            // 
            // selectedItem
            // 
            this.selectedItem.AutoSize = true;
            this.selectedItem.Location = new System.Drawing.Point(669, 268);
            this.selectedItem.Name = "selectedItem";
            this.selectedItem.Size = new System.Drawing.Size(0, 13);
            this.selectedItem.TabIndex = 13;
            // 
            // DeleteTaskListItemButton
            // 
            this.DeleteTaskListItemButton.Location = new System.Drawing.Point(529, 298);
            this.DeleteTaskListItemButton.Name = "DeleteTaskListItemButton";
            this.DeleteTaskListItemButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteTaskListItemButton.TabIndex = 14;
            this.DeleteTaskListItemButton.Text = "Delete";
            this.DeleteTaskListItemButton.UseVisualStyleBackColor = true;
            this.DeleteTaskListItemButton.Click += new System.EventHandler(this.DeleteTaskListItemButton_Click);
            // 
            // AddTaskListItemButton
            // 
            this.AddTaskListItemButton.Location = new System.Drawing.Point(704, 298);
            this.AddTaskListItemButton.Name = "AddTaskListItemButton";
            this.AddTaskListItemButton.Size = new System.Drawing.Size(100, 23);
            this.AddTaskListItemButton.TabIndex = 15;
            this.AddTaskListItemButton.Text = "Add";
            this.AddTaskListItemButton.UseMnemonic = false;
            this.AddTaskListItemButton.UseVisualStyleBackColor = true;
            this.AddTaskListItemButton.Click += new System.EventHandler(this.AddTaskListItemButton_Click);
            // 
            // ItemName
            // 
            this.ItemName.Location = new System.Drawing.Point(704, 330);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(100, 20);
            this.ItemName.TabIndex = 16;
            // 
            // UpdateTaskListItemButton
            // 
            this.UpdateTaskListItemButton.Location = new System.Drawing.Point(704, 369);
            this.UpdateTaskListItemButton.Name = "UpdateTaskListItemButton";
            this.UpdateTaskListItemButton.Size = new System.Drawing.Size(100, 23);
            this.UpdateTaskListItemButton.TabIndex = 17;
            this.UpdateTaskListItemButton.Text = "Update";
            this.UpdateTaskListItemButton.UseVisualStyleBackColor = true;
            this.UpdateTaskListItemButton.Click += new System.EventHandler(this.UpdateTaskListItemButton_Click);
            // 
            // ItemNewName
            // 
            this.ItemNewName.Location = new System.Drawing.Point(704, 403);
            this.ItemNewName.Name = "ItemNewName";
            this.ItemNewName.Size = new System.Drawing.Size(100, 20);
            this.ItemNewName.TabIndex = 18;
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(660, 333);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(38, 13);
            this.ItemNameLabel.TabIndex = 19;
            this.ItemNameLabel.Text = "Name:";
            // 
            // ItemNewNameLabel
            // 
            this.ItemNewNameLabel.AutoSize = true;
            this.ItemNewNameLabel.Location = new System.Drawing.Point(637, 405);
            this.ItemNewNameLabel.Name = "ItemNewNameLabel";
            this.ItemNewNameLabel.Size = new System.Drawing.Size(61, 13);
            this.ItemNewNameLabel.TabIndex = 20;
            this.ItemNewNameLabel.Text = "New name:";
            // 
            // ItemIsCompletedUpdate
            // 
            this.ItemIsCompletedUpdate.AutoSize = true;
            this.ItemIsCompletedUpdate.Location = new System.Drawing.Point(817, 404);
            this.ItemIsCompletedUpdate.Name = "ItemIsCompletedUpdate";
            this.ItemIsCompletedUpdate.Size = new System.Drawing.Size(93, 17);
            this.ItemIsCompletedUpdate.TabIndex = 21;
            this.ItemIsCompletedUpdate.Text = "Is Completed?";
            this.ItemIsCompletedUpdate.UseVisualStyleBackColor = true;
            // 
            // ItemIsCompletedAdd
            // 
            this.ItemIsCompletedAdd.AutoSize = true;
            this.ItemIsCompletedAdd.Location = new System.Drawing.Point(817, 302);
            this.ItemIsCompletedAdd.Name = "ItemIsCompletedAdd";
            this.ItemIsCompletedAdd.Size = new System.Drawing.Size(93, 17);
            this.ItemIsCompletedAdd.TabIndex = 22;
            this.ItemIsCompletedAdd.Text = "Is Completed?";
            this.ItemIsCompletedAdd.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "This Item will be deleted/updated -->";
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(349, 410);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(115, 31);
            this.logOutButton.TabIndex = 24;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // TaskListInfoLabel
            // 
            this.TaskListInfoLabel.AutoSize = true;
            this.TaskListInfoLabel.Location = new System.Drawing.Point(199, 268);
            this.TaskListInfoLabel.Name = "TaskListInfoLabel";
            this.TaskListInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.TaskListInfoLabel.TabIndex = 25;
            // 
            // taskList
            // 
            this.taskList.FormattingEnabled = true;
            this.taskList.Location = new System.Drawing.Point(146, 9);
            this.taskList.Name = "taskList";
            this.taskList.ScrollAlwaysVisible = true;
            this.taskList.Size = new System.Drawing.Size(271, 238);
            this.taskList.TabIndex = 26;
            this.taskList.SelectedIndexChanged += new System.EventHandler(this.taskList_SelectedIndexChanged_1);
            // 
            // ItemsGridView
            // 
            this.ItemsGridView.AllowUserToAddRows = false;
            this.ItemsGridView.AllowUserToDeleteRows = false;
            this.ItemsGridView.AutoGenerateColumns = false;
            this.ItemsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.isCompletedDataGridViewCheckBoxColumn,
            this.taskListDataGridViewTextBoxColumn});
            this.ItemsGridView.DataSource = this.taskListItemBindingSource;
            this.ItemsGridView.Location = new System.Drawing.Point(534, 9);
            this.ItemsGridView.MultiSelect = false;
            this.ItemsGridView.Name = "ItemsGridView";
            this.ItemsGridView.ReadOnly = true;
            this.ItemsGridView.RowHeadersVisible = false;
            this.ItemsGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsGridView.ShowEditingIcon = false;
            this.ItemsGridView.Size = new System.Drawing.Size(363, 235);
            this.ItemsGridView.TabIndex = 28;
            this.ItemsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsGridView_CellClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCompletedDataGridViewCheckBoxColumn
            // 
            this.isCompletedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isCompletedDataGridViewCheckBoxColumn.DataPropertyName = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.HeaderText = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.Name = "isCompletedDataGridViewCheckBoxColumn";
            this.isCompletedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCompletedDataGridViewCheckBoxColumn.Width = 80;
            // 
            // taskListDataGridViewTextBoxColumn
            // 
            this.taskListDataGridViewTextBoxColumn.DataPropertyName = "TaskList";
            this.taskListDataGridViewTextBoxColumn.HeaderText = "TaskList";
            this.taskListDataGridViewTextBoxColumn.Name = "taskListDataGridViewTextBoxColumn";
            this.taskListDataGridViewTextBoxColumn.ReadOnly = true;
            this.taskListDataGridViewTextBoxColumn.Visible = false;
            // 
            // taskListItemBindingSource
            // 
            this.taskListItemBindingSource.DataSource = typeof(ToDoList.Lib.Common.DomainModel.TaskListItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "This List will be deleted/updated -->";
            // 
            // ShowDetailsButton
            // 
            this.ShowDetailsButton.Location = new System.Drawing.Point(518, 354);
            this.ShowDetailsButton.Name = "ShowDetailsButton";
            this.ShowDetailsButton.Size = new System.Drawing.Size(122, 23);
            this.ShowDetailsButton.TabIndex = 30;
            this.ShowDetailsButton.Text = "Show item\'s details";
            this.ShowDetailsButton.UseVisualStyleBackColor = true;
            this.ShowDetailsButton.Click += new System.EventHandler(this.ShowDetailsButton_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.ShowDetailsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ItemsGridView);
            this.Controls.Add(this.taskList);
            this.Controls.Add(this.TaskListInfoLabel);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemIsCompletedAdd);
            this.Controls.Add(this.ItemIsCompletedUpdate);
            this.Controls.Add(this.ItemNewNameLabel);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.ItemNewName);
            this.Controls.Add(this.UpdateTaskListItemButton);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.AddTaskListItemButton);
            this.Controls.Add(this.DeleteTaskListItemButton);
            this.Controls.Add(this.selectedItem);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TaskListName);
            this.Controls.Add(this.NewNameLabel);
            this.Controls.Add(this.TaskListNewName);
            this.Controls.Add(this.DeleteTaskListButton);
            this.Controls.Add(this.UpdateTaskListButton);
            this.Controls.Add(this.AddTaskListButton);
            this.Controls.Add(this.listTaskListButton);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "ToDoApplication";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskListItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button listTaskListButton;
        private System.Windows.Forms.Button AddTaskListButton;
        private System.Windows.Forms.Button UpdateTaskListButton;
        private System.Windows.Forms.Button DeleteTaskListButton;
        private System.Windows.Forms.TextBox TaskListNewName;
        private System.Windows.Forms.Label NewNameLabel;
        private System.Windows.Forms.TextBox TaskListName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label selectedItem;
        private System.Windows.Forms.Button DeleteTaskListItemButton;
        private System.Windows.Forms.Button AddTaskListItemButton;
        private System.Windows.Forms.TextBox ItemName;
        private System.Windows.Forms.Button UpdateTaskListItemButton;
        private System.Windows.Forms.TextBox ItemNewName;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemNewNameLabel;
        private System.Windows.Forms.CheckBox ItemIsCompletedUpdate;
        private System.Windows.Forms.CheckBox ItemIsCompletedAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Label TaskListInfoLabel;
        private System.Windows.Forms.ListBox taskList;
        private System.Windows.Forms.DataGridView ItemsGridView;
        private System.Windows.Forms.BindingSource taskListItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCompletedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskListDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShowDetailsButton;
    }
}