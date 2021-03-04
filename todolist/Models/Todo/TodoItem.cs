using System;
using System.Collections.Generic;
using todolist.Exceptions;

namespace todolist.Models.Todo
{
    public class TodoItem : ModelBase
    {
        public TodoItem(string title, string content, string userId)
        {
            if (title.Length > 30)
            {
                throw new BusinessException("Name should be less than 10 symbols");
            }

            Title = title;
            Content = content;
            UserId = userId;
            Status = TodoItemStatus.InProgress;
            Added = DateTime.Now;
            // Tags = new List<TodoItemTag>();
            Tags = new List<string>();
            SetUpdated();
        }
        public string Title { get; }
        public string Content { get; }
        public string UserId { get; }
        public TodoItemStatus Status { get; private set; }
        public DateTime Added { get; }
        public DateTime Updated { get; private set; }
        // public List<TodoItemTag> Tags { get; }
        public List<string> Tags { get; private set; }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
            SetUpdated();
        }

        private void SetUpdated()
        {
            Updated = DateTime.Now;
        }

        public void SetTodoInProgress()
        {
            Status = TodoItemStatus.InProgress;
        }

        public void SetTodoDone()
        {
            Status = TodoItemStatus.Done;
        }

        public void ToggleDone()
        {
            Status = Status == TodoItemStatus.Done ? TodoItemStatus.InProgress : TodoItemStatus.Done;
        }
    }
}