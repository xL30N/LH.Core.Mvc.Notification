using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace LH.Core.Mvc.Notification
{
    public class NotificationTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected ITempDataDictionary TempData => ViewContext.TempData;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string[] messageTypes = Enum.GetNames(typeof(MessageType));

            string messages = string.Empty;

            string closeButton = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                "<span aria-hidden=\"true\">&times;</span></button>";

            foreach (string type in messageTypes)
            {
                string message = TempData.ContainsKey(type) ? TempData[type].ToString() : null;

                string style = "alert-info";
                switch (type)
                {
                    case "Success":
                        style = "alert-success";
                        break;
                    case "Error":
                        style = "alert-danger";
                        break;
                    case "Warning":
                        style = "alert-warning";
                        break;
                }

                if (!string.IsNullOrEmpty(message))
                {
                    string messageBox = "<div class=\"alert " + style + "\" role=\"alert\">" + message + closeButton + "</div>";

                    messages += messageBox.ToString();
                }
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent(messages);
        }
    }
}