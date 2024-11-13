using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace island;

public partial class YapilacaklarListesiPage : ContentPage
{
    public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

    public YapilacaklarListesiPage()
    {
        InitializeComponent();

        
        BindingContext = this;
    }
    private async void OnAddTaskClicked(object sender, EventArgs e)
    {

        string taskName = await DisplayPromptAsync("Yeni Görev", "Görevinizi girin:");
        if (!string.IsNullOrEmpty(taskName))
        {

            Tasks.Insert(0, new TaskItem { TaskName = taskName, IsCompleted = false });
        }
    }


    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as TaskItem;
        if (selectedItem != null)
        {
            if (selectedItem.IsCompleted)
            {
                selectedItem.TaskName = $"✓ {selectedItem.TaskName}";
            }
            else
            {
                selectedItem.TaskName = selectedItem.TaskName.Replace("✓ ", "");
            }
        }
    }


    private async void OnEditTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.CommandParameter as TaskItem;

        if (task != null)
        {
           
            string newTaskName = await DisplayPromptAsync("Düzenle", "Görevinizi güncelleyin:", initialValue: task.TaskName);

            if (!string.IsNullOrEmpty(newTaskName))
            {
               
                task.TaskName = newTaskName;
            }
        }
    }


    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.CommandParameter as TaskItem;

        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        DisplayAlert("Başarıyla Kaydedildi", "Görevler başarıyla kaydedildi.", "Tamam");
    }
}


public class TaskItem : INotifyPropertyChanged
{
    private string _taskName;
    public string TaskName
    {
        get => _taskName;
        set
        {
            if (_taskName != value)
            {
                _taskName = value;
                OnPropertyChanged(nameof(TaskName));  
            }
        }
    }

    public bool IsCompleted { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



