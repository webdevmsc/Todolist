using System;
using System.Collections.Generic;
using todolist.Exceptions;

namespace todolist.Models.Todo
{
    public class TodoItem : ModelBase
    {
        public TodoItem(string title, string content, List<string> tags, string userId)
        {
            if (title.Length > 30)
            {
                throw new BusinessException("Name should be less than 30 symbols");
            }

            Title = title;
            Content = content;
            UserId = userId;
            Status = TodoItemStatus.InProgress;
            Added = DateTime.UtcNow;
            Updated = Added;
            Tags = tags;
        }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string UserId { get; }
        public TodoItemStatus Status { get; set; }
        public DateTime Added { get; }
        public DateTime Updated { get; private set; }
        public List<string> Tags { get; private set; }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
            SetUpdated();
        }

        public void SetUpdated()
        {
            Updated = DateTime.UtcNow;
        }

        public void Update(string title, string content, TodoItemStatus status, List<string> tags)
        {
            Title = title;
            Content = content;
            Status = status;
            Tags = tags;
            SetUpdated();
        }
    }
}