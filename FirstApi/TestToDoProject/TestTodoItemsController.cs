using FirstApi.Controllers;
using FirstApi.Data;
using FirstApi.Models;
using Moq;

namespace TestToDoProject;

[TestClass]
public class TestTodoItemsController
{
    [TestMethod]
    public async Task GetAllProducts_ShouldReturnAllProducts()
    {
        //Arrange
        var mock = new Mock<ITodoItemRepository>();
        mock.Setup(a => a.GetTodos().Result).Returns(GetTestTodos());
        var controller = new ToDoItemsController(mock.Object);

        var result = await controller.GetTodoItems();

        Assert.AreEqual(GetTestTodos().Count, result.Value.Count());
    }

    [TestMethod]
    public void GetTodoOTem_ShouldReturnCorrectProduct()
    {
        long id = 2;
        var mock = new Mock<ITodoItemRepository>();
        mock.Setup(a => a.GetTodoByID(id).Result).Returns(GetTestTodos().First(t=>t.Id==id));
        var controller = new ToDoItemsController(mock.Object);

        var result = controller.GetToDoItem(id).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(GetTestTodos().First(t => t.Id == id).Name, result.Value?.Name);
    }
    
    [TestMethod]
    public void GetTodoItem_ShouldNotFindTodo()
    {
        long id = 5;
        var mock = new Mock<ITodoItemRepository>();
        mock.Setup(a => a.GetTodoByID(id).Result).Returns(GetTestTodos().Find(t => t.Id == id));
        var controller = new ToDoItemsController(mock.Object);

        var result = controller.GetToDoItem(id).Result;
        
        Assert.IsInstanceOfType(result.Result, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
    }
    
    //todo проверить методы Add, Update, Delete


    private List<ToDoItem> GetTestTodos()
    {
        var testProducts = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Name = "Demo1", IsComplete = true },
            new ToDoItem { Id = 2, Name = "Demo2", IsComplete = false },
            new ToDoItem { Id = 3, Name = "Demo3", IsComplete = false },
            new ToDoItem { Id = 4, Name = "Demo4", IsComplete = true }
        };

        return testProducts;
    }

}

