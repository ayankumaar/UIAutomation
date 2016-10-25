namespace UIAutomationDemo
{
    // This class de serisalizes the JSON into an object
    class JSONDeSerializer
    {

        public string appName;
        public string appAutomationName;
        public Events[] events;
    }

    
    class Events
    {
        public string autoId;
        public string action;


        public Events(string autoId, string action)
        {
            this.autoId = autoId;
            this.action = action;
        }
    }


}
