using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;

namespace UIAutomationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
          //  try
           // {

                var displayMsg = "This program reads the input from a JSON File, De - Serializes it and takes action as specified....";

                Console.WriteLine(displayMsg);

                // De-serialize the JSON into an object
                JSONDeSerializer deserializedJson = JsonConvert.DeserializeObject<JSONDeSerializer>(File.ReadAllText(@"C:\Users\Ayananta\Desktop\Input.json"));

                // Start the process        
                Process services = Process.Start(deserializedJson.appName);
                Thread.Sleep(5000);

                // Set the conditions to find out the Application
                PropertyCondition typeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);

                // Set the name condition read from the JSON Data
                PropertyCondition nameCondition = new PropertyCondition(AutomationElement.NameProperty, deserializedJson.appAutomationName);
                AndCondition andCondition = new AndCondition(typeCondition, nameCondition);

                // Get the root element
                AutomationElement rootElem = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCondition);

                foreach (var v in deserializedJson.events)
                {

                    // Set the automation id property for a specific element within the application
                    PropertyCondition findByAutoId = new PropertyCondition(AutomationElement.AutomationIdProperty, v.autoId);

                    // Find the element
                    AutomationElement subElem = rootElem.FindFirst(TreeScope.Descendants, findByAutoId);

                    // If the action specified in the JSON Data is click then invoke the button            
                    if (v.action.Equals("click"))
                    {
                        GetInvokePattern(subElem).Invoke();
                    }

                    // Display the name if anything returned            
                    Console.WriteLine(subElem.Current.Name);

                    // Display the type of the element
                    Console.WriteLine(subElem.Current.LocalizedControlType);
                }

                // If needed then we can  write the output in a json file also.
                // File.WriteAllText(@"C:\Users\Ayananta\Desktop\UI_Info.json", JsonConvert.SerializeObject(outPuts));

         //   } // TRY Ends

            //catch(Exception e)
            //{
            //    Console.WriteLine("Exception caught:" + e.Data);
            //}

            Console.ReadKey();

        } // MAIN Ends


        // This method invokes a control.
        public static InvokePattern GetInvokePattern(AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }

    
     }
  }

