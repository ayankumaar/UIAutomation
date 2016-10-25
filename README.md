# UIAutomation

This is a very basic console app which parses an input JSON File and uses an application.
I have made use of the .NET UIAutomation Framework.
You will need to download and add the NewtonSoftJson package.

Tool Used: I have made use of the INSPECT.EXE tool to look for the AutomationId of an element and my code looks for that particular Id of an element to find it out.

Issue: But, in some cases although I have provided the correct AutomationId, the managed code has not been able to find it. I have read a couple of blogs where people have talked about issues between managed and un-managed (INSPECT.EXE is written in un-managed) code.
