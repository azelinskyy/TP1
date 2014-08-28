// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoItemDto.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The todo item dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.DTOs
{
    using System.ComponentModel.DataAnnotations;

    using Model.ToDoModels;

    /// <summary>
    ///     The todo item dto.
    /// </summary>
    public class TodoItemDto
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TodoItemDto" /> class.
        ///     Data transfer object for <see cref="TodoItem" />
        /// </summary>
        public TodoItemDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemDto"/> class.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public TodoItemDto(TodoItem item)
        {
            this.TodoItemId = item.TodoItemId;
            this.Title = item.Title;
            this.IsDone = item.IsDone;
            this.TodoListId = item.TodoListId;
        }

        #endregion

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
        [Key]
        public int TodoItemId { get; set; }

        /// <summary>
        ///     Gets or sets the todo list id.
        /// </summary>
        public int TodoListId { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The to entity.
        /// </summary>
        /// <returns>
        ///     The <see cref="TodoItem" />.
        /// </returns>
        public TodoItem ToEntity()
        {
            return new TodoItem
                       {
                           TodoItemId = this.TodoItemId, 
                           Title = this.Title, 
                           IsDone = this.IsDone, 
                           TodoListId = this.TodoListId
                       };
        }

        #endregion
    }
}