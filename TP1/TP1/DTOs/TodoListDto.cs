// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoListDto.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   Data transfer object for
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.DTOs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Model.ToDoModels;

    /// <summary>
    ///     Data transfer object for <see cref="TodoList" />
    /// </summary>
    public class TodoListDto
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TodoListDto" /> class.
        /// </summary>
        public TodoListDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoListDto"/> class.
        /// </summary>
        /// <param name="todoList">
        /// The todo list.
        /// </param>
        public TodoListDto(TodoList todoList)
        {
            this.TodoListId = todoList.TodoListId;
            this.UserId = todoList.UserId;
            this.Title = todoList.Title;
            this.Todos = new List<TodoItemDto>();
            foreach (TodoItem item in todoList.Todos)
            {
                this.Todos.Add(new TodoItemDto(item));
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the todo list id.
        /// </summary>
        [Key]
        public int TodoListId { get; set; }

        /// <summary>
        ///     Gets or sets the todos.
        /// </summary>
        public virtual List<TodoItemDto> Todos { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The to entity.
        /// </summary>
        /// <returns>
        ///     The <see cref="TodoList" />.
        /// </returns>
        public TodoList ToEntity()
        {
            var todo = new TodoList
                           {
                               Title = this.Title, 
                               TodoListId = this.TodoListId, 
                               UserId = this.UserId, 
                               Todos = new List<TodoItem>()
                           };
            foreach (TodoItemDto item in this.Todos)
            {
                todo.Todos.Add(item.ToEntity());
            }

            return todo;
        }

        #endregion
    }
}