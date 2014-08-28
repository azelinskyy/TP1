// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoListController.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The todo list controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Infrastructure.Contexts;

    using Model.ToDoModels;

    using TP1.DTOs;
    using TP1.Filters;

    /// <summary>
    ///     The todo list controller.
    /// </summary>
    [Authorize]
    public class TodoListController : ApiController
    {
        #region Fields

        /// <summary>
        ///     The db.
        /// </summary>
        private readonly TodoItemContext db = new TodoItemContext();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The delete todo list.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage DeleteTodoList(int id)
        {
            TodoList todoList = this.db.TodoLists.Find(id);
            if (todoList == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (this.db.Entry(todoList).Entity.UserId != this.User.Identity.Name)
            {
                // Trying to delete a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var todoListDto = new TodoListDto(todoList);
            this.db.TodoLists.Remove(todoList);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, todoListDto);
        }

        // GET api/TodoList
        // GET api/TodoList/5

        /// <summary>
        /// The get todo list.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TodoListDto"/>.
        /// </returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public TodoListDto GetTodoList(int id)
        {
            TodoList todoList = this.db.TodoLists.Find(id);
            if (todoList == null)
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            if (todoList.UserId != this.User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }

            return new TodoListDto(todoList);
        }

        /// <summary>
        ///     The get todo lists.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        public IEnumerable<TodoListDto> GetTodoLists()
        {
            return
                this.db.TodoLists.Include("Todos")
                    .Where(u => u.UserId == this.User.Identity.Name)
                    .OrderByDescending(u => u.TodoListId)
                    .AsEnumerable()
                    .Select(todoList => new TodoListDto(todoList));
        }

        // PUT api/TodoList/5
        // POST api/TodoList

        /// <summary>
        /// The post todo list.
        /// </summary>
        /// <param name="todoListDto">
        /// The todo list dto.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PostTodoList(TodoListDto todoListDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            todoListDto.UserId = this.User.Identity.Name;
            TodoList todoList = todoListDto.ToEntity();
            this.db.TodoLists.Add(todoList);
            this.db.SaveChanges();
            todoListDto.TodoListId = todoList.TodoListId;

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, todoListDto);

            // ReSharper disable once AssignNullToNotNullAttribute
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = todoListDto.TodoListId }));
            return response;
        }

        /// <summary>
        /// The put todo list.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="todoListDto">
        /// The todo list dto.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PutTodoList(int id, TodoListDto todoListDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            if (id != todoListDto.TodoListId)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            TodoList todoList = todoListDto.ToEntity();
            if (this.db.Entry(todoList).Entity.UserId != this.User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            this.db.Entry(todoList).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        // DELETE api/TodoList/5
        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}