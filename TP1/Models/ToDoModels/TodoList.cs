// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoList.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   Todo list entity
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.ToDoModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Todo list entity
    /// </summary>
    public class TodoList
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the todo list id.
        /// </summary>
        public int TodoListId { get; set; }

        /// <summary>
        ///     Gets or sets the todos.
        /// </summary>
        public virtual List<TodoItem> Todos { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        #endregion
    }
}