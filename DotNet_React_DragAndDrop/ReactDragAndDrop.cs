using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ReactDropdown
{
    public class ReactDragAndDrop
    {
        public void DragAndDropExample(IWebElement source, IWebElement target, IWebDriver _driver)
        {
            Actions actions = new Actions(_driver);
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "function createEvent(typeOfEvent) {\n" +
                    "  var event = document.createEvent(\"CustomEvent\");\n" +
                    "  event.initCustomEvent(typeOfEvent, true, true, null);\n" +
                    "  event.dataTransfer = {\n" +
                    "    data: {},\n" +
                    "    setData: function (key, value) {\n" +
                    "      this.data[key] = value;\n" +
                    "    },\n" +
                    "    getData: function (key) {\n" +
                    "      return this.data[key];\n" +
                    "    }\n" +
                    "  };\n" +
                    "  return event;\n" +
                    "}\n" +
                    "\n" +
                    "function dispatchEvent(element, event, transferData) {\n" +
                    "  if (transferData !== undefined) {\n" +
                    "    event.dataTransfer = transferData;\n" +
                    "  }\n" +
                    "  if (element.dispatchEvent) {\n" +
                    "    element.dispatchEvent(event);\n" +
                    "  } else if (element.fireEvent) {\n" +
                    "    element.fireEvent(\"on\" + event.type, event);\n" +
                    "  }\n" +
                    "}\n" +
                    "\n" +
                    "var source = arguments[0];\n" +
                    "var target = arguments[1];\n" +
                    "var dragstartEvent = createEvent('dragstart');\n" +
                    "dispatchEvent(source, dragstartEvent);\n" +
                    "var dragoverEvent = createEvent('dragover');\n" +
                    "dispatchEvent(target, dragoverEvent);\n" +
                    "var dropEvent = createEvent('drop');\n" +
                    "dropEvent.dataTransfer = dragstartEvent.dataTransfer;\n" +
                    "dispatchEvent(target, dropEvent);\n" +
                    "var dragendEvent = createEvent('dragend');\n" +
                    "dragendEvent.dataTransfer = dropEvent.dataTransfer;\n" +
                    "dispatchEvent(source, dragendEvent);\n",
                    source, target);

            Console.WriteLine("Drag and drop successful!");
        }
    }
}
