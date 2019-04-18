using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AspNetCoreWebAppTodoListTests
{
    [DebuggerStepThrough, DebuggerNonUserCode]
    public class Spec
    {
        private readonly List<Action> _dispose_actions = new List<Action>();


        [DebuggerStepThrough]
        [OneTimeSetUp]
        public async Task TestFixtureSetUp()
        {
            EstablishContext();
            await EstablishContextAsync();
            BecauseOf();
            await BecauseOfAsync();
        }

        [DebuggerStepThrough]
        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var dispose_action in _dispose_actions)
            {
                dispose_action();
            }
            Cleanup();
        }

        /// <summary>
        ///     Test setup. Place your initialization code here.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void EstablishContext()
        {
        }
        [DebuggerStepThrough]
        protected virtual Task EstablishContextAsync()
        {
            return Task.FromResult(0);
        }

        /// <summary>
        ///     Test run. Place the tested method / action here.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void BecauseOf()
        {
        }
        [DebuggerStepThrough]
        protected virtual Task BecauseOfAsync()
        {
            return Task.FromResult(0);
        }

        /// <summary>
        ///     Test clean. Close/delete files, close database connections ..
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void Cleanup()
        {
        }

        /// <summary>
        ///     Creates an Action delegate.
        /// </summary>
        /// <param name="func">Method the shall be created as delegate.</param>
        /// <returns>A delegate of type <see cref="Action" /></returns>
        protected Action Invoking(Action func)
        {
            return func;
        }

        protected void DisposeOnTearDown(IDisposable disposable)
        {
            _dispose_actions.Add(() => disposable?.Dispose());
        }
    }

}
