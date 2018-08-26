using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCTest.Tests
{
    [TestClass]
    public class _PagingPartialViewTest
    {
        [TestMethod]
        public void SetPagination_Init_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = null;
            _PagingPartialView.ClickedLinkType? clickedLinkType = null;
            int? activeLinkNumber = null;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(1, settings.PageNumber);
            Assert.AreEqual(1, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink1Active);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber2UsingSecondButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 2;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Second;
            int? activeLinkNumber = null;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(2, settings.PageNumber);
            Assert.AreEqual(2, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink2Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber2UsingNextButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 2;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Next;
            int? activeLinkNumber = 1;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(2, settings.PageNumber);
            Assert.AreEqual(2, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink2Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber3UsingThirdButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 3;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Third;
            int? activeLinkNumber = null;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(3, settings.PageNumber);
            Assert.AreEqual(3, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink3Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber3UsingNextButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 3;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Next;
            int? activeLinkNumber = 2;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(3, settings.PageNumber);
            Assert.AreEqual(3, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink3Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber2UsingPrevButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 2;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Prev;
            int? activeLinkNumber = 3;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(2, settings.PageNumber);
            Assert.AreEqual(2, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink2Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToPageNumber1UsingPrevButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 1;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Prev;
            int? activeLinkNumber = 2;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(1, settings.PageNumber);
            Assert.AreEqual(1, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink1Active);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToFirstPageUsingFirstButtonFromPageNumber3_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 1;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.First;
            int? activeLinkNumber = null;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(1, settings.PageNumber);
            Assert.AreEqual(1, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink1Active);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToFirstPageUsingPrevButtonFromPageNumber2_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 1;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Prev;
            int? activeLinkNumber = 2;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(1, settings.PageNumber);
            Assert.AreEqual(1, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink1Active);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToLastPageUsingSecondButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 8;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Second;
            int? activeLinkNumber = null;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(8, settings.PageNumber);
            Assert.AreEqual(2, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink2Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }

        [TestMethod]
        public void SetPagination_GoToLastPageUsingNextButton_ReturnsCorrectSettings()
        {
            // Arrange
            const int pageSize = 10;
            int recordCount = 75;
            int? pageNumber = 8;
            _PagingPartialView.ClickedLinkType? clickedLinkType = _PagingPartialView.ClickedLinkType.Next;
            int? activeLinkNumber = 1;

            // Act
            _PagingPartialView.Settings settings = _PagingPartialView.SetPagination(recordCount, pageSize, ref pageNumber, ref clickedLinkType, ref activeLinkNumber);

            // Assert
            Assert.IsNotNull(settings);
            Assert.AreEqual(8, settings.PageNumber);
            Assert.AreEqual(2, settings.ActiveLinkNumber);
            Assert.AreEqual(_PagingPartialView.activeText, settings.ActionLink2Active);
            Assert.AreNotEqual(_PagingPartialView.disabledText, settings.PrevDisabled);
            Assert.AreEqual(_PagingPartialView.disabledText, settings.NextDisabled);
        }
    }
}
