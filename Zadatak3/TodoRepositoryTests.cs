using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace Zadatak3
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);

            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");

            repository.Add(todoItem);
            repository.Add(todoItem);
        }

        [TestMethod]
        public void RemoveItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");

            repository.Add(todoItem);
            bool returnValue = repository.Remove(todoItem.Id);

            Assert.AreEqual(0, repository.GetAll().Count);
            Assert.AreEqual(true, returnValue);
            Assert.IsTrue(repository.Get(todoItem.Id) == null);
        }

        [TestMethod]
        public void GetItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");

            repository.Add(todoItem);

            TodoItem item = repository.Get(todoItem.Id);
            Assert.AreEqual(todoItem, item);
        }

        [TestMethod]
        public void GetNonExistingItem()
        {
            ITodoRepository repository = new TodoRepository();
            TodoItem todoItem = new TodoItem("Groceries");

            TodoItem newItem = repository.Get(todoItem.Id);

            Assert.AreEqual(null, newItem);
        }

        [TestMethod]
        public void GetActiveItems()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Cloth");
            todoItem2.MarkAsCompleted();

            repository.Add(todoItem);
            repository.Add(todoItem2);

            Assert.AreEqual(1, repository.GetActive().Count);
        }

        [TestMethod]
        public void GetAllItems()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Cloth");
            todoItem2.MarkAsCompleted();

            repository.Add(todoItem);
            repository.Add(todoItem2);

            Assert.AreEqual(2, repository.GetAll().Count);
        }

        [TestMethod]
        public void GetCompletedItems()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            var todoItem2 = new TodoItem("Cloth");
            todoItem2.MarkAsCompleted();

            repository.Add(todoItem);
            repository.Add(todoItem2);

            Assert.AreEqual(1, repository.GetCompleted().Count);
        }

        [TestMethod]
        public void UpdateItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);

            todoItem.Text = "Cloth";
            repository.Update(todoItem);

            Assert.AreEqual("Cloth", repository.Get(todoItem.Id).Text);
        }

    }
}
