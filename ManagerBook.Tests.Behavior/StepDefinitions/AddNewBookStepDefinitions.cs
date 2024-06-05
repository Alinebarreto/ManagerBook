using System;
using TechTalk.SpecFlow;

namespace ManagerBook.Tests.Behavior.StepDefinitions
{
    [Binding]
    public class AddNewBookStepDefinitions
    {
        [Given(@"I have a new book")]
        public void GivenIHaveANewBook()
        {
            throw new PendingStepException();
        }

        [Given(@"there are (.*) book registered")]
        public void GivenThereAreBookRegistered(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"it is registered")]
        public void WhenItIsRegistered()
        {
            throw new PendingStepException();
        }

        [Then(@"it should be available in stock with (.*) items left")]
        public void ThenItShouldBeAvailableInStockWithItemsLeft(int p0)
        {
            throw new PendingStepException();
        }
    }
}
