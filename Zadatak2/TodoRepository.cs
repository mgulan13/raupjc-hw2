using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak2
{
    /// <summary>
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// Repository does not fetch todoItems from the actual database,
        /// it uses in memory storage for this excersise.
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException();
            }

            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
        }

        public List<TodoItem> GetActive()
        {
            return GetFiltered(i => !i.IsCompleted);
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return GetFiltered(i => i.IsCompleted);
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item == null || item.IsCompleted)
            {
                return false;
            }

            item.MarkAsCompleted();
            return true;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item == null)
            {
                return false;
            }

            _inMemoryTodoDatabase.Remove(item);
            return true;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return null;
            }

            _inMemoryTodoDatabase.Remove(todoItem);
            _inMemoryTodoDatabase.Add(todoItem);

            return todoItem;
        }
    }
}
