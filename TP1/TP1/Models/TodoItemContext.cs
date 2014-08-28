// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoItemContext.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   Defines the TodoItemContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Models
{
    using System.Data.Entity;

    // You can add custom code to this file. Changes will not be overwritten.
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, add the following
    // code to the Application_Start method in your Global.asax file.
    // Note: this will destroy and re-create your database with every model change.
    // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TP1.Models.TodoItemContext>());

    /// <summary>
    ///     The todo item context.
    /// </summary>
    public class TodoItemContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TodoItemContext" /> class.
        /// </summary>
        public TodoItemContext()
            : base("name=DefaultConnection")
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the todo items.
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        ///     Gets or sets the todo lists.
        /// </summary>
        public DbSet<TodoList> TodoLists { get; set; }

        #endregion
    }
}