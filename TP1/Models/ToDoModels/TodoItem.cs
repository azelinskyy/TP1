// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoItem.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   Todo item entity
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.ToDoModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///     Todo item entity
    /// </summary>
    public class TodoItem
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether is done.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the todo item id.
        /// </summary>
        public int TodoItemId { get; set; }

        /// <summary>
        ///     Gets or sets the todo list.
        /// </summary>
        public virtual TodoList TodoList { get; set; }

        /// <summary>
        ///     Gets or sets the todo list id.
        /// </summary>
        [ForeignKey("TodoList")]
        public int TodoListId { get; set; }

        #endregion
    }
}