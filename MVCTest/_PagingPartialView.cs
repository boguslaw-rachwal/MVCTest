using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCTest
{
    public static class _PagingPartialView
    {
        public const string activeText = "active";
        public const string disabledText = "disabled";

        public enum ClickedLinkType
        {
            Prev,
            First,
            Second,
            Third,
            Next
        }

        public struct Settings
        {
            public int PageNumber { get; set; }
            public string PrevDisabled { get; set; }
            public string NextDisabled { get; set; }
            public int ActiveLinkNumber { get; set; }
            public int ActionLink1Number { get; set; }
            public string ActionLink1Active { get; set; }
            public string ActionLink1Disabled { get; set; }
            public int ActionLink2Number { get; set; }
            public string ActionLink2Active { get; set; }
            public string ActionLink2Disabled { get; set; }
            public int ActionLink3Number { get; set; }
            public string ActionLink3Active { get; set; }
            public string ActionLink3Disabled { get; set; }
        }

        public static Settings SetPagination(int recordCount, int pageSize, ref int? pageNumber, ref ClickedLinkType? clickedLinkType, ref int? activeLinkNumber)
        {
            Settings settings = new Settings();

            int pageCount = recordCount / pageSize;

            if (recordCount % pageSize > 0)
                pageCount++;

            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
                clickedLinkType = ClickedLinkType.First;
                activeLinkNumber = 1;
            }

            settings.PageNumber = pageNumber.Value;

            if (pageNumber == 1)
            {
                settings.PrevDisabled = disabledText;
                settings.NextDisabled = "";
            }

            if (pageNumber == pageCount) settings.NextDisabled = disabledText;

            int actionLink1Number = 0;
            int actionLink2Number = 0;
            int actionLink3Number = 0;

            string actionLink1Active = "";
            string actionLink2Active = "";
            string actionLink3Active = "";

            string actionLink1Disabled = "";
            string actionLink2Disabled = "";
            string actionLink3Disabled = "";

            if (clickedLinkType == ClickedLinkType.Prev)
            {
                switch (activeLinkNumber)
                {
                    case 1:
                    case 2:
                        clickedLinkType = ClickedLinkType.First;
                        break;
                    case 3:
                        clickedLinkType = ClickedLinkType.Second;
                        break;
                }
            }
            else if (clickedLinkType == ClickedLinkType.Next)
            {
                switch (activeLinkNumber)
                {
                    case 1:
                        clickedLinkType = ClickedLinkType.Second;
                        break;
                    case 2:
                    case 3:
                        clickedLinkType = ClickedLinkType.Third;
                        break;
                }
            }

            if (clickedLinkType == ClickedLinkType.First)
            {
                actionLink1Number = pageNumber.Value;
                actionLink2Number = pageNumber.Value + 1;
                actionLink3Number = pageNumber.Value + 2;

                actionLink1Active = activeText;
                activeLinkNumber = 1;

                if (pageNumber == pageCount)
                {
                    actionLink2Disabled = disabledText;
                    actionLink3Disabled = disabledText;
                }
                else if (pageNumber + 1 == pageCount)
                    actionLink3Disabled = disabledText;
            }
            else if (clickedLinkType == ClickedLinkType.Second)
            {
                actionLink1Number = pageNumber.Value - 1;
                actionLink2Number = pageNumber.Value;
                actionLink3Number = pageNumber.Value + 1;

                actionLink2Active = activeText;
                activeLinkNumber = 2;

                if (pageNumber == pageCount)
                    actionLink3Disabled = disabledText;
            }
            else if (clickedLinkType == ClickedLinkType.Third)
            {
                actionLink1Number = pageNumber.Value - 2;
                actionLink2Number = pageNumber.Value - 1;
                actionLink3Number = pageNumber.Value;

                actionLink3Active = activeText;
                activeLinkNumber = 3;
            }

            settings.ActiveLinkNumber = activeLinkNumber.Value;

            // link 1

            settings.ActionLink1Number = actionLink1Number;
            settings.ActionLink1Active = actionLink1Active;
            settings.ActionLink1Disabled = actionLink1Disabled;

            // link 2

            settings.ActionLink2Number = actionLink2Number;
            settings.ActionLink2Active = actionLink2Active;
            settings.ActionLink2Disabled = actionLink2Disabled;

            // link 3

            settings.ActionLink3Number = actionLink3Number;
            settings.ActionLink3Active = actionLink3Active;
            settings.ActionLink3Disabled = actionLink3Disabled;

            return settings;
        }
    }
}