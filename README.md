# UIAutomation

This is a very basic console app which parses an input JSON File and uses an application as specified.
There are 2 JSON Files uploaded input.JSON(Starts the Services and finds out elemets in it) and input2.JSON (Starts a calculator instance and performs an addition).

Framework: I have made use of the .NET UIAutomation Framework.

Third Party Library: You need to download and add a reference to the NewtonSoft.Json package in order to parse the JSON input.

Tool Used: I used INSPECT.EXE to look for the AutomationId of an element and the code looks for that particular Id of an element to find it out.

Issue: But, in some cases although I have provided the correct AutomationId, the managed code has not been able to find it. I have read a couple of blogs where people have talked about issues between managed and un-managed (INSPECT.EXE is written in un-managed) code. That issue is yet to be fixed.
