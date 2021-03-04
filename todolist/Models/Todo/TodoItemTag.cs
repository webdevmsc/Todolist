using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace todolist.Models.Todo
{
    // public class TodoItemTag : ModelBase
    // {
    //     public TodoItemTag(string name)
    //     {
    //         Name = name;
    //         Status = new StatusActivity();
    //     }
    //
    //     public string Name { get; private set; }
    //     public StatusActivity Status { get; private set; }
    // }
    //
    // // public enum TagStatus
    // // {
    // //     New,
    // //     OnValidation,
    // //     Validated
    // // }
    // //
    // // public class StatusActivity
    // // {
    // //     public StatusActivity()
    // //     {
    // //         Status = TagStatus.Validated;
    // //     }
    // //     public TagStatus Status { get; private set; }
    // //     public bool IsActive => Status == TagStatus.Validated;
    // //
    // //     public void SetOnValidationStatus()
    // //     {
    // //         Status = TagStatus.OnValidation;
    // //     }
    // //
    // //     public void SetValidatedStatus()
    // //     {
    // //         Status = TagStatus.Validated;
    // //     }
    // // }
}