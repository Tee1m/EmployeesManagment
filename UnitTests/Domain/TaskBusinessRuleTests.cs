using Domain;
using Domain.Task;
using Domain.Task.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.Domain
{
    public class TaskTests
    {
        public static IEnumerable<object[]> TestGetTaskStates =>
            new List<object[]>
            {
                new object[] { TaskState.New, new List<TaskState> { TaskState.InProgress, TaskState.Canceled }, 2 },
                new object[] { TaskState.InProgress, new List<TaskState> { TaskState.ToSpecify, TaskState.ToTest }, 2 },
                new object[] { TaskState.ReOpened, new List<TaskState> { TaskState.InProgress, TaskState.Canceled }, 2 },
                new object[] { TaskState.ToTest, new List<TaskState> { TaskState.Completed, TaskState.ReOpened }, 2 },
                new object[] { TaskState.ToSpecify, new List<TaskState> { TaskState.Canceled, TaskState.ReOpened }, 2 },
                new object[] { TaskState.Completed, new List<TaskState> { TaskState.Canceled, TaskState.ReOpened }, 2 },
                new object[] { TaskState.Canceled, new List<TaskState> { TaskState.ReOpened }, 1 }
            };

        readonly string _title = "Testowy tytuł";
        readonly string _content = "Lorem Ipsum... i takie tam :)";
        readonly TaskState _currentState = TaskState.New;

        [Fact]
        public void Task_WhoObeysAllRules_WillBeCreated()
        {
            //when
            //given
            var task = Task.Create(_title, _content, _currentState);

            //then
            Assert.NotNull(task);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", null)]
        [InlineData("", "", TaskState.New)]
        [InlineData("", "content", TaskState.Completed)]
        [InlineData("Title", "content", null)]
        [InlineData("Title", "", TaskState.Completed)]
        public async void Task_MustHave_AllValues(string title, string content, TaskState currentState)
        {
            //when
            //given
            Func<System.Threading.Tasks.Task> act = async () => Task.Create(title, content, currentState);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }

        [Theory]
        [MemberData(nameof(TestGetTaskStates))]
        public void StateMachine_WorksPropely(TaskState current, List<TaskState> expectedStates, int length)
        {
            //when
            var task = Task.Create(_title, _content, current);

            //given
            var throwedStates = task.GetNextStates();
            int throwedListCount = throwedStates.Count();

            //then
            Assert.True(length == throwedListCount);

            foreach (var state in expectedStates)
            {
                Assert.True(task.ChangeState(state));
                Assert.True(task.CurrentState == state);
            }
        }

    }
}
