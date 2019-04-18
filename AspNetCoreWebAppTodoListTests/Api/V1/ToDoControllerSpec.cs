using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList;
using AspNetCoreWebAppTodoList.Api.V1;
using AspNetCoreWebAppTodoList.Model;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;

namespace AspNetCoreWebAppTodoListTests.Api.V1
{
    public abstract class ToDoControllerSpec   :Spec {
        protected TodoController _sut = new TodoController(TodoContext);
        protected static readonly ITodoContext TodoContext = A.Fake<ITodoContext>();

        public ToDoControllerSpec()
        {
        }
    }

    [TestFixture]
    public class If_GetAll_is_called : ToDoControllerSpec
    {
        private ActionResult<List<TodoItem>> _result;
        private List<TodoItem> _fakeToDoItems;

        protected override void EstablishContext()
        {
            _fakeToDoItems = new List<TodoItem> {new TodoItem()};
            A.CallTo(() => TodoContext.ToListAsync())
                .Returns(_fakeToDoItems);
        }

        protected override async Task BecauseOfAsync()
        {
            _result = await _sut.GetAll();
        }

        [Test]
        public void Should_all_ToDo_Items_be_Returned()
        {
            _result.Value.Should().ContainInOrder(_fakeToDoItems);
        }
    }
}
